using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoDeclaratoriaMap : IEntityTypeConfiguration<TipoDeclaratoria>
    {
        public void Configure(EntityTypeBuilder<TipoDeclaratoria> builder)
        {
            builder.ToTable("tipo_declaratoria", "fic");
            builder.HasKey(t => t.IdTipoDeclaratoria);
            builder.Property(t => t.IdTipoDeclaratoria).HasColumnName("id_tipo_declaratoria").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
