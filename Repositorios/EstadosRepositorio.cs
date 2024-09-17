using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class EstadosRepositorio : IEstadosRepositorio
    {
        private readonly Contexto _dbContext;

        public EstadosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EstadosModel>> GetAll()
        {
            return await _dbContext.Estado.ToListAsync();
        }

        public async Task<EstadosModel> GetById(int id)
        {
            return await _dbContext.Estado.FirstOrDefaultAsync(x => x.EstadoId == id);
        }

        public async Task<EstadosModel> InsertEstado(EstadosModel estado)
        {
            await _dbContext.Estado.AddAsync(estado);
            await _dbContext.SaveChangesAsync();
            return estado;
        }

        public async Task<EstadosModel> UpdateEstado(EstadosModel estado, int id)
        {
            EstadosModel estados = await GetById(id);
            if (estados == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                estados.EstadoNome = estado.EstadoNome;
                _dbContext.Estado.Update(estados);
                await _dbContext.SaveChangesAsync();
            }
            return estados;

        }

        public async Task<bool> DeleteEstado(int id)
        {
            EstadosModel estados = await GetById(id);
            if (estados == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Estado.Remove(estados);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
