using PrjFlowersshoesAPI.Models;
using System.Data.SqlClient;

namespace PrjFlowersshoesAPI.DAO
{
    public class ProductosDAO
    {
        private string cad_sql = "";
        public ProductosDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_PRODUCTOS> getProductos()
        {
            var lista = new List<PA_LISTAR_PRODUCTOS>();
            //
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_PRODUCTOS");
            //
            while (dr.Read())
            {
                lista.Add(new PA_LISTAR_PRODUCTOS()
                {
                    idpro = dr.GetInt32(0),
                    codbar = dr.GetString(1),
                    imagen = dr.GetString(2),
                    nompro = dr.GetString(3),
                    precio = dr.GetDecimal(4),
                    talla = dr.GetString(5),
                    color = dr.GetString(6),
                    categoria = dr.GetString(7),
                    temporada = dr.GetString(8),
                    descripcion = dr.GetString(9),
                    estado = dr.GetString(10)
                });
            }
            dr.Close();
            //
            return lista;
        }


        public string GrabarProductos(Productos obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@codbar", obj.codbar));
            parametros.Add(new KeyValuePair<string, object>("@imagen", obj.imagen));
            parametros.Add(new KeyValuePair<string, object>("@nompro", obj.nompro));
            parametros.Add(new KeyValuePair<string, object>("@precio", obj.precio));
            parametros.Add(new KeyValuePair<string, object>("@idtalla", obj.idtalla));
            parametros.Add(new KeyValuePair<string, object>("@idcolor", obj.idcolor));
            parametros.Add(new KeyValuePair<string, object>("@categoria", obj.categoria));
            parametros.Add(new KeyValuePair<string, object>("@temporada", obj.temporada));
            parametros.Add(new KeyValuePair<string, object>("@descripcion", obj.descripcion));
            parametros.Add(new KeyValuePair<string, object>("@estado", obj.estado));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_GRABAR_PRODUCTO", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }


        public string ActualizarProductos(Productos obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idpro", obj.idpro));
            parametros.Add(new KeyValuePair<string, object>("@codbar", obj.codbar));
            parametros.Add(new KeyValuePair<string, object>("@imagen", obj.imagen));
            parametros.Add(new KeyValuePair<string, object>("@nompro", obj.nompro));
            parametros.Add(new KeyValuePair<string, object>("@precio", obj.precio));
            parametros.Add(new KeyValuePair<string, object>("@idtalla", obj.idtalla));
            parametros.Add(new KeyValuePair<string, object>("@idcolor", obj.idcolor));
            parametros.Add(new KeyValuePair<string, object>("@categoria", obj.categoria));
            parametros.Add(new KeyValuePair<string, object>("@temporada", obj.temporada));
            parametros.Add(new KeyValuePair<string, object>("@descripcion", obj.descripcion));
            parametros.Add(new KeyValuePair<string, object>("@estado", obj.estado));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_MODIFICAR_PRODUCTO", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string EliminarProducto(int idpro)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_ELIMINAR_PRODUCTOS", idpro);
                mensaje = $"Se elimino correctamente al Producto: {idpro}";
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
