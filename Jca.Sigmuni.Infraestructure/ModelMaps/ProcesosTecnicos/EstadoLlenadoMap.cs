using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class EstadoLlenadoMap : IEntityTypeConfiguration<EstadoLlenado>
    {
        public void Configure(EntityTypeBuilder<EstadoLlenado> builder)
        {
            builder.ToTable("estado_llenado", "fic");
            builder.HasKey(t => t.IdEstadoLlenado);
            builder.Property(t => t.IdEstadoLlenado).HasColumnName("id_estado_llenado").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
