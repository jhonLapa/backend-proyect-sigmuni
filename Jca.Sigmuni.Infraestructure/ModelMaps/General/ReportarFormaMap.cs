using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class ReportarFormaMap : IEntityTypeConfiguration<ReportarForma>
    {
        public void Configure(EntityTypeBuilder<ReportarForma> builder)
        {
            builder.ToTable("reportar_forma", "ge");
            builder.HasKey(t => t.IdReportarForma);
            builder.Property(t => t.IdReportarForma).HasColumnName("id_reportar_forma");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
