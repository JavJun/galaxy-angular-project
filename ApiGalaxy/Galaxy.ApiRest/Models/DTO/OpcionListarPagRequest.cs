using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Models.DTO
{
    public class OpcionListarPagRequestDTO
    {
        public string Filtro { get; set; }
        public int NroPag { get; set; }
        public int RegPorPag { get; set; }
        public int NroRegTotal { get; set; }
        

    }
}
