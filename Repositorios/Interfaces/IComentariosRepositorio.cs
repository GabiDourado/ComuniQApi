using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IComentariosRepositorio
    {
        Task<List<ComentarioCompleto>> GetAll();

        Task<ComentarioCompleto> GetComentario(int id);

        Task<ComentariosModel> GetById(int id);

        Task<ComentariosModel> InsertComentario(ComentariosModel comentario);

        Task<ComentariosModel> UpdateComentario(ComentariosModel comentario, int id);

        Task<bool> DeleteComentario(int id);
    }
}
