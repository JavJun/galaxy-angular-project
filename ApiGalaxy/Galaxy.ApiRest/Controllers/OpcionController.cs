using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.ApiRest.Manager;
using Galaxy.ApiRest.Models.DTO;
using Galaxy.ApiRest.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionController : ControllerBase
    {
        private readonly ISeguridadManager seguridadManager;

        public OpcionController(ISeguridadManager seguridadManager)
        {
            this.seguridadManager = seguridadManager;
        }

        [HttpGet]
        public async Task<IActionResult> Listado(int NroPag, int RegPorPag, string filtro = "") {

            return Ok(await seguridadManager.OpcionListar(new OpcionListarPagRequestDTO { NroPag = NroPag, RegPorPag = RegPorPag, Filtro = filtro }));
        }

        [HttpGet("{cod}")]
        public async Task<IActionResult> Recuperar(int cod = 0)
        {
            return Ok(await seguridadManager.OpcionRecuperar(cod));
        }

        [HttpPut("{cod}")]
        public async Task<IActionResult> Actualizar(int cod,[FromBody] Opcion op)
        {
            if (cod != op.IdOpcion)
                {
                    return BadRequest("Datos no coinciden");
                }
            if (string.IsNullOrEmpty(op.NombreOpcion))
            {
                return BadRequest("Debe enviar el nombre");
            }
            return Ok(await seguridadManager.OpcionActualizar(op));

        }

    }
}
