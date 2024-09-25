using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class TipoPerfisMap : IEntityTypeConfiguration<TipoPerfisModel>
    {
        public void Configure(EntityTypeBuilder<TipoPerfisModel> builder)
        {
            builder.HasKey(x => x.TipoPerfilId);
            builder.Property(x => x.TipoPerfilNome).IsRequired().HasMaxLength(255);
        }
    }
}
