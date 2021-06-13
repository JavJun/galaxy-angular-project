using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.ApiRest.Manager;
using Galaxy.ApiRest.Models.BE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISeguridadManager seguridadManager;

        public AuthController(ISeguridadManager seguridadManager)
        {
            this.seguridadManager = seguridadManager;
        }


        [HttpPost]
        public IActionResult Valida([FromBody] LoginRequestDTO loginRequestBE)
        {

            LoginResponseDTO loginResponseBE = seguridadManager.Autentica(loginRequestBE);

            if (loginResponseBE == null)
            {
                return BadRequest("Credenciales invalidas");
            }

            return Ok(loginResponseBE);
        }

    }
}
