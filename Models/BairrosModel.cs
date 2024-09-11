namespace ComuniQApi.Models
{
    public class BairrosModel
    {
        public int BairroId { get; set; }
        public string BairroNome { get; set; } = string.Empty;
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }

        public static implicit operator List<object>(BairrosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
