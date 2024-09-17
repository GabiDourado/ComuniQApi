﻿using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<List<UsuariosModel>> GetAll();

        Task<UsuariosModel> GetById(int id);

        Task<UsuariosModel> InsertUsuario(UsuariosModel usuario);

        Task<bool> Login(string email, string password);

        Task<UsuariosModel> UpdateUsuario(UsuariosModel usuario, int id);

        Task<bool> DeleteUsuario(int id);
    }
}