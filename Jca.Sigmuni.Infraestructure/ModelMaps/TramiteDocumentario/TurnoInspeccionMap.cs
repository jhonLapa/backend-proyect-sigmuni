using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class TurnoInspeccionMap : IEntityTypeConfiguration<TurnoInspeccion>
    {
        public void Configure(EntityTypeBuilder<TurnoInspeccion> builder)
        {
            builder.ToTable("turno_inspeccion", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_turno_inspeccion").IsRequired();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsRequired().HasMaxLength(2);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsRequired();
            builder.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            builder.Property(e => e.HoraFin).HasColumnName("hora_fin");
            builder.Property(e => e.Orden).HasColumnName("orden");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado").IsRequired();
        }
    }
}
