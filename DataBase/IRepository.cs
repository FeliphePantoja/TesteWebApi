using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
	public interface IRepository<TEntity> where TEntity : class
	{
		List<TEntity> GetAll();
		TEntity Find(int key);
		void Incluir(params TEntity[] obj);
		void Alterar(params TEntity[] obj);
		void Excluir(params TEntity[] obj);
	}
}
