using ComuniQApi.Models;
using ComuniQApi.Repositorios;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCampanhasController : ControllerBase
    {
        private readonly ITipoCampanhasRepositorio _tipoCampanhasRepositorio;
        public TipoCampanhasController(ITipoCampanhasRepositorio tipoCampanhasRepositorio)
        {
            _tipoCampanhasRepositorio = tipoCampanhasRepositorio;
        }

        [HttpGet("GetAllTipoCampanhas")]
        public async Task<ActionResult<List<TipoCampanhasModel>>> GetAllTipoCampanhas()
        {
            List<TipoCampanhasModel> tipoCampanhas = await _tipoCampanhasRepositorio.GetAll();
            return Ok(tipoCampanhas);
        }

        [HttpGet("GetTipoCampanhaId/{id}")]
        public async Task<ActionResult<TipoCampanhasModel>> GetTipoCampanhaId(int id)
        {
            TipoCampanhasModel tipoCampanha = await _tipoCampanhasRepositorio.GetById(id);
            return Ok(tipoCampanha);
        }

        [HttpPost("InsertTipoCampanha")]
        public async Task<ActionResult<TipoCampanhasModel>> InsertTipoCampanha([FromBody] TipoCampanhasModel tipoCampanhaModel)
        {
            TipoCampanhasModel tipoCampanha = await _tipoCampanhasRepositorio.InsertTipoCampanha(tipoCampanhaModel);
            return Ok(tipoCampanha);
        }

        [HttpPut("UpdateTipoCampanha/{id:int}")]
        public async Task<ActionResult<TipoCampanhasModel>> UpdateTipoCampanha(int id, [FromBody] TipoCampanhasModel tipoCampanhaModel)
        {
            tipoCampanhaModel.TipoCampanhaId = id;
            TipoCampanhasModel tipoCampanha = await _tipoCampanhasRepositorio.UpdateTipoCampanha(tipoCampanhaModel, id);
            return Ok(tipoCampanha);
        }


        [HttpDelete("DeleteTipoCampanha/{id:int}")]
        public async Task<ActionResult<TipoCampanhasModel>> DeleteTipoCampanha(int id)
        {
            bool deleted = await _tipoCampanhasRepositorio.DeleteTipoCampanha(id);
            return Ok(deleted);
        }
    }
}
