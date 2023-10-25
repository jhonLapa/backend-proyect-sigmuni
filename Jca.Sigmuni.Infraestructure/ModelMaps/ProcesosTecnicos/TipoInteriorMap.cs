using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoInteriorMap : IEntityTypeConfiguration<TipoInterior>
    {
        public void Configure(EntityTypeBuilder<TipoInterior> builder)
        {
            builder.ToTable("tipo_interior", "loc");
            builder.HasKey(t => t.IdTipoInterior);
            builder.Property(t => t.IdTipoInterior).HasColumnName("id_tipo_interior");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
