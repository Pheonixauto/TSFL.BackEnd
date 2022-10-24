using Microsoft.AspNetCore.Mvc;
using System.Net;
using TSFL.Application.IRepository.ICardRepository;
using TSFL.Application.RequestParameters;
using TSFL.Application.ViewModels.CardModel;
using TSFL.Domain.Entities;
using System.IO;

namespace TSFL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardReadRepository _cardReadRepository;
        private readonly ICardWriteRepository _cardWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //private readonly ICardService _cardService;

        public class FileUpload
        {
            public IFormFile formFile1 { get; set; }
        }

        public CardController(ICardReadRepository cardReadRepository
            , ICardWriteRepository cardWriteRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _cardReadRepository = cardReadRepository;
            _cardWriteRepository = cardWriteRepository;
           _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCard([FromQuery]Pagination pagination)
        {
            var count = _cardReadRepository.GetAll(false).Count();
            var cards = _cardReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new {
                p.Id,
                p.Name,
                p.CreatedDate,
                p.UpdatedDate,
                p.CardGroupCard,
            }).ToList();
            if (cards != null)
            {
                return Ok(
                    new
                    {
                        cards,
                        count
                    }
                    );
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById([FromRoute] Guid id)
        {
            var card = await _cardReadRepository.GetByIdAsync(id, false);
            return (card == null) ?  NotFound() : Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> AddCards(VM_Create_Card vM_Create_Card)
        {
            if (ModelState.IsValid)
            {

            }
           await _cardWriteRepository.AddAsync(new Card()
            {
                Name = vM_Create_Card.Name,

            });
            await _cardWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard(VM_Update_Card vM_Update_Card)
        {
            Card card = await _cardReadRepository.GetByIdAsync(vM_Update_Card.Id);
            card.Name = vM_Update_Card.Name;
            await _cardWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var resultCheck = await _cardWriteRepository.RemoveAsync(id);
            await _cardWriteRepository.SaveAsync();
            return Ok(resultCheck);
        }

        [HttpPost("UpLoadImage")]
        //public async Task<ActionResult> UpLoadImage([FromForm] List<FileUpload> formFiles)
        //{
        //    bool result = false;

        //    try
        //    {
        //        //var _uploadFile = Request.Form.Files;
        //        foreach (IFormFile formFile in formFiles)
        //        {
        //            string fileName = formFile.FileName;
        //            string filePath = GetFilePath();
        //            if (!Directory.Exists(filePath))
        //            {
        //                Directory.CreateDirectory(filePath);
        //            }
        //            string imagePath = filePath + fileName;
        //            if (System.IO.File.Exists(imagePath))
        //            {
        //                System.IO.File.Delete(imagePath);
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(imagePath))
        //            {
        //                 fileStream.CopyTo(fileStream);
        //                fileStream.Flush();
        //                result = true;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return Ok(result);
        //}

        public async Task<ActionResult> UpLoadImage([FromForm] FileUpload formFile)
        {
            try
            {
                if (formFile.formFile1.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + formFile.formFile1.FileName))
                    {
                        formFile.formFile1.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok("ok");
                    }
                }
                else
                {
                    return BadRequest("false");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{fileName:alpha}")]
        public async Task<IActionResult> GetCardImage([FromRoute] string fileName)
        {
            //string filePath = GetFilePath();
            //string imagePath = filePath + fileName + ".png";
            //if (System.IO.File.Exists(imagePath))
            //{
            //    byte[] b =  System.IO.File.ReadAllBytes(imagePath);
            //    return File(b, "image/png");
            //}
            //return NoContent();
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if (System.IO.File.Exists(filePath))
            {
               byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            return NoContent();

        }

        [NonAction]
        private string GetFilePath()
        {
            //return _webHostEnvironment.WebRootPath + @"\Cards";

            return _webHostEnvironment.WebRootPath + "\\uploads\\";
        }
    }
}
