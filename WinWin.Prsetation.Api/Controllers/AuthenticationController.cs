using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinWin.Domain.Model.Account;
using WinWin.Service.AuthenticationService;
using WinWin.Service.IService.IUserServices;

namespace WinWin.Prsetation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationController(IUserService userService, ITokenHandler tokenHandler)
        {
           _userService = userService;
            _tokenHandler = tokenHandler;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLogin([FromBody] AccountModel accountModel)
        {
            if (accountModel.UserName == null || accountModel.PassWord==null)
            {
                return BadRequest();
            }
            var result = await _userService.CheckLogin(accountModel.UserName, accountModel.PassWord);
            if (result == null)
            {
                return Unauthorized();
            }

            return await Task.Factory.StartNew(() =>
            {
                return Ok(_tokenHandler.CreateToken(result));
            });
        }
    }
}
