using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Models.BE
{
    public class LoginRequestDTO
    {
        public string Credencial { get; set; }
        public string Clave { get; set; }
    }
}
