using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComuniQApi.Data
{
    public class CampanhasMap : IEntityTypeConfiguration<CampanhasModel>
    {
        public void Configure(EntityTypeBuilder<CampanhasModel> builder)
        {
            builder.HasKey(x => x.CampanhaId);
            builder.Property(x => x.CampanhaTitulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CampanhaMidia);
            builder.Property(x => x.CampanhaDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CampanhaDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoCampanhaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoCampanhaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CidadeId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}
