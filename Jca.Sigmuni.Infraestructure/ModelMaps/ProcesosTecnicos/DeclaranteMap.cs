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
    public class DeclaranteMap : IEntityTypeConfiguration<Declarante>
    {
        public void Configure(EntityTypeBuilder<Declarante> builder)
        {
            builder.ToTable("declarante", "fic");
            builder.HasKey(t => t.IdDeclarante);
            builder.Property(e => e.IdDeclarante).HasColumnName("id_declarante").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdCondicionPer).HasColumnName("id_condicion_per");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.Firma).HasColumnName("firma");
            builder.Property(e => e.TieneFirma).HasColumnName("tiene_firma");

            builder.HasOne(e => e.CondicionPer).WithMany(b => b.Declarantes).HasForeignKey(c => c.IdCondicionPer);
            builder.HasOne(e => e.Persona).WithMany(b => b.Declarantes).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.Ficha).WithMany(b => b.Declarantes).HasForeignKey(c => c.IdFicha);
        }
    }
}
