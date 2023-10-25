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
    public class RecapitulacionEdificioMap : IEntityTypeConfiguration<RecapitulacionEdificio>
    {
        public void Configure(EntityTypeBuilder<RecapitulacionEdificio> builder)
        {
            builder.ToTable("recap_edificio", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_recap_edificio").UseIdentityAlwaysColumn();
            builder.Property(e => e.Edificio).HasColumnName("edificio").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.TotalPorcentaje).HasColumnName("total_porc");
            builder.Property(e => e.TotalAtc).HasColumnName("total_atc");
            builder.Property(e => e.TotalAcc).HasColumnName("total_acc");
            builder.Property(e => e.TotalAoic).HasColumnName("total_aoic");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.RecapitulacionEdificios).HasForeignKey(c => c.IdFicha);
        }
    }
}
