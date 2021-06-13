using Galaxy.ApiRest.Models.BE;
using Galaxy.ApiRest.Models.DTO;
using Galaxy.ApiRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Manager
{
    public interface ISeguridadManager
    {
        LoginResponseDTO Autentica(LoginRequestDTO loginRequestBE);

        #region Opciones

        Task<OpcionListarPagResponseDTO> OpcionListar(OpcionListarPagRequestDTO requestDTO);
        Task<Opcion> OpcionRecuperar(int id);
        Task<Opcion> OpcionInsertar(Opcion opcion);
        Task<Opcion> OpcionActualizar(Opcion opcion);
        Task OpcionEliminar(int id);

        #endregion
    }
}
