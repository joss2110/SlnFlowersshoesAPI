﻿using FlowersshoesCoreMVC.DAO;
using Microsoft.AspNetCore.Mvc;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;


namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly CatalogoDAO daocatalogo;

        public CatalogoController(CatalogoDAO daoCatalogo)
        {
            daocatalogo = daoCatalogo;
        }

        
        [HttpGet("GetCatalogo")]
        public async Task<ActionResult<List<PA_OBTENER_CATALOGO_APP>>> GetCatalogo()
        {
            var listado = await Task.Run(() => daocatalogo.getCatalogoApp());
            return Ok(listado);
        }
    }
}
