using Galaxy.ApiRest.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Contexto.Configuracion
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey("IdUsuario");
            builder.ToTable("User", "DBO");

            builder.Property(t => t.IdUsuario).HasColumnName("IdUser");
            builder.Property(t => t.NombreCompleto).HasColumnName("Name");
            builder.Property(t => t.Credenciales).HasColumnName("UserName");
            builder.Property(t => t.Clave).HasColumnName("Password");
            builder.Property(t => t.Rol).HasColumnName("Rol");
        }
    }
}
