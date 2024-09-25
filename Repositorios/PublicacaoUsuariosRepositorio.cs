using ComuniQApi.Data;
using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComuniQApi.Repositorios
{
    public class PublicacaoUsuariosRepositorio : IPublicacaoUsuariosRepositorio
    {
        private readonly Contexto _dbContext;

        public PublicacaoUsuariosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PublicacaoUsuariosModel>> GetAll()
        {
            return await _dbContext.PublicacaoUsuario.ToListAsync();
        }

        public async Task<PublicacaoUsuariosModel> GetById(int id)
        {
            return await _dbContext.PublicacaoUsuario.FirstOrDefaultAsync(x => x.PublicacaoUsuarioId == id);
        }

        public async Task<PublicacaoUsuariosModel> InsertPublicacaoUsuario(PublicacaoUsuariosModel publicacaoUsuario)
        {
            await _dbContext.PublicacaoUsuario.AddAsync(publicacaoUsuario);
            await _dbContext.SaveChangesAsync();
            return publicacaoUsuario;
        }

        public async Task<PublicacaoUsuariosModel> UpdatePublicacaoUsuario(PublicacaoUsuariosModel publicacaoUsuario, int id)
        {
            PublicacaoUsuariosModel publicacaoUsuarios = await GetById(id);
            if (publicacaoUsuarios == null)
            {
                throw new Exception("Não encontrada.");
            }
            else
            {
                publicacaoUsuarios.UsuarioId = publicacaoUsuario.UsuarioId;
                publicacaoUsuarios.PublicacaoId = publicacaoUsuario.PublicacaoId;
                _dbContext.PublicacaoUsuario.Update(publicacaoUsuarios);
                await _dbContext.SaveChangesAsync();
            }
            return publicacaoUsuarios;

        }

        public async Task<bool> DeletePublicacaoUsuarios(int id)
        {
            PublicacaoUsuariosModel publicacaoUsuarios = await GetById(id);
            if (publicacaoUsuarios == null)
            {
                throw new Exception("Não encontrada.");
            }

            _dbContext.PublicacaoUsuario.Remove(publicacaoUsuarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
