namespace ComuniQApi.Models
{
    public class CampanhasModel
    {
        public int CampanhaId { get; set; }

        public string CampanhaTitulo { get; set; } = string.Empty;

        public string? CampanhaMidia { get; set; } = string.Empty;

        public string CampanhaDescricao { get; set; } = string.Empty;

        public int TipoCampanhaId { get; set; }

        public int CidadeId { get; set; }

        public static implicit operator List<object>(CampanhasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
