using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ITipoPerfisRepositorio
    {
        Task<List<TipoPerfisModel>> GetAll();

        Task<TipoPerfisModel> GetById(int id);

        Task<TipoPerfisModel> InsertTipoPerfil(TipoPerfisModel tipoPerfil);

        Task<TipoPerfisModel> UpdateTipoPerfil(TipoPerfisModel tipoPerfil, int id);

        Task<bool> DeleteTipoPerfil(int id);
    }
}
