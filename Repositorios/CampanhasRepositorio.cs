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

        public async Task<List<CampanhaCompleta>> GetAll()
        {
            List<CampanhaCompleta> campanhas = await _dbContext.Campanha
                .Join(_dbContext.Usuario,
                      campanha => campanha.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (campanha, usuario) => new CampanhaCompleta
                      {
                          CampanhaId = campanha.CampanhaId,
                          CampanhaDescricao = campanha.CampanhaDescricao,
                          CampanhaTitulo = campanha.CampanhaTitulo,
                          CampanhaMidia = campanha.CampanhaMidia,
                          TipoCampanhaId = campanha.TipoCampanhaId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome = usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
                      }).ToListAsync();

            return campanhas;
        }
        public async Task<CampanhaCompleta> GetCampanha(int id)
        {
            CampanhaCompleta campanha = await _dbContext.Campanha
                .Join(_dbContext.Usuario,
                      campanha => campanha.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (campanha, usuario) => new CampanhaCompleta
                      {
                          CampanhaId = campanha.CampanhaId,
                          CampanhaDescricao = campanha.CampanhaDescricao,
                          CampanhaTitulo = campanha.CampanhaTitulo,
                          CampanhaMidia = campanha.CampanhaMidia,
                          TipoCampanhaId = campanha.TipoCampanhaId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome = usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
                      }).FirstOrDefaultAsync(x => x.CampanhaId == id);

            return campanha;
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
                campanhas.CampanhaMidia = campanha.CampanhaMidia;
                campanhas.CampanhaDescricao = campanha.CampanhaDescricao;
                campanhas.TipoCampanhaId = campanha.TipoCampanhaId;
                campanhas.CidadeId = campanha.CidadeId;
                campanhas.UsuarioId= campanha.UsuarioId;
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

