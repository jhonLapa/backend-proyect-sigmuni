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
    public class ProcedimientoRequisitoMap : IEntityTypeConfiguration<ProcedimientoRequisito>
    {
        public void Configure(EntityTypeBuilder<ProcedimientoRequisito> builder)
        {
            builder.ToTable("procedimiento_requisito","trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_procedimiento_requisito");
            builder.Property(e => e.IdProcedimiento).HasColumnName("id_procedimiento");
            builder.Property(e => e.IdRequisito).HasColumnName("id_requisito");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.HasOne(e => e.Procedimiento).WithMany(b => b.ProcedimientoRequisito).HasForeignKey(c => c.IdProcedimiento);
            builder.HasOne(e => e.Requisito).WithMany(b => b.ProcedimientoRequisito).HasForeignKey(c => c.IdRequisito);
        }
    }
}
