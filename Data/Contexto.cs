using ComuniQApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsuariosModel> Usuario { get; set; }
        public DbSet<DenunciasModel> Denuncia { get; set; }
        public DbSet<TipoDenunciasModel> TipoDenuncia { get; set; }
        public DbSet<CidadesModel> Cidade { get; set; }
        public DbSet<CampanhasModel> Campanha { get; set; }
        public DbSet<TipoCampanhasModel> TipoCampanha { get; set; }
        public DbSet<BairrosModel> Bairro { get; set; }
        public DbSet<PublicacoesModel> Publicacao { get; set; }
        public DbSet<ComentariosModel> Comentario { get; set; }
        public DbSet<EstadosModel> Estado { get; set; }
        public DbSet<TipoPerfisModel> TipoPerfil { get; set; }
        public DbSet<PublicacaoUsuariosModel> PublicacaoUsuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new DenunciasMap());
            modelBuilder.ApplyConfiguration(new TipoDenunciasMap());
            modelBuilder.ApplyConfiguration(new CidadesMap());
            modelBuilder.ApplyConfiguration(new CampanhasMap());
            modelBuilder.ApplyConfiguration(new TipoCampanhasMap());
            modelBuilder.ApplyConfiguration(new BairrosMap());
            modelBuilder.ApplyConfiguration(new PublicacoesMap());
            modelBuilder.ApplyConfiguration(new ComentariosMap());
            modelBuilder.ApplyConfiguration(new EstadosMap());
            modelBuilder.ApplyConfiguration(new TipoPerfisMap());
            modelBuilder.ApplyConfiguration(new PublicacaoUsuariosMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
