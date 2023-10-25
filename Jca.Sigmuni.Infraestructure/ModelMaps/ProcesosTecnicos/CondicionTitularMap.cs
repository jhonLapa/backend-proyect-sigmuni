using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class CondicionTitularMap : IEntityTypeConfiguration<CondicionTitular>
    {
        public void Configure(EntityTypeBuilder<CondicionTitular> builder)
        {
            builder.ToTable("condicion_titular", "fic");
            builder.HasKey(t => t.IdCondicionTitular);
            builder.Property(t => t.IdCondicionTitular).HasColumnName("id_condicion_titular").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
