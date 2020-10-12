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
	public class ProdutosController : Controller
	{
		private readonly IRepository<Produtos> _repository;

		public ProdutosController(IRepository<Produtos> repository)
		{
			this._repository = repository;
		}

		[HttpGet]
		public IEnumerable GetAll()
		{
			return this._repository.GetAll();
		}

		[HttpGet("{id}", Name = "GetProduto")]
		public IActionResult GetProduto(int id)
		{
			var retornoProduto = this._repository.Find(id);

			if (retornoProduto == null)
				return NotFound();

			return new ObjectResult(retornoProduto);
		}

		[HttpPost]
		public IActionResult Incluir([FromBody] Produtos produtos)
		{
			if (ModelState.IsValid)
			{
				var novoProduto = new Produtos()
				{
					Descricao = produtos.Descricao,
					Quantidade = produtos.Quantidade
				};

				this._repository.Incluir(novoProduto);

				//var uri = Url.Action("Recuperar", new { id = usuario.id });
				return CreatedAtRoute("GetProduto", new { id = novoProduto.id }, novoProduto);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public IActionResult Alterar(int id, [FromBody] Produtos produtos)
		{
			if (produtos == null || produtos.id != id)
				return BadRequest();

			var atualizaProduto = this._repository.Find(id);

			if (atualizaProduto == null)
				return NotFound();

			atualizaProduto.Descricao = produtos.Descricao;
			atualizaProduto.Quantidade = produtos.Quantidade;

			this._repository.Alterar(atualizaProduto);

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