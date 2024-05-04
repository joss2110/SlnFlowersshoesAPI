using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;

namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresAPIController : ControllerBase
    {
        private readonly TrabajadoresDAO daotra;

        public TrabajadoresAPIController(TrabajadoresDAO daoTra)
        {
            daotra = daoTra;
        }

        // GET:Trabajadores
        // http://localhost:5050/api/TrabajadoresAPI/GetTrabajadores
        [HttpGet("GetTrabajadores")]
        public async Task<ActionResult<List<PA_LISTAR_TRABAJADORES>>> GetTrabajadores()
        {
            var listado = await Task.Run(() => daotra.getTrabajadores());
            //
            return Ok(listado);
        }

        // POST:Trabajadores
        // http://localhost:5050/api/TrabajadoresAPI/GrabarTrabajadoresPost
        [HttpPost("GrabarTrabajadoresPost")]
        public async Task<ActionResult<String>> GrabarTrabajadoresPost([FromBody] Trabajadores obj)
        {
            string mensaje = await Task.Run(() => daotra.GrabarTrabajador(obj));
            //
            return Ok(mensaje);
        }

        // PUT:Trabajadores
        // http://localhost:5050/api/TrabajadoresAPI/ActualizarTrabajadoresPut
        [HttpPut("ActualizarTrabajadoresPut")]
        public async Task<ActionResult<String>> ActualizarTrabajadoresPut([FromBody] Trabajadores obj)
        {
            string mensaje = await Task.Run(() => daotra.ActualizarTrabajador(obj));
            //
            return Ok(mensaje);
        }

        // DELETE:Trabajadores
        // http://localhost:5050/api/TrabajadoresAPI/DeleteTrabajadores/4
        [HttpDelete("DeleteTrabajadores/{id}")]
        public async Task<ActionResult<String>> DeleteTrabajadores(int id)
        {
            string mensaje = await Task.Run(() => daotra.EliminarTrabajador(id));
            //
            return Ok(mensaje);
        }

        // RESTAURAR
        // http://localhost:5050/api/TrabajadoresAPI/RestaurarTrabajadores/4
        [HttpDelete("RestaurarTrabajadores/{id}")]
        public async Task<ActionResult<String>> RestaurarTrabajadores(int id)
        {
            string mensaje = await Task.Run(() => daotra.RestaurarTrabajador(id));
            //
            return Ok(mensaje);
        }


    }
}
