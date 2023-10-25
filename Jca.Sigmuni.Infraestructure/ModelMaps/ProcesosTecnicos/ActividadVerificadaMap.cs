using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ActividadVerificadaMap : IEntityTypeConfiguration<ActividadVerificada>
    {
        public void Configure(EntityTypeBuilder<ActividadVerificada> builder)
        {
            builder.ToTable("actividad_verificada", "fic");
            builder.HasKey(t => t.IdActividadVerificada);
            builder.Property(t => t.IdActividadVerificada).HasColumnName("id_actividad_verificada").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
