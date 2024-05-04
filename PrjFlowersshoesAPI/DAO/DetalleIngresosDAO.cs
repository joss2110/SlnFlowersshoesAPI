using PrjFlowersshoesAPI.Models;
using System.Data.SqlClient;

namespace PrjFlowersshoesAPI.DAO
{
    public class DetalleIngresosDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public DetalleIngresosDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<DetalleIngresos> GetDetalleIngresos()
        {
            var list = new List<DetalleIngresos>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_DETALLE_INGRESOS");
            while (rd.Read())
            {
                list.Add(new DetalleIngresos()
                {
                    idingre = rd.GetInt32(0),
                    cantidad = rd.GetInt32(1),
                    producto = rd.GetString(2),
                    imagen = rd.GetString(3),
                    color = rd.GetString(4),
                    talla = rd.GetString(5)
                });
            }

            rd.Close();

            return list;
        }
    }
}
