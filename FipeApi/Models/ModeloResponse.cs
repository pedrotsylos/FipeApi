namespace FipeApi.Models
{
    public class ModeloResponse
    {
        public List<Modelo> Modelos { get; set; } = new();
        public List<Ano> Anos { get; set; } = new();
    }
}
