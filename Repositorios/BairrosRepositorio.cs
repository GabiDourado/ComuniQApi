using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class BairrosRepositorio : IBairrosRepositorio
    {
        private readonly Contexto _dbContext;

        public BairrosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BairrosModel>> GetAll()
        {
            return await _dbContext.Bairro.ToListAsync();
        }

        public async Task<BairrosModel> GetById(int id)
        {
            return await _dbContext.Bairro.FirstOrDefaultAsync(x => x.BairroId == id);
        }

        public async Task<BairrosModel> InsertBairro(BairrosModel bairro)
        {
            await _dbContext.Bairro.AddAsync(bairro);
            await _dbContext.SaveChangesAsync();
            return bairro;
        }

        public async Task<BairrosModel> UpdateBairro(BairrosModel bairro, int id)
        {
            BairrosModel bairros = await GetById(id);
            if (bairros == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                bairros.BairroNome = bairro.BairroNome;
                bairros.CidadeId = bairro.CidadeId;
                bairros.EstadoId = bairro.EstadoId;
                _dbContext.Bairro.Update(bairros);
                await _dbContext.SaveChangesAsync();
            }
            return bairros;

        }

        public async Task<bool> DeleteBairro(int id)
        {
            BairrosModel bairros = await GetById(id);
            if (bairros == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Bairros.Remove(bairros);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
