using TestTaskAPI.Dtos.User;

namespace TestTaskAPI.Services
{
	public interface IAuthService
	{
		public string GenerateToken(UserRegisterDto userRegisterDto);
		public Task<string> RegisterUser(UserRegisterDto userRegisterDto);
		public Task<string> Login(UserRegisterDto userLoginDto);
	}
}
