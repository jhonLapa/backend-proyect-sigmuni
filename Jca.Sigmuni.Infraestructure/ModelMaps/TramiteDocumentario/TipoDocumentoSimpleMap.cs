using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class TipoDocumentoSimpleMap : IEntityTypeConfiguration<TipoDocumentoSimple>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoSimple> builder)
        {
            builder.ToTable("tipo_documento_simple", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tipo_documento_simple");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(4);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}