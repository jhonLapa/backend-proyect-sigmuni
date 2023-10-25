using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class CondicionAnuncioMap : IEntityTypeConfiguration<CondicionAnuncio>
    {
        public void Configure(EntityTypeBuilder<CondicionAnuncio> builder)
        {
            builder.ToTable("condicion_anuncio", "fic");
            builder.HasKey(t => t.IdCondicionAnuncio);
            builder.Property(t => t.IdCondicionAnuncio).HasColumnName("id_condicion_anuncio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
