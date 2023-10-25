using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class FichaIndividualMap : IEntityTypeConfiguration<FichaIndividual>
    {
        public void Configure(EntityTypeBuilder<FichaIndividual> builder)
        {
            builder.ToTable("ficha_individual", "fic");
            builder.HasKey(t => t.IdFichaIndividual);
            builder.Property(t => t.IdFichaIndividual).HasColumnName("id_ficha_individual").UseIdentityAlwaysColumn();
            builder.Property(e => e.CodContRentas).HasColumnName("cod_cont_rentas").IsUnicode(false).HasMaxLength(15);
            builder.Property(e => e.CodPredRentas).HasColumnName("cod_pred_rentas").IsUnicode(false).HasMaxLength(15);
            builder.Property(e => e.UnidadPredRentas).HasColumnName("unidad_acum_rentas").IsUnicode(false).HasMaxLength(15);
            builder.Property(e => e.AreaTechadaLegal).HasColumnName("area_techada_legal");
            builder.Property(e => e.AreaOcupadaLegal).HasColumnName("area_ocupada_legal");
            builder.Property(e => e.AreaOcupadaVerif).HasColumnName("area_ocupada_verif");
            builder.Property(e => e.PorcBcGenLegal).HasColumnName("porc_bc_gen_legal");
            builder.Property(e => e.PorcBcLegalTerr).HasColumnName("porc_bc_legal_terr");
            builder.Property(e => e.PorcBcLegalConst).HasColumnName("porc_bc_legal_const");
            builder.Property(e => e.PorcBcFiscTerr).HasColumnName("porc_bc_fisc_terr");
            builder.Property(e => e.PorcBcFiscConst).HasColumnName("porc_bc_fisc_const");
            builder.Property(e => e.IdPredioCatastralAn).HasColumnName("id_predio_catastral_an");
            builder.Property(e => e.AreaHabActEcon).HasColumnName("area_hab_act_econ").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdTipoDeclaratoria).HasColumnName("id_tipo_declaratoria");

            builder.HasOne(e => e.Ficha).WithMany(b => b.FichaIndividuales).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.PredioCatastralAn).WithMany(b => b.FichaIndividuales).HasForeignKey(c => c.IdPredioCatastralAn);
            builder.HasOne(e => e.TipoDeclaratoria).WithMany(b => b.FichaIndividuales).HasForeignKey(c => c.IdTipoDeclaratoria);
        }
    }
}
