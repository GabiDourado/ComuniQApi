using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoUsuariosController : ControllerBase
    {
        private readonly IPublicacaoUsuariosRepositorio _publicacaoUsuariosRepositorio;
        public PublicacaoUsuariosController(IPublicacaoUsuariosRepositorio publicacaoUsuariosRepositorio)
        {
            _publicacaoUsuariosRepositorio = publicacaoUsuariosRepositorio;
        }

        [HttpGet("GetAllPublicacaoUsuarios")]
        public async Task<ActionResult<List<PublicacaoUsuariosModel>>> GetAllPublicacaoUsuarios()
        {
            List<PublicacaoUsuariosModel> publicacaoUsuarios = await _publicacaoUsuariosRepositorio.GetAll();
            return Ok(publicacaoUsuarios);
        }

        [HttpGet("GetPublicacaoUsuarioId/{id}")]
        public async Task<ActionResult<PublicacaoUsuariosModel>> GetPublicacaoUsuarioId(int id)
        {
            PublicacaoUsuariosModel publicacaoUsuario = await _publicacaoUsuariosRepositorio.GetById(id);
            return Ok(publicacaoUsuario);
        }

        [HttpPost("InsertPublicacaoUsuario")]
        public async Task<ActionResult<PublicacaoUsuariosModel>> InsertPublicacaoUsuario([FromBody] PublicacaoUsuariosModel publicacaoUsuarioModel)
        {
            PublicacaoUsuariosModel publicacaoUsuario = await _publicacaoUsuariosRepositorio.InsertPublicacaoUsuario(publicacaoUsuarioModel);
            return Ok(publicacaoUsuario);
        }

        [HttpPut("UpdatePublicacaoUsuario/{id:int}")]
        public async Task<ActionResult<PublicacaoUsuariosModel>> UpdatePublicacaoUsuario(int id, [FromBody] PublicacaoUsuariosModel publicacaoUsuarioModel)
        {
            publicacaoUsuarioModel.PublicacaoUsuarioId = id;
            PublicacaoUsuariosModel publicacaoUsuario = await _publicacaoUsuariosRepositorio.UpdatePublicacaoUsuario(publicacaoUsuarioModel, id);
            return Ok(publicacaoUsuario);
        }

        [HttpDelete("DeletePublicacaoUsuario/{id:int}")]
        public async Task<ActionResult<PublicacaoUsuariosModel>> DeletePublicacaoUsuarios(int id)
        {
            bool deleted = await _publicacaoUsuariosRepositorio.DeletePublicacaoUsuarios(id);
            return Ok(deleted);
        }
    }
}
