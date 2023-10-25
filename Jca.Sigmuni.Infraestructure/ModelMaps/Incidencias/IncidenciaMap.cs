using Jca.Sigmuni.Domain.Incidencias;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Incidencias
{
    public class IncidenciaMap : IEntityTypeConfiguration<Incidencia>
    {
        public void Configure(EntityTypeBuilder<Incidencia> builder)
        {
            builder.ToTable("incidencia", "inc");
            builder.HasKey(t => t.IdIncidencia);
            builder.Property(t => t.IdIncidencia).HasColumnName("id_incidencia");
            builder.Property(t => t.NumeroIncidencia).HasColumnName("numero_incidencia");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.Hora).HasColumnName("hora");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.IdTipoIncidencia).HasColumnName("id_tipo_incidencia");
            builder.Property(e => e.SolucionPrevia).HasColumnName("solucion_previa");
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.IdReportarForma).HasColumnName("id_reportar_forma");
            builder.Property(e => e.IdArea).HasColumnName("id_area");
            builder.Property(e => e.IdMotivo).HasColumnName("id_motivo");
            builder.Property(e => e.OtroMotivo).HasColumnName("otro_motivo");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.IdPersonaInvolucrada).HasColumnName("id_persona_involucrada");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(p => p.TipoIncidencia).WithMany(b => b.Incidencia).HasForeignKey(c => c.IdTipoIncidencia);
            //builder.HasOne(p => p.Persona).WithMany(b => b.Incidencia).HasForeignKey(c => c.IdPersona);
            builder.HasOne(p => p.ReportarForma).WithMany(b => b.Incidencia).HasForeignKey(c => c.IdReportarForma);
            builder.HasOne(p => p.Area).WithMany(b => b.Incidencia).HasForeignKey(c => c.IdArea);
            builder.HasOne(p => p.Motivo).WithMany(b => b.Incidencia).HasForeignKey(c => c.IdMotivo);
            builder.HasOne(p => p.Documento).WithMany(b => b.Incidencia).HasForeignKey(c => c.IdDocumento);
            //builder.HasOne(p => p.PersonaInvolucrada).WithMany(b => b.IncidenciaInvolucrada).HasForeignKey(c => c.IdPersonaInvolucrada);
        }
    }
}
