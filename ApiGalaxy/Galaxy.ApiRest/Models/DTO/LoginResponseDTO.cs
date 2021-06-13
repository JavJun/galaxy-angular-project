using Galaxy.ApiRest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Models.BE
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public int IdUsuario { get; set; }

        public LoginResponseDataDTO Data { get; set; }

    }
}
