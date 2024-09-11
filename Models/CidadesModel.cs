namespace ComuniQApi.Models
{
    public class CidadesModel
    {
        public int CidadeId { get; set; }
        public string CidadeNome { get; set; } = string.Empty;

        public static implicit operator List<object>(CidadesModel v)
        {
            throw new NotImplementedException();
        }
    }
}
