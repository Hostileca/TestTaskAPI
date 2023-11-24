using Microsoft.AspNetCore.Mvc;
using TestTaskAPI.Dtos.User;
using TestTaskAPI.Services;

namespace CustomIdentityServer4.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAuthService _userService;	

		public AccountController(IAuthService userService)
		{
			_userService = userService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
		{
			if(await _userService.RegisterUser(userRegisterDto))
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(UserRegisterDto userRegisterDto)
		{
			var result = await _userService.Login(userRegisterDto);
			if (result)
			{
				var tokenString = _userService.GenerateToken(userRegisterDto);
				return Ok(tokenString);
			}
			return BadRequest();
		}
	}
}