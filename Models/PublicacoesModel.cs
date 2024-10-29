namespace ComuniQApi.Models
{
    public class PublicacoesModel
    {
        public int PublicacaoId { get; set; }

        public string PublicacaoTitulo { get; set; } = string.Empty;

        public string? PublicacaoMidia { get; set; } = string.Empty;

        public string PublicacaoDescricao { get; set; } = string.Empty;

        public int BairroId { get; set; }

              public static implicit operator List<object>(PublicacoesModel v)
        {
            throw new NotImplementedException();
        }
    }
}
