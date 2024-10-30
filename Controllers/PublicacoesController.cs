using ComuniQApi.Models;
using ComuniQApi.Repositorios;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacoesController : ControllerBase
    {
        private readonly IPublicacoesRepositorio _publicacoesRepositorio;
        public PublicacoesController(IPublicacoesRepositorio publicacoesRepositorio)
        {
            _publicacoesRepositorio = publicacoesRepositorio;
        }

        [HttpGet("GetAllPublicacoes")]
        public async Task<ActionResult<List<PublicacaoCompleta>>> GetAllPublicacoes()
        {
            List<PublicacaoCompleta> publicacoes = await _publicacoesRepositorio.GetAll();
            return Ok(publicacoes);
        }

        [HttpGet("GetPublicacaoId/{id}")]
        public async Task<ActionResult<PublicacaoCompleta>> GetPublicacao(int id)
        {
            PublicacaoCompleta publicacao = await _publicacoesRepositorio.GetPublicacao(id);
            return Ok(publicacao);
        }


        [HttpPost("InsertPublicacao")]
        public async Task<ActionResult<PublicacoesModel>> InsertPublicacao([FromBody] PublicacoesModel publicacaoModel)
        {
            PublicacoesModel publicacao = await _publicacoesRepositorio.InsertPublicacao(publicacaoModel);
            return Ok(publicacao);
        }

        [HttpPut("UpdatePublicacao/{id:int}")]
        public async Task<ActionResult<PublicacoesModel>> UpdatePublicacao(int id, [FromBody] PublicacoesModel publicacaoModel)
        {
            publicacaoModel.PublicacaoId = id;
            PublicacoesModel publicacao = await _publicacoesRepositorio.UpdatePublicacao(publicacaoModel, id);
            return Ok(publicacao);
        }

        [HttpDelete("DeletePublicacao/{id:int}")]
        public async Task<ActionResult<PublicacoesModel>> DeletePublicacao(int id)
        {
            bool deleted = await _publicacoesRepositorio.DeletePublicacao(id);
            return Ok(deleted);
        }
    }
}
