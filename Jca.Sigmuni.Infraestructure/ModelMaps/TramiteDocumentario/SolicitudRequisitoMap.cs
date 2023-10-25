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
    public class SolicitudRequisitoMap : IEntityTypeConfiguration<SolicitudRequisito>
    {
        public void Configure(EntityTypeBuilder<SolicitudRequisito> builder)
        {
            builder.ToTable("solicitud_requisitos", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_solicitud_requisitos").IsRequired();
            //builder.Property(e => e.Flag).HasColumnName("flag").IsUnicode(false);
            builder.Property(e => e.Flag).HasColumnName("flag");

            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdProcedimientoRequisito).HasColumnName("id_tipo_tramite_requisito");

            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.Folios).HasColumnName("folios");
            builder.Property(e => e.DocumentoObservacion).HasColumnName("documento_observaciones");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.IpAccion).HasColumnName("ip_accion");


            builder.HasOne(a => a.Solicitud).WithMany(b => b.SolicitudRequisitos).HasForeignKey(a => a.IdSolicitud);
            builder.HasOne(m => m.ProcedimientoRequisito).WithMany(m => m.SolicitudRequisito).HasForeignKey(m => m.IdProcedimientoRequisito);
            builder.HasOne(e => e.Documento).WithMany(c => c.SolicitudRequisito).HasForeignKey(c => c.IdDocumento);
        }
    }
}
