using ComuniQApi.Models;
using ComuniQApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComuniQApi.Controllers
{
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosRepositorio _comentariosRepositorio;
        public ComentariosController(IComentariosRepositorio comentariosRepositorio)
        {
            _comentariosRepositorio = comentariosRepositorio;
        }
        [HttpGet("GetAllComentarios")]
        public async Task<ActionResult<List<ComentariosModel>>> GetAllComentarios()
        {
            List<ComentariosModel> comentarios = await _comentariosRepositorio.GetAll();
            return Ok(comentarios);
        }
        [HttpGet("GetComentarioId/{id}")]
        public async Task<ActionResult<ComentariosModel>> GetComentarioId(int id)
        {
            ComentariosModel comentario = await _comentariosRepositorio.GetById(id);
            return Ok(comentario);
        }
        [HttpPost("InsertComentario")]
        public async Task<ActionResult<ComentariosModel>> InsertComentario([FromBody] ComentariosModel comentarioModel)
        {
            ComentariosModel comentario = await _comentariosRepositorio.InsertComentario(comentarioModel);
            return Ok(comentario);
        }
        [HttpPut("UpdateComentario/{id:int}")]
        public async Task<ActionResult<ComentariosModel>> UpdateComentario(int id, [FromBody] ComentariosModel comentarioModel)
        {
            comentarioModel.ComentarioId = id;
            ComentariosModel comentario = await _comentariosRepositorio.UpdateComentario(comentarioModel, id);
            return Ok(comentario);
        }
        [HttpDelete("DeleteComentario/{id:int}")]
        public async Task<ActionResult<ComentariosModel>> DeleteComentario(int id)
        {
            bool deleted = await _comentariosRepositorio.DeleteComentario(id);
            return Ok(deleted);
        }


    }
}
