using TestTaskAPI.Dtos.User;

namespace TestTaskAPI.Services
{
	public interface IAuthService
	{
		public string GenerateToken(UserRegisterDto userRegisterDto);
		public Task<bool> RegisterUser(UserRegisterDto userRegisterDto);
		public Task<bool> Login(UserRegisterDto userLoginDto);
	}
}
