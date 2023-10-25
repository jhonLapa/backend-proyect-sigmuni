using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class MedioRegistroMap : IEntityTypeConfiguration<MedioRegistro>

    {
        public void Configure(EntityTypeBuilder<MedioRegistro> builder)
        {
            builder.ToTable("medio_registro", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_medio_registro");
            builder.Property(t => t.Codigo).HasColumnName("codigo").HasMaxLength(500);
            builder.Property(t => t.Descripcion).HasColumnName("descripcion").HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
