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
        public DbSet<CampanhasMap> Campanha { get; set; }
        public DbSet<TipoCampanhasMap> TipoCamapanha { get; set; }
        public DbSet<BairrosMap> Bairros { get; set; }
        public DbSet<PublicacoesMap> Publicacoes { get; set; }


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
            base.OnModelCreating(modelBuilder);
        }
    }
}
