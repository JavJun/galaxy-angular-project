using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Models.Entities
{
    public class Opcion
    {
        [Key]
        public int IdOpcion { get; set; }
        public string NombreOpcion { get; set; }
        public string UrlOpcion { get; set; }
        public string NombreIcono { get; set; }

    }
}
