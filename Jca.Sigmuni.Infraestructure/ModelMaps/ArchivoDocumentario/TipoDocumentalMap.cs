using System;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ArchivoDocumentario
{
    public class TipoDocumentalMap : IEntityTypeConfiguration<TipoDocumental>
    {
        public void Configure(EntityTypeBuilder<TipoDocumental> builder)
        {
            builder.ToTable("tipo_documental", "doc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tipo_documental").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.Siglas).HasColumnName("siglas");
        }
    }
}
