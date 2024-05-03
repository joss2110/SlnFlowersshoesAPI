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
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_GRABAR_PRODUCTO", obj.codbar, obj.imagen, obj.nompro, obj.precio, obj.idtalla, obj.idcolor, obj.categoria, obj.temporada, obj.descripcion, obj.estado);
                mensaje = $"Se registro al Producto: {obj.nompro} correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string ActualizarProductos(Productos obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_MODIFICAR_PRODUCTO", obj.idpro, obj.codbar, obj.imagen, obj.nompro, obj.precio, obj.idtalla, obj.idcolor, obj.categoria, obj.temporada, obj.descripcion, obj.estado);
                mensaje = $"Se actualizo al Producto: {obj.idpro} correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
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
