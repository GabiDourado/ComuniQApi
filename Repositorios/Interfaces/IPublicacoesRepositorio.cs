using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IPublicacoesRepositorio
    {
        Task<List<PublicacoesModel>> GetAll();

        Task<PublicacoesModel> GetById(int id);

        Task<PublicacoesModel> InsertPublicacao(PublicacoesModel publicacao);

        Task<PublicacoesModel> UpdatePublicacao(PublicacoesModel publicacao, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
