using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class TipoDocumentoPresentadoMap : IEntityTypeConfiguration<TipoDocumentoPresentado>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoPresentado> builder)
        {
            builder.ToTable("tipo_documento", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tipo_documento").IsRequired();
            builder.Property(e => e.Nombre).HasColumnName("nombre").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
