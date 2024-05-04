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
        public async Task<ActionResult<List<Ingresos>>> GetIngresos()
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

        [HttpDelete("EliminarIngresos")]
        public async Task<ActionResult<string>> EliminarIngresos([FromBody] Ingresos obj)
        {
            string mensaje = await Task.Run(() => daoingreso.EliminarIngresos(obj));
            return Ok(mensaje);
        }

    }
}
