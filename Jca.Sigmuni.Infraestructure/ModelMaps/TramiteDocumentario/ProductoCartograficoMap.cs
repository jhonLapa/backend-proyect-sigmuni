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
    public class ProductoCartograficoMap : IEntityTypeConfiguration<ProductoCartografico>
    {
        public void Configure(EntityTypeBuilder<ProductoCartografico> builder)
        {
            builder.ToTable("producto_cartografico","trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_producto_cartografico").IsRequired();
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdInspector).HasColumnName("id_inspector");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.Folios).HasColumnName("folios");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.IdRemitente).HasColumnName("id_remitente");
            builder.Property(e => e.EsObservado).HasColumnName("es_observado");
            builder.Property(e => e.ObservacionError).HasColumnName("observacion_error");
            builder.Property(e => e.Derivado).HasColumnName("derivado");
            builder.Property(e => e.InicioCalidad).HasColumnName("inicio_calidad");
            builder.Property(e => e.FinCalidad).HasColumnName("fin_calidad");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdInspectorCalidad).HasColumnName("id_inspector_calidad");

            //builder.HasOne(e => e.Solicitud).WithMany(b => b.ProductoCarto).HasForeignKey(c => c.IdSolicitud);
            //builder.HasOne(e => e.Inspector).WithMany(b => b.ProductoCarto).HasForeignKey(c => c.IdInspector);
            //builder.HasOne(e => e.Documento).WithMany(b => b.ProductoCarto).HasForeignKey(c => c.IdDocumento);
        }
    }
}
