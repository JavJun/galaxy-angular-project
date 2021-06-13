using Galaxy.ApiRest.Contexto.Configuracion;
using Galaxy.ApiRest.Models;
using Galaxy.ApiRest.Models.DTO;
using Galaxy.ApiRest.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Contexto
{
    public class VentasContext : DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Aplicando Configuracion
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            #endregion


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Opcion> Opcion { get; set; }
    }
}
