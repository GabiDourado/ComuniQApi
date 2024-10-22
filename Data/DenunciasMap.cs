using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class DenunciasMap : IEntityTypeConfiguration<DenunciasModel>
    {
        public void Configure(EntityTypeBuilder<DenunciasModel> builder)
        {
            builder.HasKey(x => x.DenunciaId);
            builder.Property(x => x.DenunciaTitulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DenunciaMidia);
            builder.Property(x => x.DenunciaDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoDenunciaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.BairroId).IsRequired().HasMaxLength(255);
        }
    }
}