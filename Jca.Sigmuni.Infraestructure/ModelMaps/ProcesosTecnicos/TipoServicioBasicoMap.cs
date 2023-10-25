using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoServicioBasicoMap : IEntityTypeConfiguration<TipoServicioBasico>
    {
        public void Configure(EntityTypeBuilder<TipoServicioBasico> builder)
        {
            builder.ToTable("tipo_servicio_basico", "fic");
            builder.HasKey(t => t.IdTipoServicioBasico);
            builder.Property(t => t.IdTipoServicioBasico).HasColumnName("id_tipo_servicio_basico").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.Grupo).HasColumnName("grupo");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
