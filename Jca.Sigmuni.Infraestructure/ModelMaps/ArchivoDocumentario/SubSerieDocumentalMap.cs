using System;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ArchivoDocumentario
{
    public class SubSerieDocumentalMap : IEntityTypeConfiguration<SubSerieDocumental>
    {
        public void Configure(EntityTypeBuilder<SubSerieDocumental> builder)
        {
            builder.ToTable("sub_serie_documental", "doc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_sub_serie_doc").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
