using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ClasificacionPredioMap : IEntityTypeConfiguration<ClasificacionPredio>
    {
        public void Configure(EntityTypeBuilder<ClasificacionPredio> builder)
        {
            builder.ToTable("clasificacion_predio", "fic");
            builder.HasKey(t => t.IdClasificacionPredio);
            builder.Property(t => t.IdClasificacionPredio).HasColumnName("id_clasificacion_predio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
