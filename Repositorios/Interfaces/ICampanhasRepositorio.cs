﻿using ComuniQApi.Models;

namespace ComuniQApi.Repositorios.Interfaces
{
    public interface ICampanhasRepositorio
    {
        Task<List<CampanhasModel>> GetAll();

        Task<CampanhasModel> GetById(int id);

        Task<CampanhasModel> InsertCampanha(CampanhasModel campanha);

        Task<CampanhasModel> UpdateCampanha(UsuariosModel campanha, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
