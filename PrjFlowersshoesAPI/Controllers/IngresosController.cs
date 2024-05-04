using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;

namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IngresosDAO daoingreso;

        public IngresosController(IngresosDAO ingreso)
        {
            daoingreso = ingreso;
        }

        [HttpGet("GetIngresos")]
        public async Task<ActionResult<List<PA_LISTAR_INGRESOS>>> GetIngresos()
        {
            var listado = await Task.Run(() => daoingreso.GetIngresos());

            return Ok(listado);
        }

        [HttpPost("GrabarIngresos")]
        public async Task<ActionResult<string>> GrabarIngresos([FromBody] Ingresos obj)
        {
            string mensaje = await Task.Run(() => daoingreso.GrabarIngresos(obj));
            return Ok(mensaje);
        }

        [HttpDelete("EliminarIngresos/{id}")]
        public async Task<ActionResult<string>> EliminarIngresos(int id)
        {
            string mensaje = await Task.Run(() => daoingreso.EliminarIngresos(id));
            return Ok(mensaje);
        }

        [HttpPut("RestaurarIngresos/{id}")]
        public async Task<ActionResult<string>> RestaurarIngresos(int id)
        {
            string mensaje = await Task.Run(() => daoingreso.RestaurarIngresos(id));
            return Ok(mensaje);
        }

    }
}
