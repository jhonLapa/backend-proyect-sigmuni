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
    public class PagoMap : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("pago","trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_pago");
            builder.Property(e => e.NumeroRecibo).HasColumnName("num_recibo").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.NumeroOperacion).HasColumnName("num_operacion").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Importe).HasColumnName("importe").IsUnicode(false);
            builder.Property(e => e.Fecha).HasColumnName("fecha").IsUnicode(false);
            builder.Property(e => e.Hora).HasColumnName("hora").IsUnicode(false);
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdMedioPago).HasColumnName("id_medio_pago");
            builder.Property(e => e.IdMoneda).HasColumnName("id_moneda");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Solicitud).WithMany(b => b.Pagos).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.MedioPago).WithMany(b => b.Pago).HasForeignKey(c => c.IdMedioPago);
            builder.HasOne(e => e.Moneda).WithMany(b => b.Pago).HasForeignKey(c => c.IdMoneda);
        }
    }
}
