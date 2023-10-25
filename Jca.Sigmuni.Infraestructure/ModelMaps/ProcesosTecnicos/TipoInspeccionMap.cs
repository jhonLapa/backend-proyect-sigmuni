using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoInspeccionMap : IEntityTypeConfiguration<TipoInspeccion>
    {
        public void Configure(EntityTypeBuilder<TipoInspeccion> builder)
        {
            builder.ToTable("tipo_inspeccion", "fic");
            builder.HasKey(t => t.IdTipoInspeccion);
            builder.Property(t => t.IdTipoInspeccion).HasColumnName("id_tipo_inspeccion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
