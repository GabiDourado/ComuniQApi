using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComuniQApi.Data
{
    public class BairrosMap : IEntityTypeConfiguration<BairrosModel>
    {
        public void Configure(EntityTypeBuilder<BairrosModel> builder)
        {
            builder.HasKey(x => x.BairroId);
            builder.Property(x => x.BairroNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CidadeId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EstadoId).IsRequired().HasMaxLength(255);
        }
    }
    
    
}
