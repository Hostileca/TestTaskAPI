﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestTaskAPI.Dtos.User;

namespace TestTaskAPI.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _config;

		public AuthService(UserManager<IdentityUser> userManager, IConfiguration config)
		{
			_userManager = userManager;
			_config = config;
		}

		public string GenerateToken(UserRegisterDto userRegisterDto)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name,userRegisterDto.UserName)
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
			var signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
			var securityToken = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				issuer: _config["JwtSettings:Issuer"],
				audience: _config["JwtSettings:Audience"],
				signingCredentials: signingCredentials);
			
			var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
			return tokenString;
		}

		public async Task<string> Login(UserRegisterDto userLoginDto)
		{		
			var identityUser = await _userManager.FindByNameAsync(userLoginDto.UserName);
			if (identityUser is null) {
				return "user not found";
			}
			if(await _userManager.CheckPasswordAsync(identityUser, userLoginDto.Password))
			{
				return GenerateToken(userLoginDto);
			}
			return "Incorrect password";
		}

		public async Task<string> RegisterUser(UserRegisterDto userRegisterDto)
		{
			var identityUser = new IdentityUser
			{
				UserName = userRegisterDto.UserName,
				Email = userRegisterDto.UserName
			};

			var result = await _userManager.CreateAsync(identityUser, userRegisterDto.Password);
			if (result.Succeeded)
			{
				return GenerateToken(userRegisterDto);
			}
			return "Error creating user";
		}
	}
}
