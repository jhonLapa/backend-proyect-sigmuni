using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class TecnicoCatastralMap : IEntityTypeConfiguration<TecnicoCatastral>
    {
        public void Configure(EntityTypeBuilder<TecnicoCatastral> builder)
        {
            builder.ToTable("tecnico_catastral", "ge");
            builder.HasKey(t => t.IdTecnicoCatastral);
            builder.Property(t => t.IdTecnicoCatastral).HasColumnName("id_tecnico_catastral");
            builder.Property(e => e.Fecha).HasColumnName("fecha").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdPersona).HasColumnName("id_persona").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Firma).HasColumnName("firma").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.TieneFirma).HasColumnName("tiene_firma").IsUnicode(false).HasMaxLength(100);


            builder.HasOne(e => e.Ficha).WithMany(b => b.TecnicoCatastrales).HasForeignKey(c => c.IdFicha);

            builder.HasOne(e => e.Persona).WithMany(b => b.TecnicoCatastrales).HasForeignKey(c => c.IdPersona);

        }
    }
}
