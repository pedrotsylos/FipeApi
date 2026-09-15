namespace FipeApi.Models
{
    public class ValorFIPE
    {
        public string Valor { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; } = string.Empty;
        public string CodigoFipe { get; set; } = string.Empty;
        public string MesReferencia { get; set; } = string.Empty;
        public string Autenticacao { get; set; } = string.Empty;
        public int TipoVeiculo { get; set; }
        public string SiglaCombustivel { get; set; } = string.Empty;
        public string DataConsulta { get; set; } = string.Empty;
    }
}
