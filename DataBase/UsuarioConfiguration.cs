using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataBase
{
	internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{

			builder
				.Property(u => u.Nome)
				.HasColumnType("nvarchar(100)")
				.IsRequired();

			builder
				.Property(u => u.Email)
				.HasColumnType("nvarchar(100)")
				.IsRequired();

			builder
				.Property(u => u.Senha)
				.HasColumnType("nvarchar(100)")
				.IsRequired();

		}
	}
}
