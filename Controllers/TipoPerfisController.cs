using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPerfisController : ControllerBase
    {
        private readonly ITipoPerfisRepositorio _tipoPerfisRepositorio;
        public TipoPerfisController(ITipoPerfisRepositorio tipoPerfisRepositorio)
        {
            _tipoPerfisRepositorio = tipoPerfisRepositorio;
        }

        [HttpGet("GetAllTipoPerfis")]
        public async Task<ActionResult<List<TipoPerfisModel>>> GetAllTipoPerfis()
        {
            List<TipoPerfisModel> tipoPerfis = await _tipoPerfisRepositorio.GetAll();
            return Ok(tipoPerfis);
        }

        [HttpGet("GetTipoPerfilId/{id}")]
        public async Task<ActionResult<TipoPerfisModel>> GetTipoPerfilId(int id)
        {
            TipoPerfisModel tipoPerfil = await _tipoPerfisRepositorio.GetById(id);
            return Ok(tipoPerfil);
        }

        [HttpPost("InsertTipoPerfil")]
        public async Task<ActionResult<TipoPerfisModel>> InsertTipoPerfil([FromBody] TipoPerfisModel tipoPerfilModel)
        {
            TipoPerfisModel tipoPerfil = await _tipoPerfisRepositorio.InsertTipoPerfil(tipoPerfilModel);
            return Ok(tipoPerfil);
        }

        [HttpPut("UpdateTipoPerfil/{id:int}")]
        public async Task<ActionResult<TipoPerfisModel>> UpdateTipoPerfil(int id, [FromBody] TipoPerfisModel tipoPerfilModel)
        {
            tipoPerfilModel.TipoPerfilId = id;
            TipoPerfisModel tipoPerfil = await _tipoPerfisRepositorio.UpdateTipoPerfil(tipoPerfilModel, id);
            return Ok(tipoPerfil);
        }


        [HttpDelete("DeleteTipoPerfil/{id:int}")]
        public async Task<ActionResult<TipoPerfisModel>> DeleteTipoPerfil(int id)
        {
            bool deleted = await _tipoPerfisRepositorio.DeleteTipoPerfil(id);
            return Ok(deleted);
        }
    }
}

