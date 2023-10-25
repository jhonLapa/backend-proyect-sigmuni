using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class AntiguedadMap : IEntityTypeConfiguration<Antiguedad>
    {
        public void Configure(EntityTypeBuilder<Antiguedad> builder)
        {
            builder.ToTable("antiguedad", "fic");
            builder.HasKey(t => t.IdAntiguedad);
            builder.Property(t => t.IdAntiguedad).HasColumnName("id_antiguedad").IsRequired();
            builder.Property(e => e.PrimeraCondicion).HasColumnName("primera_condicion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.LimiteInferior).HasColumnName("limite_inferior");
            builder.Property(e => e.SegundaCondicion).HasColumnName("segunda_condicion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.LimiteSuperior).HasColumnName("limite_superior");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
