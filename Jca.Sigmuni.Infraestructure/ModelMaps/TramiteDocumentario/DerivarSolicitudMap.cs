using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class DerivarSolicitudMap : IEntityTypeConfiguration<DerivarSolicitud>
    {
        public void Configure(EntityTypeBuilder<DerivarSolicitud> builder)
        {
            builder.ToTable("derivar_solicitud", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_derivar_solicitud").IsRequired();

            builder.Property(e => e.IdTramiteSolicitud).HasColumnName("id_tramite_solicitud");
            builder.Property(e => e.IdRemitente).HasColumnName("id_remitente");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.Duracion).HasColumnName("duracion");
            builder.Property(e => e.FechaEnvio).HasColumnName("fecha_envio");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento").IsRequired();
            builder.Property(e => e.Observacion).HasColumnName("observacion").IsRequired();
            builder.Property(e => e.IdArea).HasColumnName("id_area");
            builder.Property(e => e.IdDestinatario).HasColumnName("id_destinatario");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado");

            //builder.HasOne(p => p.TramiteSolicitud).WithMany(b => b.DerivarSolicitud).HasForeignKey(c => c.IdTramiteSolicitud);
            //builder.HasOne(p => p.Remitente).WithMany(b => b.DerivarSolicitudRemitente).HasForeignKey(c => c.IdRemitente);
            //builder.HasOne(p => p.Destinatario).WithMany(b => b.DerivarSolicitudDestinatario).HasForeignKey(c => c.IdDestinatario);
            builder.HasOne(p => p.Documento).WithMany(b => b.DerivarSolicitud).HasForeignKey(c => c.IdDocumento);

        }
    }
}
