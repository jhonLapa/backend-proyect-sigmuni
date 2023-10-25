using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class UnidadMedidaMap : IEntityTypeConfiguration<UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.ToTable("unidad_medida", "fic");
            builder.HasKey(t => t.IdUnidadMedida);
            builder.Property(t => t.IdUnidadMedida).HasColumnName("id_unidad_medida").UseIdentityAlwaysColumn();
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.Abreviatura).HasColumnName("abreviatura");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
