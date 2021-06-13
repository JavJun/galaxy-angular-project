using Galaxy.ApiRest.Models.BE;
using Galaxy.ApiRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Models.DTO
{
    public class OpcionListarPagResponseDTO
    {

        public int TotalReg { get; set; }
        public List<Opcion> ListaOpcion { get; set; }

    }
}
