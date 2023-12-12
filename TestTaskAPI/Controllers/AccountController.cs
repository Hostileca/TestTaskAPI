using Microsoft.AspNetCore.Mvc;
using TestTaskAPI.Dtos.User;
using TestTaskAPI.Services;

namespace CustomIdentityServer4.Controllers
{
	[Route("api/v1/users")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAuthService _userService;	

		public AccountController(IAuthService userService)
		{
			_userService = userService;
		}

		[HttpPost("registration")]
		public async Task<string> RegisterUser(UserRegisterDto userRegisterDto)
		{
			return await _userService.RegisterUser(userRegisterDto);
		}

		[HttpPost("authorization")]
		public async Task<string> Login(UserRegisterDto userRegisterDto)
		{
			return await _userService.Login(userRegisterDto);
		}
	}
}