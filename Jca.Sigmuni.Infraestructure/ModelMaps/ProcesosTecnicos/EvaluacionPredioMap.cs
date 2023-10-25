using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class EvaluacionPredioMap : IEntityTypeConfiguration<EvaluacionPredio>
    {
        public void Configure(EntityTypeBuilder<EvaluacionPredio> builder)
        {
            builder.ToTable("evaluacion_predio", "fic");
            builder.HasKey(t => t.IdEvaluacionPredio);
            builder.Property(t => t.IdEvaluacionPredio).HasColumnName("id_evaluacion_predio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Area).HasColumnName("area");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.IdTipoEvaluacion).HasColumnName("id_tipo_evaluacion");

            builder.HasOne(e => e.Ficha).WithMany(b => b.EvaluacionPredios).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoEvaluacion).WithMany(b => b.EvaluacionPredios).HasForeignKey(c => c.IdTipoEvaluacion);
        }
    }
}
