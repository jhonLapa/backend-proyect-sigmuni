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
    public class SolicitudNotificacionMap : IEntityTypeConfiguration<SolicitudNotificacion>
    {
        public void Configure(EntityTypeBuilder<SolicitudNotificacion> builder)
        {
            builder.ToTable("solicitud_notificacion","trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_solicitud_notificacion");

            builder.Property(e => e.NumeroNotificacion).HasColumnName("nro_notificacion");
            builder.Property(e => e.Asunto).HasColumnName("asunto");
            builder.Property(e => e.Referencia).HasColumnName("referencia");
            builder.Property(e => e.Observacion).HasColumnName("observacion");
            builder.Property(e => e.Correo).HasColumnName("correo");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado").IsRequired();

            //builder.HasOne(e => e.Solicitud).WithMany(b => b.SolicitudNotificacion).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.Usuario).WithMany(b => b.SolicitudNotificacion).HasForeignKey(c => c.IdUsuario);
        }
    }
}
