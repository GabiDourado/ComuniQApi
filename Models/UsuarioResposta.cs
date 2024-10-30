namespace ComuniQApi.Models
{
    public class UsuarioResposta
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioSobrenome { get; set; } = string.Empty;

        public string UsuarioApelido { get; set; } = string.Empty;


        public string? UsuarioFoto { get; set; } = string.Empty;
    }
}
