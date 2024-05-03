using Microsoft.AspNetCore.Mvc;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosDAO daopro;

        public ProductosController(ProductosDAO daoPro)
        {
            daopro = daoPro;
        }
        // GET:Productos
        [HttpGet("GetProductos")]
        public async Task<ActionResult<List<PA_LISTAR_PRODUCTOS>>> GetProductos()
        {
            var listado = await Task.Run(() => daopro.getProductos());
            //
            return Ok(listado);
        }

        // POST:Productos
        [HttpPost("GrabarProductosPost")]
        public async Task<ActionResult<String>> GrabarProductosPost([FromBody] Productos obj)
        {
            string mensaje = await Task.Run(() => daopro.GrabarProductos(obj));
            //
            return Ok(mensaje);
        }

        // PUT:Productos
        [HttpPut("ActualizarProductosPut")]
        public async Task<ActionResult<String>> ActualizarProductosPut([FromBody] Productos obj)
        {
            string mensaje = await Task.Run(() => daopro.ActualizarProductos(obj));
            //
            return Ok(mensaje);
        }

        // DELETE:Productos
        [HttpDelete("DeleteProductos/{id}")]
        public async Task<ActionResult<String>> DeleteProductos(int id)
        {
            string mensaje = await Task.Run(() => daopro.EliminarProducto(id));
            //
            return Ok(mensaje);
        }
    }
}
