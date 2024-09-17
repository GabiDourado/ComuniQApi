using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class DenunciasRepositorio : IDenunciasRepositorio
    {
        private readonly Contexto _dbContext;
        public DenunciasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<DenunciasModel>> GetAll()
        {
            return await _dbContext.Denuncia.ToListAsync();
        }
        public async Task<DenunciasModel> GetById(int id)
        {
            return await _dbContext.Denuncia.FirstOrDefaultAsync(x => x.DenunciaId == id);
        }
        public async Task<DenunciasModel> InsertDenuncia(DenunciasModel denuncia)
        {
            await _dbContext.Denuncia.AddAsync(denuncia);
            await _dbContext.SaveChangesAsync();
            return denuncia;
        }
        public async Task<DenunciasModel> UpdateDenuncia(DenunciasModel denuncia, int id)
        {
            DenunciasModel denuncias = await GetById(id);
            if (denuncias == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                denuncias.DenunciaTitulo = denuncia.DenunciaTitulo;
                denuncias.DenunciaMidia = denuncia.DenunciaMidia;
                denuncias.DenunciaDescricao = denuncia.DenunciaDescricao;
                denuncias.TipoDenunciaId = denuncia.TipoDenunciaId;
                denuncias.BairroId = denuncia.BairroId;
                _dbContext.Denuncia.Update(denuncias);
                await _dbContext.SaveChangesAsync();
            }
            return denuncias;

        }
        public async Task<bool> DeleteDenuncia(int id)
        {
            DenunciasModel denuncias = await GetById(id);
            if (denuncias == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Denuncia.Remove(denuncias);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
