namespace ComuniQApi.Models
{
    public class TipoDenunciasModel
    {
        public int TipoDenunciaId { get; set; }

        public string TipoDenunciaNome { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoDenunciasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
