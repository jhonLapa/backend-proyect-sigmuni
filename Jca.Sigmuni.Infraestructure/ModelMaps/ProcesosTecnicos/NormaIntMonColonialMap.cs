using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class NormaIntMonColonialMap : IEntityTypeConfiguration<NormaIntMonColonial>
    {
        public void Configure(EntityTypeBuilder<NormaIntMonColonial> builder)
        {
            builder.ToTable("norma_int_mon_colonial","ni");
            builder.HasKey(t => t.IdNormaIntMonColonial);
            builder.Property(t => t.IdNormaIntMonColonial).HasColumnName("id_norma_int_mon_colonial").IsRequired();
            builder.Property(e => e.NumPlano).HasColumnName("num_plano");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.IdMonumentoColonial).HasColumnName("id_monumento_colonial");
            builder.Property(e => e.IdNormaInteres).HasColumnName("id_norma_interes");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.NormaInteres).WithMany(b => b.NormaIntMonColonial).HasForeignKey(c => c.IdNormaInteres);
            builder.HasOne(e => e.MonumentoColonial).WithMany(b => b.NormaIntMonColonial).HasForeignKey(c => c.IdMonumentoColonial);

        }
    }
}
