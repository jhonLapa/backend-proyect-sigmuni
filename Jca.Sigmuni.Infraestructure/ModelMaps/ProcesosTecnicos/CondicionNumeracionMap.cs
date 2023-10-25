using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class CondicionNumeracionMap : IEntityTypeConfiguration<CondicionNumeracion>
    {
        public void Configure(EntityTypeBuilder<CondicionNumeracion> builder)
        {
            builder.ToTable("condicion_numeracion", "loc");
            builder.HasKey(t => t.IdCondicionNumeracion);
            builder.Property(t => t.IdCondicionNumeracion).HasColumnName("id_condicion_numeracion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
           
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
