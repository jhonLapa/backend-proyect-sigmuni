using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoAnuncioMap : IEntityTypeConfiguration<TipoAnuncio>
    {
        public void Configure(EntityTypeBuilder<TipoAnuncio> builder)
        {
            builder.ToTable("tipo_anuncio", "fic");
            builder.HasKey(t => t.IdTipoAnuncio);
            builder.Property(t => t.IdTipoAnuncio).HasColumnName("id_tipo_anuncio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
