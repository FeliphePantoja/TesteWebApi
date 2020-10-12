using Microsoft.EntityFrameworkCore;
using Model;

namespace DataBase
{
	public class DataBaseContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Produtos> Produtos { get; set; }

		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
		{
			this.Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
			modelBuilder.ApplyConfiguration<Produtos>(new ProdutosConfiguration());
		}

	}
}
