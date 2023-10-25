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
    public class ConstruccionMap : IEntityTypeConfiguration<Construccion>
    {
        public void Configure(EntityTypeBuilder<Construccion> builder)
        {
            builder.ToTable("construccion", "fic");
            builder.HasKey(t => t.IdConstruccion);
            builder.Property(t => t.IdConstruccion).HasColumnName("id_construccion").UseIdentityAlwaysColumn();
            builder.Property(e => e.NumeroPiso).HasColumnName("nume_piso").IsUnicode(false).HasMaxLength(5);
            builder.Property(e => e.EstructuraMuroColumna).HasColumnName("estr_muro_col").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.EstructuraTecho).HasColumnName("estr_techo").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.AcabadoPiso).HasColumnName("acab_piso").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.AcabadoPuertaVentana).HasColumnName("acab_puerta_ven").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.AcabadoRevestimiento).HasColumnName("acab_revest").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.AcabadoBanio).HasColumnName("acab_bano").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.InstalacionElectricaSanitaria).HasColumnName("ins_elect_sanita").IsUnicode(false).HasMaxLength(1);
            builder.Property(e => e.AreaVerificada).HasColumnName("area_verificada");
            builder.Property(e => e.AreaTechadaDeclarada).HasColumnName("area_declarada");
            builder.Property(e => e.ValorUnitario).HasColumnName("valor_unitario");
            builder.Property(e => e.PorcentajeValorDepreciado).HasColumnName("porcentaje_valor_depreciado");
            builder.Property(e => e.ValorDepreciado).HasColumnName("valor_depreciado");
            builder.Property(e => e.PorcentajeAreaComun).HasColumnName("porcentaje_area_comun");
            builder.Property(e => e.ValorAreaComun).HasColumnName("valor_area_comun");
            builder.Property(e => e.ValorConstruccion).HasColumnName("valor_construccion");
            builder.Property(e => e.IdMep).HasColumnName("id_mep");
            builder.Property(e => e.IdEcs).HasColumnName("id_ecs");
            builder.Property(e => e.IdEcc).HasColumnName("id_ecc");
            builder.Property(e => e.IdUca).HasColumnName("id_uca");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.IdEd).HasColumnName("id_ed").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdEdificacionIndustrial).HasColumnName("id_edificacion_industrial");
            builder.Property(e => e.MesAnio).HasColumnName("fecha");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Mep).WithMany(b => b.Construcciones).HasForeignKey(c => c.IdMep);
            builder.HasOne(e => e.Ecs).WithMany(b => b.Construcciones).HasForeignKey(c => c.IdEcs);
            builder.HasOne(e => e.Ecc).WithMany(b => b.Construcciones).HasForeignKey(c => c.IdEcc);
            builder.HasOne(e => e.Uca).WithMany(b => b.Construcciones).HasForeignKey(c => c.IdUca);
            builder.HasOne(e => e.Ficha).WithMany(b => b.Construcciones).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.EdificacionIndustrial).WithMany(b => b.Construcciones).HasForeignKey(c => c.IdEdificacionIndustrial);
        }
    }
}
