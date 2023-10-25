using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class PredioCatastralEnMap : IEntityTypeConfiguration<PredioCatastralEn>
    {
        public void Configure(EntityTypeBuilder<PredioCatastralEn> builder)
        {
            builder.ToTable("predio_catastral_en", "fic");
            builder.HasKey(t => t.IdPredioCatastralEn);
            builder.Property(t => t.IdPredioCatastralEn).HasColumnName("id_predio_catastral_en").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
