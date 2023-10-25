using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class MepMap : IEntityTypeConfiguration<Mep>
    {
        public void Configure(EntityTypeBuilder<Mep> builder)
        {
            builder.ToTable("mep", "fic");
            builder.HasKey(t => t.IdMep);
            builder.Property(t => t.IdMep).HasColumnName("id_mep").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
