namespace ComuniQApi.Models
{
    public class ComentariosModel
    {
        public int ComentarioId { get; set; }
        public string ComentarioTexto { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public int PublicacaoId { get; set; }

        public static implicit operator List<object>(ComentariosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
