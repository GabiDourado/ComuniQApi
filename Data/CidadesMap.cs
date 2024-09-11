using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComuniQApi.Data
{
    public class CidadesMap : IEntityTypeConfiguration<CidadesModel>
    {
        public void Configure(EntityTypeBuilder<CidadesModel> builder)
        {
            builder.HasKey(x => x.CidadeId);
            builder.Property(x => x.CidadeNome).IsRequired().HasMaxLength(255);
        }
    }
}
