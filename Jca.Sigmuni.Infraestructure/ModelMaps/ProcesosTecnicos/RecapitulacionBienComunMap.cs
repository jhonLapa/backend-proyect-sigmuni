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
    internal class RecapitulacionBienComunMap : IEntityTypeConfiguration<RecapitulacionBienComun>
    {
        public void Configure(EntityTypeBuilder<RecapitulacionBienComun> builder)
        {
            builder.ToTable("recap_bbcc", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_recap_bbcc").UseIdentityAlwaysColumn();
            builder.Property(e => e.Numero).HasColumnName("numero").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Edificacion).HasColumnName("edificacion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Entrada).HasColumnName("entrata").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Piso).HasColumnName("piso").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Unidad).HasColumnName("unidad").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Porcentaje).HasColumnName("porcentaje");
            builder.Property(e => e.LegalTerreno).HasColumnName("lega_terreno");
            builder.Property(e => e.LegalConstruccion).HasColumnName("lega_construccion");
            builder.Property(e => e.FisicoTerreno).HasColumnName("fisico_terreno");
            builder.Property(e => e.FisicoConstruccion).HasColumnName("fisico_construccion");
            builder.Property(e => e.Atc).HasColumnName("atc");
            builder.Property(e => e.Acc).HasColumnName("acc");
            builder.Property(e => e.Aoic).HasColumnName("aoic");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.RecapitulacionBienComunes).HasForeignKey(c => c.IdFicha);
        }
    }
}
