using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.PadronNumeraciones.Numeraciones
{
    public class CertificadoMap : IEntityTypeConfiguration<Certificado>
    {
        public void Configure(EntityTypeBuilder<Certificado> builder)
        {
            builder.ToTable("certificado", "cer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_certificado").UseIdentityAlwaysColumn();
            builder.Property(t => t.NumCertificadoExterior).HasColumnName("num_certificado_exterior");
            builder.Property(t => t.AnioCertificadoExterior).HasColumnName("anio_certificado_exterior");
            builder.Property(t => t.NumCertificadoInterior).HasColumnName("num_certificado_interior");
            builder.Property(t => t.AnioCertificadoInterior).HasColumnName("anio_certificado_interior");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
