using Galaxy.ApiRest.Models.DTO;
using Galaxy.ApiRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Services
{
    public interface ISeguridadService
    {
        Task<List<Opcion>> Listar(OpcionListarPagRequestDTO requestDTO);
        Task<Opcion> Recuperar(int id);
        Task<Opcion> Insertar(Opcion opcion);
        Task<Opcion> Actualizar(Opcion opcion);
        Task Eliminar(int id);
    }
}
