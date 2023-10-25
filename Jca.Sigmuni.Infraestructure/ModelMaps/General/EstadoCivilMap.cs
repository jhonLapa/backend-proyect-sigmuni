using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class EstadoCivilMap : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.ToTable("estado_civil", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_estado_civil").IsRequired();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
