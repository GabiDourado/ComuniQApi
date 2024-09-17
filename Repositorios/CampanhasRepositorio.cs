using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class CampanhasRepositorio : ICampanhasRepositorio
    {
        private readonly Contexto _dbContext;

        public CampanhasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CampanhasModel>> GetAll()
        {
            return await _dbContext.Campanha.ToListAsync();
        }
        public async Task<CampanhasModel> GetById(int id)
        {
            return await _dbContext.Campanha.FirstOrDefaultAsync(x => x.CampanhaId == id);
        }

        public async Task<CampanhasModel> InsertCampanha(CampanhasModel campanha)
        {
            await _dbContext.Campanha.AddAsync(campanha);
            await _dbContext.SaveChangesAsync();
            return campanha;
        }

        public async Task<CampanhasModel> UpdateCampanha(CampanhasModel campanha, int id)
        {
            CampanhasModel campanhas = await GetById(id);
            if (campanhas == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                campanhas.CampanhaTitulo = campanha.CampanhaTitulo;
                _dbContext.Campanha.Update(campanhas);
                await _dbContext.SaveChangesAsync();
            }
            return campanhas;

        }

        public async Task<bool> DeleteCampanha(int id)
        {
            CampanhasModel campanhas = await GetById(id);
            if (campanhas == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Campanha.Remove(campanhas);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}

