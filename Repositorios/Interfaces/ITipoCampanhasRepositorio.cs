using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ITipoCampanhasRepositorio
    {
        Task<List<TipoCampanhasModel>> GetAll();

        Task<TipoCampanhasModel> GetById(int id);

        Task<TipoCampanhasModel> InsertTipoCampanha(TipoCampanhasModel tipocampanha);

        Task<TipoCampanhasModel> UpdateTipoCampanha(UsuariosModel tipocampanha, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
