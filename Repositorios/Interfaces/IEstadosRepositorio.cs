using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IEstadosRepositorio
    {
        Task<List<EstadosModel>> GetAll();

        Task<EstadosModel> GetById(int id);

        Task<EstadosModel> InsertEstado(EstadosModel estado);

        Task<EstadosModel> UpdateEstado(EstadosModel estado, int id);

        Task<bool> DeleteEstado(int id);
    }
}
