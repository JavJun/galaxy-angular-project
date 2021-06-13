using Galaxy.ApiRest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Services
{
    public class UsuarioServiceMemoria:IUsuarioService
    {
        List<Usuario> contexto = null;
        public UsuarioServiceMemoria()
        {
            contexto = new List<Usuario>();
            contexto.Add(new Usuario() { IdUsuario = 1, NombreCompleto = "Javier Flores", Credenciales = "jfloresv",Clave="123456",Rol="admin" });
            contexto.Add(new Usuario() { IdUsuario = 2, NombreCompleto = "Luis Perez", Credenciales = "lperez", Clave = "admin", Rol="admin" });
            contexto.Add(new Usuario() { IdUsuario = 3, NombreCompleto = "Daniel Sanchez", Credenciales = "dsanchez", Clave = "root",Rol= "admin" });

        }

        public Usuario Autenticar(string credencial, string clave)
        {
            return (from x in contexto
                    where x.Credenciales == credencial && x.Clave == clave
                    select x).FirstOrDefault();
        }

        public Usuario Registrar(Usuario usuario)
        {
            contexto.Add(usuario);
            return usuario;
        }
    }
}
