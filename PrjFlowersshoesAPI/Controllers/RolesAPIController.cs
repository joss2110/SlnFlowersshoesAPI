using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;

namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesAPIController : ControllerBase
    {
        private readonly RolesDAO daorol;

        public RolesAPIController(RolesDAO daoRol)
        {
            daorol = daoRol;
        }

        //GET:Roles
        [HttpGet("GetRoles")]
        public async Task<ActionResult<List<Roles>>> GetRoles()
        {
            var listado = await Task.Run(() => daorol.GetRoles());
            //
            return Ok(listado);
        }
    }
}
