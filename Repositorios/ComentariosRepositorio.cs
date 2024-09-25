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

        public async Task<List<ComentariosModel>> GetAll()
        {
            return await _dbContext.Comentario.ToListAsync();
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
