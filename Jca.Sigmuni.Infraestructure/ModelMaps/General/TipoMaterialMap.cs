using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class TipoMaterialMap : IEntityTypeConfiguration<TipoMaterial>
    {
        public void Configure(EntityTypeBuilder<TipoMaterial> builder)
        {
            builder.ToTable("tipo_material", "loc");
            builder.HasKey(t => t.IdTipoMaterial);
            builder.Property(t => t.IdTipoMaterial).HasColumnName("id_tipo_material");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
