using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoEdificacionMap : IEntityTypeConfiguration<TipoEdificacion>
    {
        public void Configure(EntityTypeBuilder<TipoEdificacion> builder)
        {
            builder.ToTable("tipo_edificacion", "loc");
            builder.HasKey(t => t.IdTipoEdificacion);
            builder.Property(t => t.IdTipoEdificacion).HasColumnName("id_tipo_edificacion").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
