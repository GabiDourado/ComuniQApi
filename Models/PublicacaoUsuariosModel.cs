namespace ComuniQApi.Models
{
    public class PublicacaoUsuariosModel
    {
        public int PublicacaoUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int PublicacaoId { get; set; }

        public static implicit operator List<object>(PublicacaoUsuariosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
