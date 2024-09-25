namespace ComuniQApi.Models
{
    public class TipoPerfisModel
    {
        public int TipoPerfilId { get; set; }
        public string TipoPerfilNome { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoPerfisModel v)
        {
            throw new NotImplementedException();
        }
    }
}
