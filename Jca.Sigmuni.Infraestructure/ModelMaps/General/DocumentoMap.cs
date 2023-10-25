using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class DocumentoMap : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("documento", "trd");
            builder.HasKey(t => t.IdDocumento);
            builder.Property(t => t.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Contenido).HasColumnName("contenido").HasColumnType("bytea");
            builder.Property(e => e.MineType).HasColumnName("mime_type");
            builder.Property(e => e.Extencion).HasColumnName("extencion");
            builder.Property(e => e.NombreOriginal).HasColumnName("nombre_original");
            builder.Property(e => e.UbicacionFisica).HasColumnName("ubicacion_fisica");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
