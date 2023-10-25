using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("perfil", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_perfil");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Etiqueta).HasColumnName("etiqueta");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}