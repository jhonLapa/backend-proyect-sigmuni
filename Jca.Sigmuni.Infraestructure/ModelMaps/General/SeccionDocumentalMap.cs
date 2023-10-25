using System;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class SeccionDocumentalMap : IEntityTypeConfiguration<SeccionDocumental>
    {
        public void Configure(EntityTypeBuilder<SeccionDocumental> builder)
        {
            builder.ToTable("seccion_documento", "doc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_seccion_documento").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.Siglas).HasColumnName("siglas");
        }
    }
}
