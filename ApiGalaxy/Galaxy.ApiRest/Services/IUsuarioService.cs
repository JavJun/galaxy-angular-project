using Galaxy.ApiRest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Services
{
    public interface IUsuarioService
    {
        Usuario Autenticar(string credencial, string clave);
        Usuario Registrar(Usuario usuario);
    }
}
