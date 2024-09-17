using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenunciaController : ControllerBase
    {
        private readonly IDenunciasRepositorio _denunciasRepositorio;
        public DenunciaController(IDenunciasRepositorio denunciasRepositorio)
        {
            _denunciasRepositorio = denunciasRepositorio;
        }
        [HttpGet("GetAllDenuncias")]
        public async Task<ActionResult<List<DenunciasModel>>> GetAllDenuncias()
        {
            List<DenunciasModel> denuncias = await _denunciasRepositorio.GetAll();
            return Ok(denuncias);
        }
        [HttpGet("GetDenunciaId/{id}")]
        public async Task<ActionResult<DenunciasModel>> GetDenunciaId(int id)
        {
            DenunciasModel denuncia = await _denunciasRepositorio.GetById(id);
            return Ok(denuncia);
        }
        [HttpPost("InsertDenuncia")]
        public async Task<ActionResult<DenunciasModel>> InsertDenuncia([FromBody] DenunciasModel denunciaModel)
        {
            DenunciasModel denuncia = await _denunciasRepositorio.InsertDenuncia(denunciaModel);
            return Ok(denuncia);
        }
        [HttpPut("UpdateDenuncia/{id:int}")]
        public async Task<ActionResult<DenunciasModel>> UpdateDenuncia(int id, [FromBody] DenunciasModel denunciaModel)
        {
            denunciaModel.DenunciaId = id;
            DenunciasModel denuncia = await _denunciasRepositorio.UpdateDenuncia(denunciaModel, id);
            return Ok(denuncia);
        }
        [HttpDelete("DeleteDenuncia/{id:int}")]
        public async Task<ActionResult<DenunciasModel>> DeleteDenuncia(int id)
        {
            bool deleted = await _denunciasRepositorio.DeleteDenuncia(id);
            return Ok(deleted);
        }


    }
}
