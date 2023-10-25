using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoDocumentoObraMap : IEntityTypeConfiguration<TipoDocumentoObra>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoObra> builder)
        {
            builder.ToTable("tipo_documento_obra", "fic");
            builder.HasKey(t => t.IdTipoDocumentoObra);
            builder.Property(t => t.IdTipoDocumentoObra).HasColumnName("id_tipo_documento_obra").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
