using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class MonedaMap : IEntityTypeConfiguration<Moneda>
    {
        public void Configure(EntityTypeBuilder<Moneda> builder)
        {
            builder.ToTable("moneda", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_moneda");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}