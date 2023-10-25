using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class UsoPredioMap : IEntityTypeConfiguration<UsoPredio>
    {
        public void Configure(EntityTypeBuilder<UsoPredio> builder)
        {
            builder.ToTable("uso_predio", "fic");
            builder.HasKey(t => t.IdUsoPredio);
            builder.Property(t => t.IdUsoPredio).HasColumnName("id_uso_predio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
