using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IPublicacaoUsuariosRepositorio
    {
        Task<List<PublicacaoUsuariosModel>> GetAll();

        Task<PublicacaoUsuariosModel> GetById(int id);

        Task<PublicacaoUsuariosModel> InsertPublicacaoUsuario(PublicacaoUsuariosModel publicacaoUsuario);

        Task<PublicacaoUsuariosModel> UpdatePublicacaoUsuario(PublicacaoUsuariosModel publicacaoUsuario, int id);

        Task<bool> DeletePublicacaoUsuarios(int id);
    }
}
