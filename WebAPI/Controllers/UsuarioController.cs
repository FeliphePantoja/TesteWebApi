using DataBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections;

namespace WebAPI.Controllers
{
	[ApiController]
	//[Authorize()]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	public class UsuarioController : Controller
	{
		private readonly IRepository<Usuario> _repository;

		public UsuarioController(IRepository<Usuario> repository)
		{
			this._repository = repository;
			//IncluirTestes();
		}

		private void IncluirTestes()
		{
			var novoUsuario = new Usuario()
			{
				Nome = "Felipe",
				Email = "Felipe@gmail.com",
				Senha = "123456"
			};

			this._repository.Incluir(novoUsuario);
		}

		//[HttpGet]
		//public IActionResult Mensagem()
		//{
		//	return Ok("API CRIADA");
		//}

		[HttpGet(Name = "GetUser")]
		public IEnumerable GetAll()
		{
			return this._repository.GetAll();
		}

		[HttpPost]
		public IActionResult Incluir([FromBody] Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				var novoUsuario = new Usuario()
				{
					Nome = usuario.Nome,
					Email = usuario.Email,
					Senha = usuario.Senha
				};

				this._repository.Incluir(novoUsuario);

				//var uri = Url.Action("Recuperar", new { id = usuario.id });
				return CreatedAtRoute("GetUser", new { id = usuario.id }, novoUsuario);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public IActionResult Alterar(int id, [FromBody] Usuario usuario)
		{
			if (usuario == null || usuario.id != id)
				return BadRequest();

			var atualizaUsuario = this._repository.Find(id);

			if (atualizaUsuario == null)
				return NotFound();

			atualizaUsuario.Nome = usuario.Nome;
			atualizaUsuario.Email = usuario.Email;
			atualizaUsuario.Senha = usuario.Senha;

			this._repository.Alterar(atualizaUsuario);

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var resultadoUsuario = this._repository.Find(id);

			if (resultadoUsuario == null)
				return NotFound();

			this._repository.Excluir(resultadoUsuario);

			return new NoContentResult();
		}
	}
}
