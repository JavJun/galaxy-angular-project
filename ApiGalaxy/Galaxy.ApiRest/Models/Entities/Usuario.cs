using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Models.DTO
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Credenciales { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }


	}
}
