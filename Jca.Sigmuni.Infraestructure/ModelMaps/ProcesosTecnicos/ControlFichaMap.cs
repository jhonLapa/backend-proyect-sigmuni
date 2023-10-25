using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ControlFichaMap : IEntityTypeConfiguration<ControlFicha>
    {
        public void Configure(EntityTypeBuilder<ControlFicha> builder)
        {
            builder.ToTable("control_ficha", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_control_ficha");
            builder.Property(e => e.NombreFicha).HasColumnName("nombre_ficha");
            builder.Property(e => e.NombreTab).HasColumnName("nombre_tab");
            builder.Property(e => e.NombreCampo).HasColumnName("nombre_campo");
            builder.Property(e => e.ValorAnterior).HasColumnName("valor_anterior");
            builder.Property(e => e.ValorActual).HasColumnName("valor_actual");
            builder.Property(e => e.EsConforme).HasColumnName("es_conforme");
            builder.Property(e => e.Observacion).HasColumnName("observacion");
            builder.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.IdUnidadCatastral).HasColumnName("id_unidad_catastral");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");




        }
    }
}

