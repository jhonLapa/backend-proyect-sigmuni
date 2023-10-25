using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class UcaMap : IEntityTypeConfiguration<Uca>
    {
        public void Configure(EntityTypeBuilder<Uca> builder)
        {
            builder.ToTable("uca", "fic");
            builder.HasKey(t => t.IdUca);
            builder.Property(t => t.IdUca).HasColumnName("id_uca").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
