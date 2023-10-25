using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class NormaIntMonPrehiMap : IEntityTypeConfiguration<NormaIntMonPrehi>
    {
        public void Configure(EntityTypeBuilder<NormaIntMonPrehi> builder)
        {
            builder.ToTable("norma_int_mon_preins","ni");
            builder.HasKey(t => t.IdNormaIntMonPrehi);
            builder.Property(t => t.IdNormaIntMonPrehi).HasColumnName("id_norma_int_mon_preins").IsRequired();
            builder.Property(e => e.NumPlano).HasColumnName("num_plano");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.IdMonumentoPre).HasColumnName("id_monumento_pre");
            builder.Property(e => e.IdNormaInteres).HasColumnName("id_norma_interes");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.NormaInteres).WithMany(b => b.NormaIntMonPreins).HasForeignKey(c => c.IdNormaInteres);
            builder.HasOne(e => e.MonumentoPrehispanico).WithMany(b => b.NormaIntMonPreins).HasForeignKey(c => c.IdMonumentoPre);

        }
    }
}
