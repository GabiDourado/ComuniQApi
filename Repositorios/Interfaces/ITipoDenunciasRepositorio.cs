using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ITipoDenunciasRepositorio
    {
        Task<List<TipoDenunciasModel>> GetAll();

        Task<TipoDenunciasModel> GetById(int id);

        Task<TipoDenunciasModel> InsertTipoDenuncia(TipoDenunciasModel tipoDenuncia);

        Task<TipoDenunciasModel> UpdateTipoDenuncia(TipoDenunciasModel tipoDenuncia, int id);

        Task<bool> DeleteTipoDenuncia(int id);
    }
}
