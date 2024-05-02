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
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_GRABAR_TRABAJADORES", obj.nombres, obj.tipoDocumento, obj.nroDocumento, obj.direccion, obj.email, obj.pass, obj.idrol);
                mensaje = $"Se registro al Trabajador: {obj.nombres} correctamente";
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

    }
}
