using PrjFlowersshoesAPI.Models;
using System.Data.SqlClient;

namespace PrjFlowersshoesAPI.DAO
{
    public class TrabajadoresDAO
    {
        private string cad_sql;

        public TrabajadoresDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_TRABAJADORES> getTrabajadores()
        {
            var lista = new List<PA_LISTAR_TRABAJADORES>();
            //
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_TRABAJADORES");
            //
            while (dr.Read())
            {
                lista.Add(new PA_LISTAR_TRABAJADORES()
                {
                    idtra = dr.GetInt32(0),
                    nombres = dr.GetString(1),
                    tipoDocumento = dr.GetString(2),
                    nroDocumento = dr.GetString(3),
                    direccion = dr.GetString(4),
                    email = dr.GetString(5),
                    nomRol = dr.GetString(6),
                    estado = dr.GetString(7)
                });
            }
            dr.Close();
            //
            return lista;
        }

        public string GrabarTrabajador(Trabajadores obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@nombres", obj.nombres));
            parametros.Add(new KeyValuePair<string, object>("@tipoDocumento", obj.tipoDocumento));
            parametros.Add(new KeyValuePair<string, object>("@nroDocumento", obj.nroDocumento));
            parametros.Add(new KeyValuePair<string, object>("@direccion", obj.direccion));
            parametros.Add(new KeyValuePair<string, object>("@email", obj.email));
            parametros.Add(new KeyValuePair<string, object>("@pass", obj.pass));
            parametros.Add(new KeyValuePair<string, object>("@idrol", obj.idrol));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_AGREGAR_TRABAJADORES", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string ActualizarTrabajador(Trabajadores obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_MODIFICAR_TRABAJADORES", obj.idtra, obj.nombres, obj.tipoDocumento, obj.nroDocumento, obj.direccion, obj.email, obj.pass, obj.idrol);
                mensaje = $"Se actualizo al Trabajador: {obj.idtra} correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string EliminarTrabajador(int idtra)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_ELIMINAR_TRABAJADORES", idtra);
                mensaje = $"Se elimino correctamente al Trabajador: {idtra}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string RestaurarTrabajador(int idtra)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_RESTAURAR_TRABAJADORES", idtra);
                mensaje = $"Se restauro correctamente al Trabajador: {idtra}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }
    }
}
