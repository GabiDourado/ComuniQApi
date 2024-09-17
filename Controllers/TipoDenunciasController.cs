using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    public class TipoDenunciasController : ControllerBase
    {
        private readonly ITipoDenunciasRepositorio _tipoDenunciasRepositorio;
        public TipoDenunciasController(ITipoDenunciasRepositorio tipoDenunciasRepositorio)
        {
            _tipoDenunciasRepositorio = tipoDenunciasRepositorio;
        }
        [HttpGet("GetAllTipoDenuncias")]
        public async Task<ActionResult<List<TipoDenunciasModel>>> GetAllTipoDenuncias()
        {
            List<TipoDenunciasModel> tipoDenuncias = await _tipoDenunciasRepositorio.GetAll();
            return Ok(tipoDenuncias);
        }
        [HttpGet("GetTipoDenunciaId/{id}")]
        public async Task<ActionResult<TipoDenunciasModel>> GetTipoDenunciaId(int id)
        {
            TipoDenunciasModel tipoDenuncia = await _tipoDenunciasRepositorio.GetById(id);
            return Ok(tipoDenuncia);
        }
        [HttpPost("InsertTipoDenuncia")]
        public async Task<ActionResult<TipoDenunciasModel>> InsertTipoDenuncia([FromBody] TipoDenunciasModel tipoDenunciaModel)
        {
            TipoDenunciasModel tipoDenuncia = await _tipoDenunciasRepositorio.InsertTipoDenuncia(tipoDenunciaModel);
            return Ok(tipoDenuncia);
        }
        [HttpPut("UpdateTipoDenuncia/{id:int}")]
        public async Task<ActionResult<TipoDenunciasModel>> UpdateTipoDenuncia(int id, [FromBody] TipoDenunciasModel tipoDenunciaModel)
        {
            tipoDenunciaModel.TipoDenunciaId = id;
            TipoDenunciasModel tipoDenuncia = await _tipoDenunciasRepositorio.UpdateTipoDenuncia(tipoDenunciaModel, id);
            return Ok(tipoDenuncia);
        }
        [HttpDelete("DeleteTipoDenuncia/{id:int}")]
        public async Task<ActionResult<TipoDenunciasModel>> DeleteTipoDenuncia(int id)
        {
            bool deleted = await _tipoDenunciasRepositorio.DeleteTipoDenuncia(id);
            return Ok(deleted);
        }


    }
}
