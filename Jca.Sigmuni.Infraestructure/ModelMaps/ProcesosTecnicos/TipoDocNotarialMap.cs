using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoDocNotarialMap : IEntityTypeConfiguration<TipoDocNotarial>
    {
        public void Configure(EntityTypeBuilder<TipoDocNotarial> builder)
        {
            builder.ToTable("tipo_doc_notarial", "fic");
            builder.HasKey(t => t.IdTipoDocNotarial);
            builder.Property(t => t.IdTipoDocNotarial).HasColumnName("id_tipo_doc_notarial").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
