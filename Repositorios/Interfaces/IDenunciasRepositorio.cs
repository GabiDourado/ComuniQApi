using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IDenunciasRepositorio
    {
        Task<List<DenunciasModel>> GetAll();

        Task<DenunciasModel> GetById(int id);

        Task<DenunciasModel> InsertDenuncia(DenunciasModel denuncia);

        Task<DenunciasModel> UpdateDenuncia(DenunciasModel denuncia, int id);

        Task<bool> DeleteDenuncia(int id);
    }
}
