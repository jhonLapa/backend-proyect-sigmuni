using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.CompendioNormas
{
    public class NormaDiaDetalleMap : IEntityTypeConfiguration<NormaDiaDetalle>
    {
        public void Configure(EntityTypeBuilder<NormaDiaDetalle> builder)
        {
            builder.ToTable("norma_dia_detalle", "ni");
            builder.HasKey(t => t.IdNormaDiaDetalle);
            builder.Property(t => t.IdNormaDiaDetalle).HasColumnName("id_norma_dia_detalle");
            builder.Property(t => t.Nombre).HasColumnName("nombre");
            builder.Property(t => t.Sumilla).HasColumnName("sumilla");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(t => t.IdNormaDia).HasColumnName("id_norma_dia");
            builder.Property(e => e.FlagNotificacion).HasColumnName("flag_notificacion");
            builder.Property(t => t.IdAutoridad).HasColumnName("id_autoridad");
            builder.Property(t => t.Enlace).HasColumnName("enlace");
        }
    }
}
