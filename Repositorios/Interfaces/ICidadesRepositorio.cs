using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ICidadesRepositorio
    {
        Task<List<CidadesModel>> GetAll();

        Task<CidadesModel> GetById(int id);

        Task<CidadesModel> InsertCidade(CidadesModel cidade);

        Task<CidadesModel> UpdateCidade(CidadesModel cidade, int id);

        Task<bool> DeleteCidade(int id);
    }
}
