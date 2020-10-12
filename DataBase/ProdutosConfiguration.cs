using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataBase
{
	internal class ProdutosConfiguration : IEntityTypeConfiguration<Produtos>
	{
		public void Configure(EntityTypeBuilder<Produtos> builder)
		{
			builder
				.Property(u => u.Descricao)
				.HasColumnType("nvarchar(100)")
				.IsRequired();

			builder
				.Property(u => u.Quantidade)
				.HasColumnType("int")
				.IsRequired(); 
		}
	}
}
