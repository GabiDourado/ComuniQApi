namespace ComuniQApi.Models
{
    public class PublicacaoCompleta
    {
        public int PublicacaoId { get; set; }

        public string PublicacaoTitulo { get; set; } = string.Empty;

        public string? PublicacaoMidia { get; set; } = string.Empty;

        public string PublicacaoDescricao { get; set; } = string.Empty;

        public int BairroId { get; set; }

        public UsuarioResposta Usuario { get; set; }

        public static implicit operator List<object>(PublicacaoCompleta? v)
        {
            throw new NotImplementedException();
        }
    }
}
