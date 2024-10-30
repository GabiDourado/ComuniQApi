using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class PublicacoesRepositorio : IPublicacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public PublicacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PublicacaoCompleta>> GetAll()
        {
            List<PublicacaoCompleta> publicacoes = await _dbContext.Publicacao
                .Join(_dbContext.Usuario,
                      publicacao => publicacao.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (publicacao, usuario) => new PublicacaoCompleta
                      {
                          PublicacaoId = publicacao.PublicacaoId,
                          PublicacaoTitulo = publicacao.PublicacaoTitulo,
                          PublicacaoMidia = publicacao.PublicacaoMidia,
                          PublicacaoDescricao = publicacao.PublicacaoDescricao,
                          BairroId = publicacao.BairroId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome = usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
                      }).ToListAsync();

            return publicacoes;
        }

        public async Task<PublicacaoCompleta> GetPublicacao(int id)
        {
            PublicacaoCompleta publicacao = await _dbContext.Publicacao
                .Join(_dbContext.Usuario,
                      publicacao => publicacao.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (publicacao, usuario) => new PublicacaoCompleta
                      {
                          PublicacaoId = publicacao.PublicacaoId,
                          PublicacaoTitulo = publicacao.PublicacaoTitulo,
                          PublicacaoMidia = publicacao.PublicacaoMidia,
                          PublicacaoDescricao = publicacao.PublicacaoDescricao,
                          BairroId = publicacao.BairroId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome = usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
                      }).FirstOrDefaultAsync(x => x.PublicacaoId == id);

            return publicacao;
        }

        public async Task<PublicacoesModel> GetById(int id)
        {
            return await _dbContext.Publicacao.FirstOrDefaultAsync(x => x.PublicacaoId == id);
        }

        public async Task<PublicacoesModel> InsertPublicacao(PublicacoesModel publicacao)
        {
            await _dbContext.Publicacao.AddAsync(publicacao);
            await _dbContext.SaveChangesAsync();
            return publicacao;
        }

        public async Task<PublicacoesModel> UpdatePublicacao(PublicacoesModel publicacao, int id)
        {
            PublicacoesModel publicacoes = await GetById(id);
            if (publicacoes == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                publicacoes.PublicacaoTitulo = publicacao.PublicacaoTitulo;
                publicacoes.PublicacaoMidia = publicacao.PublicacaoMidia;
                publicacoes.PublicacaoDescricao = publicacao.PublicacaoDescricao;
                publicacoes.BairroId = publicacao.BairroId;
                publicacoes.UsuarioId= publicacao.UsuarioId;
                _dbContext.Publicacao.Update(publicacoes);
                await _dbContext.SaveChangesAsync();
            }
            return publicacoes;

        }

        public async Task<bool> DeletePublicacao(int id)
        {
            PublicacoesModel publicacoes = await GetById(id);
            if (publicacoes == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Publicacao.Remove(publicacoes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }



}

    