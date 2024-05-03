using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;

namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallasController : ControllerBase
    {
        private readonly TallasDAO daotalla;

        public TallasController(TallasDAO daoTalla)
        {
            daotalla = daoTalla;
        }

        //GET:Tallas
        [HttpGet("GetTallas")]
        public async Task<ActionResult<List<Tallas>>> GetTallas()
        {
            var listado = await Task.Run(() => daotalla.GetTallas());
            //
            return Ok(listado);
        }
    }
}
