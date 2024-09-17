using ComuniQApi.Models;
using ComuniQApi.Repositorios;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadesRepositorio _cidadesRepositorio;
        public CidadesController(ICidadesRepositorio cidadesRepositorio)
        {
            _cidadesRepositorio = cidadesRepositorio;
        }
        [HttpGet("GetAllCidades")]
        public async Task<ActionResult<List<CidadesModel>>> GetAllCidades()
        {
            List<CidadesModel> cidades = await _cidadesRepositorio.GetAll();
            return Ok(cidades);
        }
        [HttpGet("GetCidadeId/{id}")]
        public async Task<ActionResult<CidadesModel>> GetCidadeId(int id)
        {
            CidadesModel cidade = await _cidadesRepositorio.GetById(id);
            return Ok(cidade);
        }
        [HttpPost("InsertCidade")]
        public async Task<ActionResult<CidadesModel>> InsertCidade([FromBody] CidadesModel cidadeModel)
        {
            CidadesModel cidade = await _cidadesRepositorio.InsertCidade(cidadeModel);
            return Ok(cidade);
        }
        [HttpPut("UpdateCidade/{id:int}")]
        public async Task<ActionResult<CidadesModel>> UpdateCidade(int id, [FromBody] CidadesModel cidadeModel)
        {
            cidadeModel.CidadeId = id;
            CidadesModel cidade = await _cidadesRepositorio.UpdateCidade(cidadeModel, id);
            return Ok(cidade);
        }
        [HttpDelete("DeleteCidade/{id:int}")]
        public async Task<ActionResult<CidadesModel>> DeleteCidade(int id)
        {
            bool deleted = await _cidadesRepositorio.DeleteCidade(id);
            return Ok(deleted);
        }


    }
}
