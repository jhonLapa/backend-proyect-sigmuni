using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ArancelMap : IEntityTypeConfiguration<Arancel>
    {
        public void Configure(EntityTypeBuilder<Arancel> builder)
        {
            builder.ToTable("arancel", "fic");
            builder.HasKey(t => t.IdArancel);
            builder.Property(t => t.IdArancel).HasColumnName("id_arancel");
            builder.Property(e => e.Anio).HasColumnName("anio");
            builder.Property(e => e.IdVia).HasColumnName("id_via").IsRequired();
            builder.Property(e => e.IdManzana).HasColumnName("id_manzana").IsRequired();
            builder.Property(e => e.Valor).HasColumnName("valor");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Manzana).WithMany(b => b.Arancel).HasForeignKey(c => c.IdManzana);
            builder.HasOne(e => e.Via).WithMany(b => b.Arancel).HasForeignKey(c => c.IdVia);
        }
    }
}
