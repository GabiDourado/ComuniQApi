﻿namespace ComuniQApi.Models
{
    public class UsuariosModel
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioSobrenome { get; set; } = string.Empty;

        public string UsuarioApelido { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string UsuarioTelefone { get; set; } = string.Empty;

        public string UsuarioCPF { get; set; } = string.Empty;

        public string UsuarioCEP { get; set; } = string.Empty;

        public string UsuarioCidade { get; set; } = string.Empty;

        public string UsuarioBairro { get; set; } = string.Empty;

        public string UsuarioEstado { get; set; } = string.Empty;

        public string UsuarioSenha { get; set; } = string.Empty;

        public string? UsuarioFoto { get; set; } = string.Empty;

        public int TipoPerfilId { get; set; }

        public static implicit operator List<object>(UsuariosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
