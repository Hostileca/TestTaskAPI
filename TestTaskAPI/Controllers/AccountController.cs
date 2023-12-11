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
		public async Task<Response<bool>> RegisterUser(UserRegisterDto userRegisterDto)
		{
			if(await _userService.RegisterUser(userRegisterDto))
			{
				return new Response<bool>(true);
			}
			return new Response<bool>("User registration error");
		}

		[HttpPost("authorization")]
		public async Task<Response<string>> Login(UserRegisterDto userRegisterDto)
		{
			var result = await _userService.Login(userRegisterDto);
			if (result)
			{
				var tokenString = _userService.GenerateToken(userRegisterDto);
				return new Response<string>(tokenString);
			}
			return new Response<string>("Wrong login or password");
		}
	}
}