using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoDocumentoFichaMap : IEntityTypeConfiguration<TipoDocumentoFicha>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoFicha> builder)
        {
            builder.ToTable("tipo_documento_ficha", "ge");
            builder.HasKey(t => t.IdTipoDocumentoFicha);
            builder.Property(t => t.IdTipoDocumentoFicha).HasColumnName("id_tipo_documento_ficha").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.Grupo).HasColumnName("grupo");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
