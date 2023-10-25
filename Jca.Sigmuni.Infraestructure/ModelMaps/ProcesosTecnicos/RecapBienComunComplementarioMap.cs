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
    internal class RecapBienComunComplementarioMap : IEntityTypeConfiguration<RecapBienComunComplementario>
    {
        public void Configure(EntityTypeBuilder<RecapBienComunComplementario> builder)
        {
            builder.ToTable("recap_bbcc_compl", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_recap_bbcc_compl").UseIdentityAlwaysColumn();
            builder.Property(e => e.AnchoPasaje).HasColumnName("ancho_pasaje").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Distancia).HasColumnName("distancia").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.RecapBienComunComplementarios).HasForeignKey(c => c.IdFicha);
        }
    }
}
