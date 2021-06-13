using AutoMapper;
using Galaxy.ApiRest.Configs;
using Galaxy.ApiRest.Models.BE;
using Galaxy.ApiRest.Models.DTO;
using Galaxy.ApiRest.Models.Entities;
using Galaxy.ApiRest.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Manager
{
    public class SeguridadManager : ISeguridadManager
    {
        private readonly IOptions<JwtParameterConfig> options;
        private readonly IUsuarioService usuarioService;
        private readonly ISeguridadService seguridadService;
        private readonly IMapper mapper;

        public SeguridadManager(
            IOptions<JwtParameterConfig> options,
            IUsuarioService usuarioService,
            ISeguridadService seguridadService, IMapper mapper)
        {
            this.options = options;
            this.usuarioService = usuarioService;
            this.seguridadService = seguridadService;
            this.mapper = mapper;
        }



        public LoginResponseDTO Autentica(LoginRequestDTO loginRequestBE)
        {
            LoginResponseDTO loginResponseBE = null;

            Usuario user = usuarioService.Autenticar(loginRequestBE.Credencial, loginRequestBE.Clave);

            if (user == null)
            {
                return loginResponseBE;
            }
            //if (!(loginRequestBE.Credencial == "jperez" && loginRequestBE.Clave == "123456"))
            //{
            //    return loginResponseBE;
            //};


            //Generar la semilla
            string semilla = options.Value.Secret;// "Miguel123abc098673";
            byte[] semillaByte = Encoding.UTF8.GetBytes(semilla);
            SymmetricSecurityKey key = new SymmetricSecurityKey(semillaByte);

            //Crear el algoritmo de encriptacion
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Crear Payload
            var misClaims = new[] {
                new Claim("user", user.Credenciales),
                new Claim("rol", user.Rol),
                new Claim("cod", user.IdUsuario.ToString()),
            };

            DateTime fechaCaduca = DateTime.Now.AddMinutes(5);
            //Crear un generador de token
            JwtSecurityToken generador = new JwtSecurityToken(
                claims: misClaims,
                expires: fechaCaduca,
                signingCredentials: cred,
                issuer: "demo.com",
                audience: "demo.com"
                );

            //Lanzar un token en base al generador
            string tk = new JwtSecurityTokenHandler().WriteToken(generador);

            loginResponseBE = new LoginResponseDTO();
            loginResponseBE.Token = tk;
            loginResponseBE.IdUsuario = user.IdUsuario;
            loginResponseBE.Data = new LoginResponseDataDTO
            {
                FechaCaducidad = fechaCaduca,
                AutoGenerado = Guid.NewGuid().ToString()
            };

            return loginResponseBE;
        }

        #region Opcion
        public async Task<Opcion> OpcionActualizar(Opcion opcion)
        {
            return await seguridadService.Actualizar(opcion);
        }
        public async Task OpcionEliminar(int id)
        {
            await seguridadService.Eliminar(id);
        }

        public async Task<Opcion> OpcionInsertar(Opcion opcion)
        {
            return await seguridadService.Insertar(opcion);
        }

        public async Task<OpcionListarPagResponseDTO> OpcionListar(OpcionListarPagRequestDTO requestDTO)
        {
            //return await seguridadService.Listar();
            List<Opcion> listaOpciones = await seguridadService.Listar(requestDTO);
            var listaRes = mapper.Map<List<Opcion>>(listaOpciones);
            OpcionListarPagResponseDTO res = new OpcionListarPagResponseDTO { ListaOpcion = listaRes, TotalReg = requestDTO.NroRegTotal };
            return res;
        }

        public async Task<Opcion> OpcionRecuperar(int id)
        {
            return await seguridadService.Recuperar(id);
        }

       

        #endregion

    }
}
