using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Services
{
	public static class TokenService
	{

		public static string GenerateToken(UsuarioConfiguration configuration, IConfiguration config)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(config["SecurityKey"]);
			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new Claim[] {

					new Claim(ClaimTypes.Name, configuration.UserName.ToString())
					//new Claim(ClaimTypes.Role, configuration.Role.ToString())

				}),

				Expires = DateTime.UtcNow.AddHours(2),

				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
