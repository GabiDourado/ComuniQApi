using ComuniQApi.Models;
using ComuniQApi.Repositorios;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairrosController : ControllerBase
    {
        private readonly IBairrosRepositorio _bairrosRepositorio;
        public BairrosController(IBairrosRepositorio bairrosRepositorio)
        {
            _bairrosRepositorio = bairrosRepositorio;
        }

        [HttpGet("GetAllBairros")]
        public async Task<ActionResult<List<BairrosModel>>> GetAllBairros()
        {
            List<BairrosModel> bairros = await _bairrosRepositorio.GetAll();
            return Ok(bairros);
        }

        [HttpGet("GetBairroId/{id}")]
        public async Task<ActionResult<BairrosModel>> GetBairroId(int id)
        {
            BairrosModel bairro = await _bairrosRepositorio.GetById(id);
            return Ok(bairro);
        }

        [HttpPost("InsertBairro")]
        public async Task<ActionResult<BairrosModel>> InsertBairro([FromBody] BairrosModel bairroModel)
        {
            BairrosModel bairro = await _bairrosRepositorio.InsertBairro (bairroModel);
            return Ok(bairro);
        }

        [HttpPut("UpdateBairro/{id:int}")]
        public async Task<ActionResult<BairrosModel>> UpdateBairro(int id, [FromBody] BairrosModel bairroModel)
        {
            bairroModel.BairroId = id;
            BairrosModel bairro = await _bairrosRepositorio.UpdateBairro (bairroModel, id);
            return Ok(bairro);
        }

        [HttpDelete("DeleteBairro/{id:int}")]
        public async Task<ActionResult<BairrosModel>> DeleteBairros(int id)
        {
            bool deleted = await _bairrosRepositorio.DeleteBairros(id);
            return Ok(deleted);
        }
    }
}
