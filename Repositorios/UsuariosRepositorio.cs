using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuariosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuariosModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuariosModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuariosModel> InsertUsuario(UsuariosModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Login(string email, string password)
        {

            var result = await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioEmail == email && x.UsuarioSenha == password);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<UsuariosModel> UpdateUsuario(UsuariosModel usuario, int id)
        {
            UsuariosModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarios.UsuarioNome = usuario.UsuarioNome;
                usuarios.UsuarioSobrenome = usuario.UsuarioSobrenome;
                usuarios.UsuarioApelido = usuario.UsuarioApelido;
                usuarios.UsuarioEmail = usuario.UsuarioEmail;
                usuarios.UsuarioTelefone = usuario.UsuarioTelefone;
                usuarios.UsuarioCPF = usuario.UsuarioCPF;
                usuarios.UsuarioCEP = usuario.UsuarioCEP;
                usuarios.UsuarioCidade = usuario.UsuarioCidade;
                usuarios.UssuarioBairro = usuario.UssuarioBairro;
                usuarios.UsuarioEstado = usuario.UsuarioEstado;
                usuarios.UsuarioSenha = usuario.UsuarioSenha;
                _dbContext.Usuario.Update(usuarios);
                await _dbContext.SaveChangesAsync();
            }
            return usuarios;

        } 

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuariosModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
