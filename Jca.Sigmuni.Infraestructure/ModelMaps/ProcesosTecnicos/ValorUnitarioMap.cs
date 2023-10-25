using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ValorUnitarioMap : IEntityTypeConfiguration<ValorUnitario>
    {
        public void Configure(EntityTypeBuilder<ValorUnitario> builder)
        {
            builder.ToTable("valor_unitario", "fic");
            builder.HasKey(t => t.IdValorUnitario);
            builder.Property(t => t.IdValorUnitario).HasColumnName("id_valor_unitario").UseIdentityAlwaysColumn();
            builder.Property(e => e.Anio).HasColumnName("anio").IsUnicode(false).HasMaxLength(4);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200);
            builder.Property(e => e.Valor).HasColumnName("valor");
            builder.Property(e => e.IdClasificacionValUnitario).HasColumnName("id_clasificacion_valunitario");
            builder.Property(e => e.IdCategoriaValUnitario).HasColumnName("id_categoria_valubnitario");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.ClasificacionValorUnitario).WithMany(b => b.ValorUnitario).HasForeignKey(c => c.IdClasificacionValUnitario);
            builder.HasOne(e => e.CategoriaValorUnitario).WithMany(b => b.ValorUnitario).HasForeignKey(c => c.IdCategoriaValUnitario);
        }
    }
}
