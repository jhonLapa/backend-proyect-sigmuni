using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class TblCodigoMap : IEntityTypeConfiguration<TblCodigo>
    {
        public void Configure(EntityTypeBuilder<TblCodigo> builder)
        {
            builder.ToTable("tbl_codigo", "loc");
            builder.HasKey(t => t.IdTblCodigo);
            builder.Property(t => t.IdTblCodigo).HasColumnName("id_tbl_codigo");
            builder.Property(e => e.CodDepartamento).HasColumnName("cod_departamento").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.CodProvincia).HasColumnName("cod_provincia").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.CodDistrito).HasColumnName("cod_distrito").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodSector).HasColumnName("cod_sector").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodManzana).HasColumnName("cod_manzana").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodLote).HasColumnName("cod_lote").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodEdif).HasColumnName("cod_edif").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.CodEnt).HasColumnName("cod_ent");
            builder.Property(e => e.CodPiso).HasColumnName("cod_piso");
            builder.Property(e => e.CodUnid).HasColumnName("cod_unid");
            builder.Property(e => e.DigitoControl).HasColumnName("digito_control");
            builder.Property(e => e.FlagTipo).HasColumnName("flag_tipo");
            builder.Property(e => e.IdUnidadCatastral).HasColumnName("id_unidad_catastral");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Estado).HasColumnName("estado").IsUnicode(false).HasMaxLength(100);

            

            builder.HasOne(e => e.UnidadCatastral).WithMany(b => b.TblCodigo).HasForeignKey(c => c.IdUnidadCatastral);

         
        }
    }
}
