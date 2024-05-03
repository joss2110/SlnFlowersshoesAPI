using System.Data.SqlClient;
using PrjFlowersshoesAPI.Models;

namespace FlowersshoesCoreMVC.DAO
{
    public class StocksDAO
    {

        private string cad_sql = "";
        public StocksDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_STOCKS> getStocks()
        {
            var lista = new List<PA_LISTAR_STOCKS>();

            SqlDataReader dr =
              SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_STOCKS");

            while (dr.Read())
            {
                lista.Add(
                  new PA_LISTAR_STOCKS()
                  {
                      idstock = dr.GetInt32(0),
                      nompro = dr.GetString(1),
                      imagen = dr.GetString(2),
                      color = dr.GetString(3),
                      talla = dr.GetString(4),
                      cantidad = dr.GetInt32(5),
                  });
            }
            dr.Close();

            return lista;
        }
    }
}
