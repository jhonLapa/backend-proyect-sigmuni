using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class CategoriaInmuebleMap : IEntityTypeConfiguration<CategoriaInmueble>
    {
        public void Configure(EntityTypeBuilder<CategoriaInmueble> builder)
        {
            //Falta por mapear
            builder.ToTable("categoria_inmueble", "loc");
            builder.HasKey(t => t.IdCategoriaInmueble);
            builder.Property(t => t.IdCategoriaInmueble).HasColumnName("id_categoria_inmueble");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
