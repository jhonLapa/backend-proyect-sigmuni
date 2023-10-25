using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class EstadoAcabadoMap : IEntityTypeConfiguration<EstadoAcabado>
    {
        public void Configure(EntityTypeBuilder<EstadoAcabado> builder)
        {
            builder.ToTable("estado_acabado","loc");
            builder.HasKey(t => t.IdEstadoAcabado);
            builder.Property(t => t.IdEstadoAcabado).HasColumnName("id_estado_acabado");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
