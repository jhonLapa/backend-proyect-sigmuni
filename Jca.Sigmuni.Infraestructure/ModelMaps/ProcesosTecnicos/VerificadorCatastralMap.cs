using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    internal class VerificadorCatastralMap : IEntityTypeConfiguration<VerificadorCatastral>
    {
        public void Configure(EntityTypeBuilder<VerificadorCatastral> builder)
        {
            builder.ToTable("verificador", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_verificador").UseIdentityAlwaysColumn();
            builder.Property(e => e.IdCondicionPer).HasColumnName("id_condicion_per");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.NumeroRegistro).HasColumnName("numero_registro");
            builder.Property(e => e.TieneFirma).HasColumnName("tiene_firma");

            builder.HasOne(e => e.CondicionPer).WithMany(b => b.VerificadorCatastrales).HasForeignKey(c => c.IdCondicionPer);
            builder.HasOne(e => e.Persona).WithMany(b => b.VerificadorCatastrales).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.Ficha).WithMany(b => b.VerificadorCatastrales).HasForeignKey(c => c.IdFicha);
        }
    }
}
