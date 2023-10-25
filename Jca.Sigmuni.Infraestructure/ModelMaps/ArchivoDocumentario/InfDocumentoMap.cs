using System;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ArchivoDocumentario
{
    public class InfDocumentoMap : IEntityTypeConfiguration<InfDocumento>
    {
        public void Configure(EntityTypeBuilder<InfDocumento> builder)
        {
            builder.ToTable("inf_documento", "doc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_inf_documento").UseIdentityAlwaysColumn();
            builder.Property(t => t.NumRegistro).HasColumnName("num_registro");
            builder.Property(t => t.RazonSocial).HasColumnName("razon_social");
            builder.Property(t => t.Asunto).HasColumnName("asunto");
            builder.Property(t => t.InformacionRelevante).HasColumnName("informacion_relevante");
            builder.Property(t => t.FechaInicio).HasColumnName("fecha_inicio");
            builder.Property(t => t.FechaTermino).HasColumnName("fecha_termino");
            builder.Property(t => t.NumFolios).HasColumnName("num_folios");
            builder.Property(t => t.TotalImagenes).HasColumnName("total_imagenes");
            builder.Property(t => t.Mayora3).HasColumnName("mayora3");
            builder.Property(t => t.TapaContratapa).HasColumnName("tapa_contratapa");
            builder.Property(t => t.NumUnidadCaja).HasColumnName("num_unidad_caja");
            builder.Property(t => t.Anio).HasColumnName("anio");
            builder.Property(t => t.Observaciones).HasColumnName("observaciones");
            builder.Property(t => t.NumModulo).HasColumnName("num_modulo");
            builder.Property(t => t.Lado).HasColumnName("lado");
            builder.Property(t => t.NumCuerpo).HasColumnName("num_cuerpo");
            builder.Property(t => t.NumBalda).HasColumnName("num_balda");
            builder.Property(t => t.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(t => t.IdSeccionDocumento).HasColumnName("id_seccion_documento");
            builder.Property(t => t.IdTipoDocumental).HasColumnName("id_tipo_documental");
            builder.Property(t => t.IdSerieDocumental).HasColumnName("id_serie_documental");
            builder.Property(t => t.IdSubSerieDoc).HasColumnName("id_sub_serie_doc");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.NumCaja).HasColumnName("num_caja");
            builder.Property(t => t.NumConcatRegistro).HasColumnName("num_concat_registro");

            builder.HasOne(e => e.TipoDocumental).WithMany(b => b.InfDocumento).HasForeignKey(c => c.IdTipoDocumental);
            builder.HasOne(e => e.SerieDocumental).WithMany(b => b.InfDocumento).HasForeignKey(c => c.IdSerieDocumental);
            builder.HasOne(e => e.SubSerieDocumental).WithMany(b => b.InfDocumento).HasForeignKey(c => c.IdSubSerieDoc);
            builder.HasOne(e => e.SeccionDocumental).WithMany(b => b.InfDocumento).HasForeignKey(c => c.IdSeccionDocumento);
            builder.HasOne(e => e.Solicitud).WithMany(b => b.InfDocumento).HasForeignKey(c => c.IdSolicitud);



        }
    }
}
