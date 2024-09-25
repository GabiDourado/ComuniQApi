using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class TipoPerfisRepositorio : ITipoPerfisRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoPerfisRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoPerfisModel>> GetAll()
        {
            return await _dbContext.TipoPerfil.ToListAsync();
        }

        public async Task<TipoPerfisModel> GetById(int id)
        {
            return await _dbContext.TipoPerfil.FirstOrDefaultAsync(x => x.TipoPerfilId == id);
        }

        public async Task<TipoPerfisModel> InsertTipoPerfil(TipoPerfisModel tipoPerfil)
        {
            await _dbContext.TipoPerfil.AddAsync(tipoPerfil);
            await _dbContext.SaveChangesAsync();
            return tipoPerfil;
        }

        public async Task<TipoPerfisModel> UpdateTipoPerfil(TipoPerfisModel tipoPerfil, int id)
        {
            TipoPerfisModel tipoPerfis = await GetById(id);
            if (tipoPerfis == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                tipoPerfis.TipoPerfilNome = tipoPerfil.TipoPerfilNome;
                _dbContext.TipoPerfil.Update(tipoPerfis);
                await _dbContext.SaveChangesAsync();
            }
            return tipoPerfis;

        }

        public async Task<bool> DeleteTipoPerfil(int id)
        {
            TipoPerfisModel tipoPerfis = await GetById(id);
            if (tipoPerfis == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.TipoPerfil.Remove(tipoPerfis);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
