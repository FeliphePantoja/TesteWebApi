using DataBase;
using Model;
using System.Collections.Generic;

namespace WebAPI.Respositorio	
{
	public class UsuarioRepositorio : IRepository<Usuario>
	{
		private readonly RepositorioBaseEF<Usuario> _repoUsuario;

		public UsuarioRepositorio(RepositorioBaseEF<Usuario> repo)
		{
			this._repoUsuario = repo;
		} 

		public List<Usuario> GetAll()
		{
			return this._repoUsuario.GetAll();
		}

		public void Alterar(params Usuario[] obj)
		{
			this._repoUsuario.Alterar(obj);
		}

		public void Excluir(params Usuario[] obj)
		{
			this._repoUsuario.Excluir(obj);
		}

		public Usuario Find(int key)
		{
			var resultado = this._repoUsuario.Find(key);
			if (resultado != null) return resultado;
			return null;
		}

		public void Incluir(params Usuario[] obj)
		{
			this._repoUsuario.Incluir(obj);
		}
	}
}
