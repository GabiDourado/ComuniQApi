using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class UsuariosMap : IEntityTypeConfiguration<UsuariosModel>
    {
        public void Configure(EntityTypeBuilder<UsuariosModel> builder)
        {
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.UsuarioNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioSobrenome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioApelido).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioTelefone).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioCPF).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioCEP).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioCidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioBairro).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioEstado).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioSenha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioFoto).IsRequired();
            builder.Property(x => x.TipoPerfilId).IsRequired().HasMaxLength(255);
        }
    }
}

