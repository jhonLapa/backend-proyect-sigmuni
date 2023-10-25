using System;
using Jca.Sigmuni.Domain.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Admins
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_usuario");
            builder.Property(t => t.NombreUsuario).HasColumnName("nombre_usuario");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.Clave).HasColumnName("clave");
            builder.Property(t => t.ClaveSalt).HasColumnName("clave_salt");
            builder.Property(t => t.IdPerfil).HasColumnName("id_perfil");
            builder.Property(t => t.TrabajadorPermanente).HasColumnName("trabajador_permanente");
            builder.Property(t => t.IdAreaCargo).HasColumnName("id_area_cargo");
            builder.Property(t => t.FechaAlta).HasColumnName("fecha_alta");
            builder.Property(t => t.FechaBaja).HasColumnName("fecha_baja");
            builder.Property(t => t.IdCargo).HasColumnName("id_cargo");
            builder.Property(t => t.IdArea).HasColumnName("id_area");
            builder.Property(t => t.ClaveAlterna).HasColumnName("clave_alterna");
            builder.Property(t => t.ClaveSaltAlterna).HasColumnName("clave_salt_alterna");

            builder.HasOne(e => e.Perfil).WithMany(b => b.Usuario).HasForeignKey(c => c.IdPerfil);
            builder.HasOne(e => e.Area).WithMany(b => b.Usuario).HasForeignKey(c => c.IdArea);
            builder.HasOne(e => e.Cargo).WithMany(b => b.Usuario).HasForeignKey(c => c.IdCargo);
        }
    }
}

