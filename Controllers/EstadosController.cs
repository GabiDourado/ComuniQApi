using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosRepositorio _estadosRepositorio;
        public EstadosController(IEstadosRepositorio estadosRepositorio)
        {
            _estadosRepositorio = estadosRepositorio;
        }

        [HttpGet("GetAllEstados")]
        public async Task<ActionResult<List<EstadosModel>>> GetAllEstados()
        {
            List<EstadosModel> estados = await _estadosRepositorio.GetAll();
            return Ok(estados);
        }

        [HttpGet("GetEstadoId/{id}")]
        public async Task<ActionResult<EstadosModel>> GetEstadoId(int id)
        {
            EstadosModel estado = await _estadosRepositorio.GetById(id);
            return Ok(estado);
        }

        [HttpPost("InsertEstado")]
        public async Task<ActionResult<EstadosModel>> InsertEstado([FromBody] EstadosModel estadoModel)
        {
            EstadosModel estado = await _estadosRepositorio.InsertEstado(estadoModel);
            return Ok(estado);
        }

        [HttpPut("UpdateEstado/{id:int}")]
        public async Task<ActionResult<EstadosModel>> UpdateEstado(int id, [FromBody] EstadosModel estadoModel)
        {
            estadoModel.EstadoId = id;
            EstadosModel estado = await _estadosRepositorio.UpdateEstado(estadoModel, id);
            return Ok(estado);
        }

        [HttpDelete("DeleteEstado/{id:int}")]
        public async Task<ActionResult<EstadosModel>> DeleteEstado(int id)
        {
            bool deleted = await _estadosRepositorio.DeleteEstado(id);
            return Ok(deleted);
        }
    }
}
