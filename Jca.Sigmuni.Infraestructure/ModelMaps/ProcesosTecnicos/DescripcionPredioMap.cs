using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class DescripcionPredioMap : IEntityTypeConfiguration<DescripcionPredio>
    {
        public void Configure(EntityTypeBuilder<DescripcionPredio> builder)
        {
            builder.ToTable("descripcion_predio", "fic");
            builder.HasKey(t => t.IdDescripcionPredio);
            builder.Property(t => t.IdDescripcionPredio).HasColumnName("id_descripcion_predio").UseIdentityAlwaysColumn();
            builder.Property(t => t.Estructuracion).HasColumnName("estructuracion");
            builder.Property(t => t.Zonificacion).HasColumnName("zonificacion");
            builder.Property(t => t.AreaTitulo).HasColumnName("area_titulo");
            builder.Property(t => t.AreaLibre).HasColumnName("area_libre");
            builder.Property(t => t.AreaVerificada).HasColumnName("area_verificada");
            builder.Property(t => t.IdClasificacionPredio).HasColumnName("id_clasificacion_predio");
            builder.Property(t => t.IdUsoPredio).HasColumnName("id_uso_predio");
            builder.Property(t => t.IdPredioCatastralEn).HasColumnName("id_predio_catastral_en");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.ClasfDescOtros).HasColumnName("clasf_desc_otros");
            builder.Property(t => t.PredioCatOtros).HasColumnName("predio_cat_otros");
            builder.Property(t => t.UsoPredioOtros).HasColumnName("uso_predio_otros");
            builder.Property(t => t.AreaDeclarada).HasColumnName("area_declarada");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.ClasificacionPredio).WithMany(b => b.DescripcionPredios).HasForeignKey(c => c.IdClasificacionPredio);
            builder.HasOne(e => e.UsoPredio).WithMany(b => b.DescripcionPredios).HasForeignKey(c => c.IdUsoPredio);
            builder.HasOne(e => e.PredioCatastralEn).WithMany(b => b.DescripcionPredios).HasForeignKey(c => c.IdPredioCatastralEn);
            builder.HasOne(e => e.Ficha).WithMany(b => b.DescripcionPredios).HasForeignKey(c => c.IdFicha);
            builder.HasOne(a => a.LinderoPredio).WithOne(b => b.DescripcionPredio).HasForeignKey<LinderoPredio>(b => b.Id);
        }
    }
}
