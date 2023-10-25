using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class FormaAdquisicionMap : IEntityTypeConfiguration<FormaAdquisicion>
    {
        public void Configure(EntityTypeBuilder<FormaAdquisicion> builder)
        {
            builder.ToTable("forma_adquisicion", "fic");
            builder.HasKey(t => t.IdFormaAdquisicion);
            builder.Property(t => t.IdFormaAdquisicion).HasColumnName("id_forma_adquisicion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Nombre).HasColumnName("nombre");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
