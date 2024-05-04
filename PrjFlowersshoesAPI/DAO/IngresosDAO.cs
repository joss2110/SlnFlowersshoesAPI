using PrjFlowersshoesAPI.Models;
using System.Data.SqlClient;

namespace PrjFlowersshoesAPI.DAO
{
    public class IngresosDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public IngresosDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<Ingresos> GetIngresos()
        {
            var list = new List<Ingresos>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_INGRESOS");
            while (rd.Read())
            {
                list.Add(new Ingresos()
                {
                    idingre = rd.GetInt32(0),
                    fecha = rd.GetDateTime(1),
                    descripcion = rd.GetString(2),
                    nombres = rd.GetString(3),
                    estado = rd.GetString(4)
                });
            }

            rd.Close();

            return list;
        }



        public string GrabarIngresos(Ingresos obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@fecha", obj.fecha));
            parametros.Add(new KeyValuePair<string, object>("@descripcion", obj.descripcion));
            parametros.Add(new KeyValuePair<string, object>("@idtra", obj.idtra));
            parametros.Add(new KeyValuePair<string, object>("@idpro", obj.idpro));
            parametros.Add(new KeyValuePair<string, object>("@cantidad", obj.cantidad));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_GRABAR_INGRESOS", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string EliminarIngresos(Ingresos obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idingre", obj.idingre));
            parametros.Add(new KeyValuePair<string, object>("@idpro", obj.idpro));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_ELIMINAR_INGRESOS", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

    }
}
