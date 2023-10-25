using Jca.Sigmuni.Domain.Vias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Vias
{
    public class TipoViaMap : IEntityTypeConfiguration<TipoVia>
    {
        public void Configure(EntityTypeBuilder<TipoVia> builder)
        {
            builder.ToTable("tipo_via", "loc");
            builder.HasKey(t => t.IdTipoVia);
            builder.Property(t => t.IdTipoVia).HasColumnName("id_tipo_via");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");



            //builder.HasOne(e => e.Ubigeo).WithMany(b => b.Via).HasForeignKey(c => c.CodigoUbigeo);

            //builder.HasMany(e => e.Domicilio).WithOne(b => b.Via).HasForeignKey(c => c.Id);

        }
    }
}
