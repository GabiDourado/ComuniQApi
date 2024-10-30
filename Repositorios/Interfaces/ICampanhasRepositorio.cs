using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ICampanhasRepositorio
    {
        Task<List<CampanhaCompleta>> GetAll();

        Task<CampanhaCompleta> GetCampanha(int id);

        Task<CampanhasModel> GetById(int id);

        Task<CampanhasModel> InsertCampanha(CampanhasModel campanha);

        Task<CampanhasModel> UpdateCampanha(CampanhasModel campanha, int id);

        Task<bool> DeleteCampanha(int id);
    }
}
