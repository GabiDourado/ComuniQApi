using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComuniQApi.Data
{
    public class TipoCampanhasMap : IEntityTypeConfiguration<TipoCampanhasModel>
    {
        public void Configure(EntityTypeBuilder<TipoCampanhasModel> builder)
        {
            builder.HasKey(x => x.TipoCampanhaId);
            builder.Property(x => x.TipoCampanhaNome).IsRequired().HasMaxLength(255);
        }
    }
}
