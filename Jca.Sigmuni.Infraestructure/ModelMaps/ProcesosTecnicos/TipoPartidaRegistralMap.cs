using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoPartidaRegistralMap : IEntityTypeConfiguration<TipoPartidaRegistral>
    {
        public void Configure(EntityTypeBuilder<TipoPartidaRegistral> builder)
        {
            builder.ToTable("tipo_partida_registral", "fic");
            builder.HasKey(t => t.IdTipoPartidaRegistral);
            builder.Property(t => t.IdTipoPartidaRegistral).HasColumnName("id_tipo_partida_registral").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
