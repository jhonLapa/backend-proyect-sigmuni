using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class TipoInformeMap : IEntityTypeConfiguration<TipoInforme>
    {
        public void Configure(EntityTypeBuilder<TipoInforme> builder)
        {
            builder.ToTable("tipo_informe", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tipo_informe").IsRequired();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
