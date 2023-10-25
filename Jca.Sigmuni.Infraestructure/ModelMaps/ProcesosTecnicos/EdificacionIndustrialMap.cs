using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class EdificacionIndustrialMap : IEntityTypeConfiguration<EdificacionIndustrial>
    {
        public void Configure(EntityTypeBuilder<EdificacionIndustrial> builder)
        {
            builder.ToTable("edificacion_industrial", "fic");
            builder.HasKey(t => t.IdEdificacionIndustrial);
            builder.Property(t => t.IdEdificacionIndustrial).HasColumnName("id_edificacion_industrial").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Titulo).HasColumnName("titulo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
