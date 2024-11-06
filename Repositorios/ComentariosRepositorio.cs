using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class ComentariosRepositorio : IComentariosRepositorio
    {
        private readonly Contexto _dbContext;
        public ComentariosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ComentarioCompleto>> GetAll()
        {
            List<ComentarioCompleto> comentarios = await _dbContext.Comentario
                .Join(_dbContext.Usuario,
                      comentario => comentario.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (comentario, usuario) => new ComentarioCompleto
                      {
                          ComentarioId = comentario.ComentarioId,
                          ComentarioTexto = comentario.ComentarioTexto,
                          PublicacaoId = comentario.PublicacaoId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome= usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
              }).ToListAsync();

            return comentarios;
        }

        public async Task<List<ComentarioCompleto>> GetComentariosByPost(int id )
        {
            List<ComentarioCompleto> comentarios = await _dbContext.Comentario
                .Where( c => c.PublicacaoId == id )
                .Join(_dbContext.Usuario,
                      comentario => comentario.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (comentario, usuario) => new ComentarioCompleto
                      {
                          ComentarioId = comentario.ComentarioId,
                          ComentarioTexto = comentario.ComentarioTexto,
                          PublicacaoId = comentario.PublicacaoId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome = usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
                      }).ToListAsync();

            return comentarios;
        }

        public async Task<ComentarioCompleto> GetComentario(int id)
        {
            ComentarioCompleto comentario =  await _dbContext.Comentario
                .Join(_dbContext.Usuario,
                      comentario => comentario.UsuarioId,
                      usuario => usuario.UsuarioId,
                      (comentario, usuario) => new ComentarioCompleto
                      {
                          ComentarioId = comentario.ComentarioId,
                          ComentarioTexto = comentario.ComentarioTexto,
                          PublicacaoId = comentario.PublicacaoId,
                          Usuario = new UsuarioResposta
                          {
                              UsuarioId = usuario.UsuarioId,
                              UsuarioNome = usuario.UsuarioNome,
                              UsuarioSobrenome = usuario.UsuarioSobrenome,
                              UsuarioApelido = usuario.UsuarioApelido,
                              UsuarioFoto = usuario.UsuarioFoto
                          }
                      }).FirstOrDefaultAsync(x => x.ComentarioId == id);

            return comentario;
        }

        public async Task<ComentariosModel> GetById(int id)
        {
            return await _dbContext.Comentario.FirstOrDefaultAsync(x => x.ComentarioId == id);
        }

        public async Task<ComentariosModel> InsertComentario(ComentariosModel comentario)
        {
            await _dbContext.Comentario.AddAsync(comentario);
            await _dbContext.SaveChangesAsync();
            return comentario;
        }

        public async Task<ComentariosModel> UpdateComentario(ComentariosModel comentario, int id)
        {
            ComentariosModel comentarios = await GetById(id);
            if (comentarios == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                comentarios.ComentarioTexto = comentario.ComentarioTexto;
                comentarios.UsuarioId = comentario.UsuarioId;
                comentarios.PublicacaoId = comentario.PublicacaoId;
                _dbContext.Comentario.Update(comentarios);
                await _dbContext.SaveChangesAsync();
            }
            return comentarios;

        }

        public async Task<bool> DeleteComentario(int id)
        {
            ComentariosModel comentarios = await GetById(id);
            if (comentarios == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.Comentario.Remove(comentarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
