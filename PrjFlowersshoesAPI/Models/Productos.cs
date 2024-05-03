namespace PrjFlowersshoesAPI.Models
{
    public class Productos
    {
        public int idpro { get; set; }
        public string codbar { get; set; } = String.Empty;
        public string imagen { get; set; } = String.Empty;
        public string nompro { get; set; } = String.Empty;
        public decimal precio { get; set; }
        public int idtalla { get; set; }
        public int idcolor { get; set; }
        public string categoria { get; set; } = String.Empty;
        public string temporada { get; set; } = String.Empty; 
        public string descripcion { get; set; } = String.Empty;
        public string estado { get; set; } = String.Empty;
    }
}
