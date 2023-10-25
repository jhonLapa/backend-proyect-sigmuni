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
    internal class EvaluacionPredioCatastralMap : IEntityTypeConfiguration<EvaluacionPredioCatastral>
    {
        public void Configure(EntityTypeBuilder<EvaluacionPredioCatastral> builder)
        {
            builder.ToTable("evaluacion_predio_catrastal", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_evaluacion").UseIdentityAlwaysColumn();
            builder.Property(t => t.PredioCatastralSobreEvaluado).HasColumnName("predio_catrastal_sobreevaluado");
            builder.Property(t => t.PredioCatastralSubEvaluado).HasColumnName("predio_catrastal_subevaluado");
            builder.Property(t => t.PredioCatastralOmiso).HasColumnName("predio_catrastal_omiso");
            builder.Property(t => t.PredioCatastralConforme).HasColumnName("predio_catrastal_conforme");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");

            builder.HasOne(e => e.Ficha).WithMany(b => b.EvaluacionPredioCatastrales).HasForeignKey(c => c.IdFicha);
        }
    }
}
