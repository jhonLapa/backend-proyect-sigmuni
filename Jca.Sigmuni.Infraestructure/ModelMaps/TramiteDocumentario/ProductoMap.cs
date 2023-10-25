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
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("producto", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_producto");
            builder.Property(e => e.NumCorrelativo).HasColumnName("num_correlativo").HasMaxLength(100);
            builder.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            builder.Property(e => e.FechaCaducidad).HasColumnName("fecha_caducacion");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.JsonProducto).HasColumnName("json_producto").HasColumnType("NCLOB");
            builder.Property(e => e.NumInforme).HasColumnName("num_informe").HasMaxLength(500);
            builder.Property(e => e.NumPlanoZonificacion).HasColumnName("num_plano_zonificacion").HasMaxLength(50);
            builder.Property(e => e.NumPlanoVia).HasColumnName("num_plano_via").HasMaxLength(50);
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.EsProducto).HasColumnName("es_producto");

            builder.HasOne(e => e.Solicitud).WithMany(b => b.Producto).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.Documento).WithMany(b => b.Producto).HasForeignKey(c => c.IdDocumento);
        }
    }
}
