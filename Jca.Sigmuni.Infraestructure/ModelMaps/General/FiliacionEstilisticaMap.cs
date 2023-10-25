using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class FiliacionEstilisticaMap : IEntityTypeConfiguration<FiliacionEstilistica>
    {
        public void Configure(EntityTypeBuilder<FiliacionEstilistica> builder)
        {
            builder.ToTable("filiacion_estilistica","loc");
            builder.HasKey(t => t.IdFiliacionEstilistica);
            builder.Property(t => t.IdFiliacionEstilistica).HasColumnName("id_filiacion_estilistica");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
