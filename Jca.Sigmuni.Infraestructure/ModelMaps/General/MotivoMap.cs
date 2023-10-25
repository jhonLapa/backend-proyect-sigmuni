using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class MotivoMap : IEntityTypeConfiguration<Motivo>
    {
        public void Configure(EntityTypeBuilder<Motivo> builder)
        {
            builder.ToTable("motivo", "loc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_motivo");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Grupo).HasColumnName("grupo").IsUnicode(false).HasMaxLength(45);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}

