namespace ComuniQApi.Models
{
    public class TipoCampanhasModel
    {
        public int TipoCampanhaId { get; set; }
        public string TipoCampanhaNome { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoCampanhasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
