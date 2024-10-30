using ComuniQApi.Models;
using ComuniQApi.Repositorios;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhasController : ControllerBase
    {
        private readonly ICampanhasRepositorio _campanhasRepositorio;
        public CampanhasController(ICampanhasRepositorio campanhasRepositorio)
        {
            _campanhasRepositorio = campanhasRepositorio;
        }

        [HttpGet("GetAllCampanhas")]
        public async Task<ActionResult<List<CampanhaCompleta>>> GetAllCampanhas()
        {
            List<CampanhaCompleta> campanhas = await _campanhasRepositorio.GetAll();
            return Ok(campanhas);
        }

        [HttpGet("GetCampanhaId/{id}")]
        public async Task<ActionResult<CampanhaCompleta>> GetCampanha(int id)
        {
            CampanhaCompleta campanha = await _campanhasRepositorio.GetCampanha(id);
            return Ok(campanha);
        }

        [HttpPost("InsertCampanha")]
        public async Task<ActionResult<CampanhasModel>> InsertCampanha([FromBody] CampanhasModel campanhaModel)
        {
            CampanhasModel campanha = await _campanhasRepositorio.InsertCampanha(campanhaModel);
            return Ok(campanha);
        }


        [HttpPut("UpdateCampanha/{id:int}")]
        public async Task<ActionResult<CampanhasModel>> UpdateCampanha(int id, [FromBody] CampanhasModel campanhaModel)
        {
            campanhaModel.CampanhaId = id;
            CampanhasModel campanha = await _campanhasRepositorio.UpdateCampanha(campanhaModel, id);
            return Ok(campanha);
        }

        [HttpDelete("DeleteCampanha/{id:int}")]
        public async Task<ActionResult<CampanhasModel>> DeleteCampanha(int id)
        {
            bool deleted = await _campanhasRepositorio.DeleteCampanha(id);
            return Ok(deleted);
        }
    }

} 
