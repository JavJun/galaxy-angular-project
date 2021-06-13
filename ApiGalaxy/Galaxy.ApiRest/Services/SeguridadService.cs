using Galaxy.ApiRest.Contexto;
using Galaxy.ApiRest.Models.DTO;
using Galaxy.ApiRest.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Services
{
    public class SeguridadService : ISeguridadService
    {
        private readonly VentasContext ventasContext;

        public SeguridadService(VentasContext ventasContext)
        {
            this.ventasContext = ventasContext;
        }

        public async Task<Opcion> Actualizar(Opcion opcion)
        {
            ventasContext.Opcion.Update(opcion);
            await ventasContext.SaveChangesAsync();
            return opcion;
        }

        public async Task Eliminar(int id)
        {
            var opt = await ventasContext.Opcion.FirstOrDefaultAsync(t => t.IdOpcion == id);
            ventasContext.Opcion.Remove(opt);
            await ventasContext.SaveChangesAsync();
        }

        public async Task<Opcion> Insertar(Opcion opcion)
        {
            await ventasContext.Opcion.AddAsync(opcion);
            await ventasContext.SaveChangesAsync();
            return opcion;
        }

        public async Task<List<Opcion>> Listar(OpcionListarPagRequestDTO requestDTO)
        {
            //return await ventasContext.Opcion.AsNoTracking().ToListAsync();
            var query = (from x in ventasContext.Opcion
                         select x);

            //if (!string.IsNullOrEmpty(requestDTO.Filtro))
            //{
            //    query = query.Where(t =>
            //      (t.Cliente.ApellidoMaterno + t.Cliente.ApellidoPaterno + t.Cliente.Nombres)
            //      .Contains(requestDTO.Filtro, StringComparison.InvariantCultureIgnoreCase));
            //}

            requestDTO.NroRegTotal = await query.CountAsync();
            //pedidoListarPagRequestDTO.NroRegTotal = query.Count();

            query = query
                .Skip(requestDTO.NroPag * requestDTO.RegPorPag)
                .Take(requestDTO.RegPorPag).AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<Opcion> Recuperar(int id)
        {
            return await ventasContext.Opcion.AsNoTracking().FirstOrDefaultAsync(t => t.IdOpcion == id);
        }
    }
}
