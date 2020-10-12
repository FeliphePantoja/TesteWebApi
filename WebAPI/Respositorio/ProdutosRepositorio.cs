using DataBase;
using Model;
using System.Collections.Generic;

namespace WebAPI.Respositorio
{
	public class ProdutosRepositorio : IRepository<Produtos>
	{
		private readonly RepositorioBaseEF<Produtos> _repoProdutos;

		public ProdutosRepositorio(RepositorioBaseEF<Produtos> repo)
		{
			this._repoProdutos = repo;
		}

		public void Alterar(params Produtos[] obj)
		{
			this._repoProdutos.Alterar(obj);
		}

		public void Excluir(params Produtos[] obj)
		{
			this._repoProdutos.Excluir(obj);
		}

		public Produtos Find(int key)
		{
			var resultado = this._repoProdutos.Find(key);
			if (resultado != null) return resultado;
			return null;
		}

		public List<Produtos> GetAll()
		{
			return this._repoProdutos.GetAll();
		}

		public void Incluir(params Produtos[] obj)
		{
			this._repoProdutos.Incluir(obj);
		}
	}
}