using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IPublicacoesRepositorio
    {
        Task<List<PublicacaoCompleta>> GetAll();

        Task<PublicacaoCompleta> GetPublicacao(int id);

        Task<PublicacoesModel> GetById(int id);

        Task<PublicacoesModel> InsertPublicacao(PublicacoesModel publicacao);

        Task<PublicacoesModel> UpdatePublicacao(PublicacoesModel publicacao, int id);

        Task<bool> DeletePublicacao(int id);
    }
}
