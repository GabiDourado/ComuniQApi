namespace ComuniQApi.Models
{
    public class UsuariosModel
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioSobrenome { get; set; } = string.Empty;

        public string UsuarioApelido { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public int UsuarioTelefone { get; set; }

        public string UsuarioCPF { get; set; } = string.Empty;

        public int UsuarioCEP { get; set; }

        public string UsuarioCidade { get; set; } = string.Empty;

        public string UssuarioBairro { get; set; } = string.Empty;

        public string UsuarioEstado { get; set; } = string.Empty;

        public string UsuarioSenha { get; set; } = string.Empty;

        public byte[]? UsuarioFoto { get; set; }

        public int TipoPerfilId { get; set; }

        public static implicit operator List<object>(UsuariosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
