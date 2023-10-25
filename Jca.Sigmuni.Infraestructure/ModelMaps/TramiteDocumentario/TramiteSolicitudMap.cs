using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class TramiteSolicitudMap : IEntityTypeConfiguration<TramiteSolicitud>
    {
        public void Configure(EntityTypeBuilder<TramiteSolicitud> builder)
        {
            builder.ToTable("tramite_solicitud", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tramite_solicitud");

            builder.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            builder.Property(e => e.FechaCulminacion).HasColumnName("fecha_culminacion");
            builder.Property(e => e.Observaciones).HasColumnName("observaciones");
            builder.Property(e => e.Detalle).HasColumnName("detalle");
            builder.Property(e => e.Folios).HasColumnName("folios");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado").IsRequired();
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdActividad).HasColumnName("id_actividad");
            builder.Property(e => e.IdResultado).HasColumnName("id_resultado");

            builder.Property(e => e.FechaCulminacionReal).HasColumnName("fecha_culminacion_real");
            builder.Property(e => e.CumplimientoActividad).HasColumnName("cumplimiento_actividad");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");

            builder.HasOne(e => e.Solicitud).WithMany(b => b.TramiteSolicitudes).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.Actividad).WithMany(b => b.TramiteSolicitudes).HasForeignKey(c => c.IdActividad);
            builder.HasOne(e => e.Resultado).WithMany(b => b.TramiteSolicitudes).HasForeignKey(c => c.IdResultado);
            builder.HasOne(e => e.Documento).WithMany(b => b.TramiteSolicitud).HasForeignKey(c => c.IdDocumento);
        }
    }


}
