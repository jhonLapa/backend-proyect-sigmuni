using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoEvaluacionMap : IEntityTypeConfiguration<TipoEvaluacion>
    {
        public void Configure(EntityTypeBuilder<TipoEvaluacion> builder)
        {
            builder.ToTable("tipo_evaluacion", "fic");
            builder.HasKey(t => t.IdTipoEvaluacion);
            builder.Property(t => t.IdTipoEvaluacion).HasColumnName("id_tipo_evaluacion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
