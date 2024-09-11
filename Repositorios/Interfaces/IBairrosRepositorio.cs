using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IBairrosRepositorio
    {
        Task<List<BairrosModel>> GetAll();

        Task<BairrosModel> GetById(int id);

        Task<BairrosModel> InsertBairro(BairrosModel bairro);

        Task<BairrosModel> UpdateBairro(BairrosModel bairro, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
