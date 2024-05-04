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

        public List<PA_LISTAR_INGRESOS> GetIngresos()
        {
            var list = new List<PA_LISTAR_INGRESOS>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_INGRESOS");
            while (rd.Read())
            {
                list.Add(new PA_LISTAR_INGRESOS()
                {
                    idingre = rd.GetInt32(0),
                    fecha = rd.GetDateTime(1),
                    descripcion = rd.GetString(2),
                    estado = rd.GetString(3),
                    nombres = rd.GetString(4)
                });
            }

            rd.Close();

            return list;
        }

        public string GrabarIngresos(Ingresos obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(
                cad_sql, "PA_GRABAR_INGRESOS",
                obj.fecha, obj.descripcion, obj.idtra);
                //
                mensaje = $"Ingreso agregado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string EliminarIngresos(int idingre)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_ELIMINAR_INGRESOS", idingre);
                mensaje = $"Ingreso eliminado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string RestaurarIngresos(int idingre)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_RESTAURAR_INGRESOS", idingre);
                mensaje = $"Ingreso restaurado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

    }
}
