using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class EccMap : IEntityTypeConfiguration<Ecc>
    {
        public void Configure(EntityTypeBuilder<Ecc> builder)
        {
            builder.ToTable("ecc", "fic");
            builder.HasKey(t => t.IdEcc);
            builder.Property(t => t.IdEcc).HasColumnName("id_ecc").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
