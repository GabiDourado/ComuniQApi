using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class CidadesRepositorio : ICidadesRepositorio
    {
        private readonly Contexto _dbContext;

        public CidadesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CidadesModel>> GetAll()
        {
            return await _dbContext.Cidade.ToListAsync();
        }

        public async Task<CidadesModel> GetById(int id)
        {
            return await _dbContext.Cidade.FirstOrDefaultAsync(x => x.CidadeId == id);
        }

        public async Task<CidadesModel> InsertCidade(CidadesModel cidade)
        {
            await _dbContext.Cidade.AddAsync(cidade);
            await _dbContext.SaveChangesAsync();
            return cidade;
        }

        public async Task<CidadesModel> UpdateCidade(CidadesModel cidade, int id)
        {
            CidadesModel cidades = await GetById(id);
            if (cidades == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                cidades.CidadeNome = cidade.CidadeNome;
                _dbContext.Cidade.Update(cidades);
                await _dbContext.SaveChangesAsync();
            }
            return cidades;

        }

        public async Task<bool> DeleteCidade(int id)
        {
            CidadesModel cidades = await GetById(id);
            if (cidades == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Cidade.Remove(cidades);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
