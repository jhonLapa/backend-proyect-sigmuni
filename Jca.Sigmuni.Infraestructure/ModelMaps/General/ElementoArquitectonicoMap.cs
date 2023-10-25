using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class ElementoArquitectonicoMap : IEntityTypeConfiguration<ElementoArquitectonico>
    {
        public void Configure(EntityTypeBuilder<ElementoArquitectonico> builder)
        {
            builder.ToTable("elemento_arquitectonico","loc");
            builder.HasKey(t => t.IdElementoArquitectonico);
            builder.Property(t => t.IdElementoArquitectonico).HasColumnName("id_elemento_arquitectonico");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
