namespace ComuniQApi.Models
{
    public class EstadosModel
    {
        public int EstadoId { get; set; }
        public string EstadoNome { get; set; } = string.Empty;

        public static implicit operator List<object>(EstadosModel v)
        {
            throw new NotImplementedException();
        }
    }
    
}
