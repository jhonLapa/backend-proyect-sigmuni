using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class CondicionEspecialPredioMap : IEntityTypeConfiguration<CondicionEspecialPredio>
    {
        public void Configure(EntityTypeBuilder<CondicionEspecialPredio> builder)
        {
            builder.ToTable("condicion_especial_predio", "fic");
            builder.HasKey(t => t.IdCondicionEspecialPredio);
            builder.Property(t => t.IdCondicionEspecialPredio).HasColumnName("id_condicion_especial_predio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Nombre).HasColumnName("nombre");
           
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
