using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class EcsMap : IEntityTypeConfiguration<Ecs>
    {
        public void Configure(EntityTypeBuilder<Ecs> builder)
        {
            builder.ToTable("ecs", "fic");
            builder.HasKey(t => t.IdEcs);
            builder.Property(t => t.IdEcs).HasColumnName("id_ecs").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            
        }
    }
}
