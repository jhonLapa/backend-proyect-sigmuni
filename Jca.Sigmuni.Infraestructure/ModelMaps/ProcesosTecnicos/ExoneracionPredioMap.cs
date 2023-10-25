using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ExoneracionPredioMap : IEntityTypeConfiguration<ExoneracionPredio>
    {
        public void Configure(EntityTypeBuilder<ExoneracionPredio> builder)
        {
            builder.ToTable("exoneracion_predio", "fic");
            builder.HasKey(t => t.IdExoneracionPredio);
            builder.Property(t => t.IdExoneracionPredio).HasColumnName("id_exoneracion_predio").UseIdentityAlwaysColumn();
            builder.Property(t => t.NumeroResolucion).HasColumnName("nume_resolucion");
            builder.Property(t => t.Porcentaje).HasColumnName("porcentake");
            builder.Property(t => t.FechaInicio).HasColumnName("fecha_inicio");
            builder.Property(t => t.FechaVencimiento).HasColumnName("fecha_vencimiento");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.AnioResolucion).HasColumnName("anio_resolucion");
            builder.Property(t => t.IdCondicionEspecialPredio).HasColumnName("id_condicion_especial_predio");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.CondicionEspecialPredio).WithMany(b => b.ExoneracionPredios).HasForeignKey(c => c.IdCondicionEspecialPredio);
        }
    }
}
