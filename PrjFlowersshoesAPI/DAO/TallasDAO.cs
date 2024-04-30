using PrjFlowersshoesAPI.Models;
using System.Data.SqlClient;

namespace PrjFlowersshoesAPI.DAO
{
    public class TallasDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public TallasDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<Tallas> GetTallas()
        {
            var list = new List<Tallas>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_TALLAS");
            while (rd.Read())
            {
                list.Add(new Tallas()
                {
                    idtalla = rd.GetInt32(0),
                    talla = rd.GetString(1)
                });
            }

            rd.Close();

            return list;
        }

    }
}
