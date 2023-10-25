using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class DepreciacionMap : IEntityTypeConfiguration<Depreciacion>
    {
        public void Configure(EntityTypeBuilder<Depreciacion> builder)
        {
            builder.ToTable("depreciacion", "fic");
            builder.HasKey(t => t.IdDepreciacion);
            builder.Property(t => t.IdDepreciacion).HasColumnName("id_depreciacion").IsRequired();
            builder.Property(e => e.Porcentaje).HasColumnName("porcentaje");
            builder.Property(e => e.IdAntiguedad).HasColumnName("id_antiguedad");
            builder.Property(e => e.IdEcs).HasColumnName("id_ecs");
            builder.Property(e => e.IdMep).HasColumnName("id_mep");
            builder.Property(e => e.IdClasificacionPredio).HasColumnName("id_clasificacion_predio");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Antiguedad).WithMany(b => b.Depreciacion).HasForeignKey(c => c.IdAntiguedad);
            builder.HasOne(e => e.Ecs).WithMany(b => b.Depreciacion).HasForeignKey(c => c.IdEcs);
            builder.HasOne(e => e.Mep).WithMany(b => b.Depreciacion).HasForeignKey(c => c.IdMep);
            builder.HasOne(e => e.ClasificacionPredio).WithMany(b => b.Depreciacion).HasForeignKey(c => c.IdClasificacionPredio);
        }
    }
}
