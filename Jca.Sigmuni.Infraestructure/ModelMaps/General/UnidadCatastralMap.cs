using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class UnidadCatastralMap : IEntityTypeConfiguration<UnidadCatastral>
    {
        public void Configure(EntityTypeBuilder<UnidadCatastral> builder)
        {
            builder.ToTable("unidad_catastral", "loc");
            builder.HasKey(t => t.IdUnidadCatastral);

            builder.Property(e => e.IdUnidadCatastral).HasColumnName("id_unidad_catastral");
            builder.Property(e => e.CodigoCatastral).HasColumnName("codigo_catastral").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodigoHojaCatastral).HasColumnName("codigo_hoja_catastral").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodigoPredialSat).HasColumnName("codigo_predial_sat").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Correlativo).HasColumnName("correlativo").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdMotivo).HasColumnName("id_motivo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.CodigoRefCatastral).HasColumnName("codigo_ref_catastral");
            builder.Property(e => e.UnidadAcumuladaCodigo).HasColumnName("unid_acum_cod");
            builder.Property(e => e.Ambito).HasColumnName("ambito");
            builder.Property(e => e.IdLoteCarto).HasColumnName("id_lote_carto");
            builder.Property(e => e.AnioUltimoDDJJ).HasColumnName("anio_ultimo_ddjj");
            builder.Property(e => e.Cuc).HasColumnName("cuc");

            //builder.HasOne(e => e.Motivo).WithMany(b => b.UnidadCatastral).HasForeignKey(c => c.IdMotivo);
            builder.HasOne(e => e.Lote).WithMany(b => b.UnidadCatastral).HasForeignKey(c => c.IdLoteCarto);







        }
    }
}
