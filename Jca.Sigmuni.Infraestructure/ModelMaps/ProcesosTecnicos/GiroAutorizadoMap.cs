using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class GiroAutorizadoMap : IEntityTypeConfiguration<GiroAutorizado>
    {
        public void Configure(EntityTypeBuilder<GiroAutorizado> builder)
        {
            builder.ToTable("giro_autorizado", "fic");
            builder.HasKey(t => t.IdGiroAutorizado);
            builder.Property(t => t.IdGiroAutorizado).HasColumnName("id_giro_autorizado").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
