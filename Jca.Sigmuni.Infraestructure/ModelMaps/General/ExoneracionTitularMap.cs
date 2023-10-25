using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class ExoneracionTitularMap : IEntityTypeConfiguration<ExoneracionTitular>
    {
        public void Configure(EntityTypeBuilder<ExoneracionTitular> builder)
        {
            builder.ToTable("exoneracion_titular", "ge");
            builder.HasKey(t => t.IdExoneracionTitular);
            builder.Property(t => t.IdExoneracionTitular).HasColumnName("id_exoneracion_titular").UseIdentityAlwaysColumn();
            builder.Property(e => e.IdCondicionEspecialTitular).HasColumnName("id_cond_esp_titular");
            builder.Property(e => e.NumeroResolucion).HasColumnName("num_resolucion").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.NumeroBoletaPension).HasColumnName("num_boleta_pension").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.AnioBoletaPension).HasColumnName("anio_boleta").IsUnicode(false).HasMaxLength(4);
            builder.Property(e => e.AnioResolucion).HasColumnName("anio_resolucion").IsUnicode(false).HasMaxLength(4);
            builder.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            builder.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdTipoExoneracion).HasColumnName("id_tipo_exoneracion");
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");

            builder.HasOne(e => e.CondicionEspecialTitular).WithMany(b => b.ExoneracionTitulares).HasForeignKey(c => c.IdCondicionEspecialTitular);
            builder.HasOne(e => e.Persona).WithMany(b => b.ExoneracionTitulares).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.TipoExoneracion).WithMany(b => b.ExoneracionTitulares).HasForeignKey(c => c.IdTipoExoneracion);
        }
    }
}
