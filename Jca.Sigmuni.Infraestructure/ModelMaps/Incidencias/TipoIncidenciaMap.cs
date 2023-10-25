using Jca.Sigmuni.Domain.Incidencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Incidencias
{
    public class TipoIncidenciaMap : IEntityTypeConfiguration<TipoIncidencia>
    {
        public void Configure(EntityTypeBuilder<TipoIncidencia> builder)
        {
            builder.ToTable("tipo_incidencia", "inc");

            builder.HasKey(t => t.IdTipoIncidencia);
            builder.Property(t => t.IdTipoIncidencia).HasColumnName("id_tipo_incidencia");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}