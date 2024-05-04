namespace PrjFlowersshoesAPI.Models
{
    public class Productos
    {
        public int idpro { get; set; }
        public string codbar { get; set; } = string.Empty;
        public string imagen { get; set; } = string.Empty;
        public string nompro { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int idtalla { get; set; }
        public int idcolor { get; set; }
        public string categoria { get; set; } = string.Empty;
        public string temporada { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
    }
}
