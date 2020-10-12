using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
	public class RepositorioBaseEF<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly DataBaseContext _context;

		public RepositorioBaseEF(DataBaseContext context)
		{
			this._context = context;
		}

		public List<TEntity> GetAll()
		{
			return _context.Set<TEntity>().AsQueryable().ToList();
		}

		public void Alterar(params TEntity[] obj)
		{
			_context.Set<TEntity>().UpdateRange(obj);
			_context.SaveChanges();
		}

		public void Excluir(params TEntity[] obj)
		{
			_context.Set<TEntity>().RemoveRange(obj);
			_context.SaveChanges();
		}

		public TEntity Find(int key)
		{
			return _context.Find<TEntity>(key);
		}

		public void Incluir(params TEntity[] obj)
		{
			_context.Set<TEntity>().AddRange(obj);
			_context.SaveChanges();
		}
	}
}
