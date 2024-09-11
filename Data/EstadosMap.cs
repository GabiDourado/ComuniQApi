using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class EstadosMap : IEntityTypeConfiguration<EstadosModel>
    {
        public void Configure(EntityTypeBuilder<EstadosModel> builder)
        {
            builder.HasKey(x => x.EstadoId);
            builder.Property(x => x.EstadoNome).IsRequired().HasMaxLength(255);
        }
    }
}
