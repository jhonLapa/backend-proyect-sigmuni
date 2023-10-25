using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class FichaBienCulturalMap : IEntityTypeConfiguration<FichaBienCultural>
    {
        public void Configure(EntityTypeBuilder<FichaBienCultural> builder)
        {
            builder.ToTable("ficha_bien_cultural","fic");
            builder.HasKey(t => t.IdFichaBienCultural);
            builder.Property(t => t.IdFichaBienCultural).HasColumnName("id_ficha_bien_cultural").IsRequired();
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.CUIDistrito).HasColumnName("cui_distrito").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CUISector).HasColumnName("cui_sector").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CUIManzana).HasColumnName("cui_manzana").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CUILote).HasColumnName("cui_lote").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CUISubLote).HasColumnName("cui_sub_lote").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CRCZona).HasColumnName("crc_zona").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CRCCoordenadaEsta).HasColumnName("crc_coordenada_esta").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CRCCoordenadaNorte).HasColumnName("crc_coordenada_norta").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.CRCUnidadCatastral).HasColumnName("crc_unidad_catastral").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.HasOne(e => e.Ficha).WithMany(b => b.FichaBienCulturales).HasForeignKey(c => c.IdFicha);

        }
    }
}
