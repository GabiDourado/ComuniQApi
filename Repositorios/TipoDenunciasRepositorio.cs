using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class TipoDenunciasRepositorio : ITipoDenunciasRepositorio
    {
        private readonly Contexto _dbContext;
        public TipoDenunciasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TipoDenunciasModel>> GetAll()
        {
            return await _dbContext.TipoDenuncia.ToListAsync();
        }
        public async Task<TipoDenunciasModel> GetById(int id)
        {
            return await _dbContext.TipoDenuncia.FirstOrDefaultAsync(x => x.TipoDenunciaId == id);
        }
        public async Task<TipoDenunciasModel> InsertTipoDenuncia(TipoDenunciasModel tipoDenuncia)
        {
            await _dbContext.TipoDenuncia.AddAsync(tipoDenuncia);
            await _dbContext.SaveChangesAsync();
            return tipoDenuncia;
        }
        public async Task<TipoDenunciasModel> UpdateTipoDenuncia(TipoDenunciasModel tipoDenuncia, int id)
        {
            TipoDenunciasModel tipoDenuncias = await GetById(id);
            if (tipoDenuncias == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                tipoDenuncias.TipoDenunciaNome = tipoDenuncia.TipoDenunciaNome;
                _dbContext.TipoDenuncia.Update(tipoDenuncias);
                await _dbContext.SaveChangesAsync();
            }
            return tipoDenuncias;

        }
        public async Task<bool> DeleteTipoDenuncia(int id)
        {
            TipoDenunciasModel tipoDenuncias = await GetById(id);
            if (tipoDenuncias == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.TipoDenuncia.Remove(tipoDenuncias);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
