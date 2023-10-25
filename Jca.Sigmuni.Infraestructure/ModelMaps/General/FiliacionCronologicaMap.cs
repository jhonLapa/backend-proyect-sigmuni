using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class FiliacionCronologicaMap : IEntityTypeConfiguration<FiliacionCronologica>
    {
        public void Configure(EntityTypeBuilder<FiliacionCronologica> builder)
        {
            builder.ToTable("filiacion_cronologica", "loc");
            builder.HasKey(t => t.IdFiliacionCronologica);
            builder.Property(t => t.IdFiliacionCronologica).HasColumnName("id_filiacion_cronologica");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
