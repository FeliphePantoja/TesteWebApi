using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class TokenController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly string _username = "AdminAPIWORD";
		private readonly string _password = "dvf+@n3BRU^qJp?U";
		private readonly string _role = "CB";

		public TokenController(IConfiguration configuration)
		{
			this._configuration = configuration;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioConfiguration usuario)
		{
			if (usuario.UserName == this._username && usuario.PassWord == this._password)
			{
				var token = TokenService.GenerateToken(usuario, this._configuration);
				usuario.PassWord = string.Empty;
				return new
				{
					usuario = usuario,
					token = token
				};

			}
			else return NotFound(new { message = "Usuário ou senha inválida" });

		}
	}
}
