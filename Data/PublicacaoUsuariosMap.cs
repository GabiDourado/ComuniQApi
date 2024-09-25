using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class PublicacaoUsuariosMap : IEntityTypeConfiguration<PublicacaoUsuariosModel>
    {
        public void Configure(EntityTypeBuilder<PublicacaoUsuariosModel> builder)
        {
            builder.HasKey(x => x.PublicacaoUsuarioId);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PublicacaoId).IsRequired().HasMaxLength(255);
        }
    }
}
