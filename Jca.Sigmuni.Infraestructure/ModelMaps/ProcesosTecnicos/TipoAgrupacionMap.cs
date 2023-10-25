using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoAgrupacionMap : IEntityTypeConfiguration<TipoAgrupacion>
    {
        public void Configure(EntityTypeBuilder<TipoAgrupacion> builder)
        {
            builder.ToTable("tipo_agrupacion", "loc");
            builder.HasKey(t => t.IdTipoAgrupacion);
            builder.Property(t => t.IdTipoAgrupacion).HasColumnName("id_tipo_agrupacion").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
