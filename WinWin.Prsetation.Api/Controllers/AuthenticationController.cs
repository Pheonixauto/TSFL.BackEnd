using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinWin.Domain.Model.Account;
using WinWin.Service.AuthenticationService;
using WinWin.Service.IService.IUserServices;
using WinWin.Service.IService.IUserTokenService;

namespace WinWin.Prsetation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUerTokens _tokens;

        public AuthenticationController(IUserService userService, ITokenHandler tokenHandler, IUerTokens tokens)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
            _tokens = tokens;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLogin([FromBody] AccountModel accountModel)
        {
            if (accountModel.UserName == null || accountModel.PassWord == null)
            {
                return BadRequest();
            }
            var result = await _userService.CheckLogin(accountModel.UserName, accountModel.PassWord);
            if (result == null)
            {
                return Unauthorized();
            }


            (string accessToken, DateTime expiredAccessToken) = await _tokenHandler.CreateToken(result);
            (string refreshToken, DateTime expiredrefreshToken) = await _tokenHandler.CreateRefreshToken(result);

            await _tokens.SaveToken(new Domain.Entity.Token.Tokens {
                AccessToken = accessToken,
                ExpiredDateAccessToken = expiredAccessToken,
                RefreshToken = refreshToken,
                ExpiredDateRefreshToken = expiredrefreshToken,
                UserId = result.Id,
                CreatedDateToken = DateTime.Now
            });

            return Ok(new JwtModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserName = result.UserName,
                FullName = result.DisplayName,
            });

        }
    }
}
