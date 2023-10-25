using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class TipoArquitecturaMap : IEntityTypeConfiguration<TipoArquitectura>
    {
        public void Configure(EntityTypeBuilder<TipoArquitectura> builder)
        {
            builder.ToTable("tipo_arquitectura", "loc");
            builder.HasKey(t => t.IdTipoArquitectura);
            builder.Property(t => t.IdTipoArquitectura).HasColumnName("id_tipo_arquitectura");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Grupo).HasColumnName("grupo");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
