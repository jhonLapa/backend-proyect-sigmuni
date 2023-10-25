using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoMantenimientoMap : IEntityTypeConfiguration<TipoMantenimiento>
    {
        public void Configure(EntityTypeBuilder<TipoMantenimiento> builder)
        {
            builder.ToTable("tipo_mantenimiento", "fic");
            builder.HasKey(t => t.IdTipoMantenimiento);
            builder.Property(t => t.IdTipoMantenimiento).HasColumnName("id_tipo_mantenimiento").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
