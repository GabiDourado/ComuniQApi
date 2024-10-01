using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<List<UsuariosModel>> GetAll();

        Task<UsuariosModel> GetById(int id);

        Task<UsuariosModel> InsertUsuario(UsuariosModel usuario);

        Task<UsuariosModel> Login(string email, string password);

        Task<UsuariosModel> UpdateUsuario(UsuariosModel usuario, int id);
        Task<UsuariosModel> RecuperarSenha(string email, string novaSenha);

        Task<bool> DeleteUsuario(int id);
    }
}
