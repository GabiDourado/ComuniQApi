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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
