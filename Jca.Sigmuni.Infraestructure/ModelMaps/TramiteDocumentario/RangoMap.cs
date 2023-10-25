using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class RangoMap : IEntityTypeConfiguration<Rango>
    {
        public void Configure(EntityTypeBuilder<Rango> builder)
        {
            builder.ToTable("rango", "trd");
            builder.HasKey(t => t.IdRango);
            builder.Property(t => t.IdRango).HasColumnName("id_rango").UseIdentityAlwaysColumn();
            builder.Property(t => t.PrimeraCondicion).HasColumnName("primera_condicion");
            builder.Property(t => t.SegundaCondicion).HasColumnName("segunda_condicion");
            builder.Property(t => t.PrimerValor).HasColumnName("primer_valor");
            builder.Property(t => t.SegundoValor).HasColumnName("segundo_valor");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
