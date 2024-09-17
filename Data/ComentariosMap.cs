using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class ComentariosMap : IEntityTypeConfiguration<ComentariosModel>
    {
        public void Configure(EntityTypeBuilder<ComentariosModel> builder)
        {
            builder.HasKey(x => x.ComentarioId);
            builder.Property(x => x.ComentarioTexto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
