using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ProcedimientoNormaInteresMap : IEntityTypeConfiguration<ProcedimientoNormaInteres>
    {
        public void Configure(EntityTypeBuilder<ProcedimientoNormaInteres> builder)
        {
            builder.ToTable("procedimiento_norma_interes","trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_procedimiento_norma_interes").IsRequired();
            builder.Property(e => e.IdProcedimiento).HasColumnName("id_procedimiento").IsRequired();
            builder.Property(e => e.IdNormaInteres).HasColumnName("id_norma_interes").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Procedimiento).WithMany(b => b.ProcedimientoNormaInteres).HasForeignKey(c => c.IdProcedimiento);
            builder.HasOne(e => e.NormaInteres).WithMany(b => b.ProcedimientoNormaInteres).HasForeignKey(c => c.IdNormaInteres);
        }
    }
}
