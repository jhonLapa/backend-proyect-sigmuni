using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class IntervencionInmuebleMap : IEntityTypeConfiguration<IntervencionInmueble>
    {
        public void Configure(EntityTypeBuilder<IntervencionInmueble> builder)
        {
            builder.ToTable("intervencion_inmueble","loc");
            builder.HasKey(t => t.IdIntervencionInmueble);
            builder.Property(t => t.IdIntervencionInmueble).HasColumnName("id_intervencion_inmueble");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
