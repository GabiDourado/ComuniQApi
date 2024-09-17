﻿using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class TipoCampanhasRepositorio : ITipoCampanhasRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoCampanhasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoCampanhasModel>> GetAll()
        {
            return await _dbContext.TipoCamapanha.ToListAsync();
        }

        public async Task<TipoCampanhasModel> GetById(int id)
        {
            return await _dbContext.TipoCamapanha.FirstOrDefaultAsync(x => x.TipoCampanhaId == id);
        }

        public async Task<TipoCampanhasModel> InsertTipoCampanha(TipoCampanhasModel tipoCampanha)
        {
            await _dbContext.TipoCamapanha.AddAsync(tipoCampanha);
            await _dbContext.SaveChangesAsync();
            return tipoCampanha;
        }

        public async Task<TipoCampanhasModel> UpdateTipoCampanha(TipoCampanhasModel tipoCampanha, int id)
        {
            TipoCampanhasModel tipoCampanhas = await GetById(id);
            if (tipoCampanhas == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                tipoCampanhas.TipoCampanhaNome = tipoCampanha.TipoCampanhaNome;
                _dbContext.TipoCamapanha.Update(tipoCampanhas);
                await _dbContext.SaveChangesAsync();
            }
            return tipoCampanhas;

        }

        public async Task<bool> DeleteTipoCampanha(int id)
        {
            TipoCampanhasModel tipoCampanhas = await GetById(id);
            if (tipoCampanhas == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.TipoCamapanha.Remove(tipoCampanhas);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}