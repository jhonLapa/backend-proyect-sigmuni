using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoLitiganteMap : IEntityTypeConfiguration<TipoLitigante>
    {
        public void Configure(EntityTypeBuilder<TipoLitigante> builder)
        {
            builder.ToTable("tipo_litigante", "fic");
            builder.HasKey(t => t.IdTipoLitigante);
            builder.Property(t => t.IdTipoLitigante).HasColumnName("id_tipo_litigante").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
