namespace ComuniQApi.Models
{
    public class ComentarioCompleto
    {
        public int ComentarioId { get; set; }
        public string ComentarioTexto { get; set; } = string.Empty;
        public int PublicacaoId { get; set; }

        public UsuarioResposta Usuario { get; set; }
    }
}
