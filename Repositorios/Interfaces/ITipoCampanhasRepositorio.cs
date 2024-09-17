using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ITipoCampanhasRepositorio
    {
        Task<List<TipoCampanhasModel>> GetAll();

        Task<TipoCampanhasModel> GetById(int id);

        Task<TipoCampanhasModel> InsertTipoCampanha(TipoCampanhasModel tipocampanha);

        Task<TipoCampanhasModel> UpdateTipoCampanha(TipoCampanhasModel tipocampanha, int id);

        Task<bool> DeleteTipoCampanha(int id);
    }
}
