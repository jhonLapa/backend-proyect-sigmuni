using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoFichaMap : IEntityTypeConfiguration<TipoFicha>
    {
        public void Configure(EntityTypeBuilder<TipoFicha> builder)
        {
            builder.ToTable("tipo_ficha", "fic");
            builder.HasKey(t => t.IdTipoFicha);

            builder.Property(e => e.IdTipoFicha).HasColumnName("id_tipo_ficha").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(100);

          
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

            builder.Property(e => e.Estado).HasColumnName("estado");





        }
    }
}
