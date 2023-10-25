using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class CondicionConductorMap : IEntityTypeConfiguration<CondicionConductor>
    {
        public void Configure(EntityTypeBuilder<CondicionConductor> builder)
        {
            builder.ToTable("condicion_conductor", "fic");
            builder.HasKey(t => t.IdCondicionConductor);
            builder.Property(t => t.IdCondicionConductor).HasColumnName("id_condicion_conductor").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
