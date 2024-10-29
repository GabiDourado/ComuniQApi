namespace ComuniQApi.Models
{
    public class DenunciasModel
    {
        public int DenunciaId { get; set; }
        public string DenunciaTitulo { get; set; } = string.Empty;
        public string? DenunciaMidia { get; set; } = string.Empty;
        public string DenunciaDescricao { get; set; } = string.Empty;
        public int TipoDenunciaId { get; set; }
        public int BairroId { get; set; }

        public static implicit operator List<object>(DenunciasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
