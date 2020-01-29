using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infra.Mapping
{
    class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("TB_Livro");
            builder.HasKey(x => x.Id);


            builder.HasOne(c => c.Autor).WithMany(x => x.Livros).HasForeignKey(x => x.AutorId);
            builder.HasIndex(x => x.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
