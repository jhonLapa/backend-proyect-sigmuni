using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ReintegroSolicitudMap : IEntityTypeConfiguration<ReintegroSolicitud>
    {
        public void Configure(EntityTypeBuilder<ReintegroSolicitud> builder)
        {
            builder.ToTable("reintegro_solicitud");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_reintegro_solicitud");

            builder.Property(e => e.Importe).HasColumnName("importe");
            builder.Property(e => e.NumeroRecibo).HasColumnName("numero_recibo");
            builder.Property(e => e.FechaRecibo).HasColumnName("fecha_recibo");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado").IsRequired();

            //builder.HasOne(e => e.Solicitud).WithMany(b => b.ReintegroSolicitudes).HasForeignKey(c => c.IdSolicitud);
        }
    }
}
