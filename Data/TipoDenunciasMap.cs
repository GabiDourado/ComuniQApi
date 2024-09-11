using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class TipoDenunciasMap : IEntityTypeConfiguration<TipoDenunciasModel>
    {
        public void Configure(EntityTypeBuilder<TipoDenunciasModel> builder)
        {
            builder.HasKey(x => x.TipoDenunciaId);
            builder.Property(x => x.TipoDenunciaNome).IsRequired().HasMaxLength(255);
        }
    }
}
