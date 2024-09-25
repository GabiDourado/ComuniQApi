using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComuniQApi.Data
{
    public class PublicacoesMap : IEntityTypeConfiguration<PublicacoesModel>
    {
        public void Configure(EntityTypeBuilder<PublicacoesModel> builder)
        {
            builder.HasKey(x => x.PublicacaoId);
            builder.Property(x => x.PublicacaoTitulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PublicacaoMidia).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PublicacaoDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.BairroId).IsRequired().HasMaxLength(255);
        }
    }
}
