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
    internal class SolicitudMap : IEntityTypeConfiguration<Solicitud>
    {
        public void Configure(EntityTypeBuilder<Solicitud> builder)
        {
            builder.ToTable("solicitud", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_solicitud");
            builder.Property(t => t.NumeroExpediente).HasColumnName("numero_expediente");
            builder.Property(t => t.NumeroSolicitud).HasColumnName("numero_solicitud");
            builder.Property(t => t.Inspeccion).HasColumnName("inspeccion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.IdMedioRegistro).HasColumnName("id_medio_registro");
            builder.Property(t => t.IdProcedimiento).HasColumnName("id_procedimiento");
            builder.Property(t => t.Monto).HasColumnName("monto");
            builder.Property(t => t.NumeroRecibo).HasColumnName("numero_recibo");
            builder.Property(t => t.IdRepresentanteLegal).HasColumnName("id_representante_legal");
            builder.Property(t => t.IdSolicitante).HasColumnName("id_solicitante");
            builder.Property(t => t.IdTipoDocumentoSimple).HasColumnName("id_tipo_documento_simple");
            builder.Property(t => t.IdTipoTramite).HasColumnName("id_tipo_tramite");
            builder.Property(t => t.NombreDocumento).HasColumnName("nombre_documento");
            builder.Property(t => t.IdArea).HasColumnName("id_area");
            builder.Property(t => t.NumExpReferencia).HasColumnName("num_exp_referencia");
            builder.Property(t => t.AnioSolicitud).HasColumnName("anio_solicitud");
            builder.Property(t => t.IdUsuarioAccion).HasColumnName("id_usuario_accion");
            builder.Property(t => t.AsuntoDocSimple).HasColumnName("asunto_doc_simple");
            builder.Property(t => t.ActualizacionGrafica).HasColumnName("actualizacion_grafica");
            //builder.Property(e => e.Ip).HasColumnName("IP_ACCION");
            builder.Property(e => e.NumeroInspeccion).HasColumnName("numero_inspeccion");
            builder.Property(e => e.AnioInspeccion).HasColumnName("anio_inspeccion");


            builder.HasOne(p => p.Procedimiento).WithMany(b => b.Solicitud).HasForeignKey(c => c.IdProcedimiento);
            builder.HasOne(s => s.Solicitante).WithMany(b => b.Solicitante).HasForeignKey(c => c.IdSolicitante);
            builder.HasOne(s => s.TipoDocumentoSimple).WithMany(b => b.Solicitud).HasForeignKey(c => c.IdTipoDocumentoSimple);
            builder.HasOne(s => s.TipoTramite).WithMany(b => b.Solicitud).HasForeignKey(c => c.IdTipoTramite);
            builder.HasOne(s => s.Area).WithMany(b => b.Solicitud).HasForeignKey(c => c.IdArea);
            builder.HasOne(r => r.RepresentanteLegal).WithMany(b => b.RepresentanteLegal).HasForeignKey(c => c.IdRepresentanteLegal);
            builder.HasOne(m => m.MedioRegistro).WithMany(m => m.Solicitud).HasForeignKey(m => m.IdMedioRegistro);

            //builder.HasMany(a => a.SolicitudCuc).WithMany(a => a.Solicitud).HasForeignKey(a => a.Id);

        }
    }
}
