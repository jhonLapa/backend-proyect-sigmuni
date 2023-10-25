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
    public class PuertaMap : IEntityTypeConfiguration<Puerta>
    {
        public void Configure(EntityTypeBuilder<Puerta> builder)
        {
            builder.ToTable("puerta", "loc");
            builder.HasKey(t => t.IdPuerta);
            builder.Property(t => t.IdPuerta).HasColumnName("id_puerta").UseIdentityAlwaysColumn();
            builder.Property(e => e.CodigoPuerta).HasColumnName("codigo_puerta").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.NumeracionMunicipal).HasColumnName("nume_muni").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdTipoPuerta).HasColumnName("id_tipo_puerta");
            builder.Property(e => e.IdVia).HasColumnName("id_via");
            builder.Property(e => e.IdLoteCartografia).HasColumnName("id_lote_carto").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdUbicacionPredio).HasColumnName("id_ubicacion");
            builder.Property(e => e.IdCondNumPrincipal).HasColumnName("id_cond_principal");
            builder.Property(e => e.IdCondNumSecundario).HasColumnName("id_cond_secundaria");
            builder.Property(e => e.IdTipoNumPrincipal).HasColumnName("id_tipo_num_princ");
            builder.Property(e => e.IdTipoNumSecundario).HasColumnName("id_tipo_num_secun");
            builder.Property(e => e.LtPrincipal).HasColumnName("lt_principal").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.LtScundario).HasColumnName("lt_secundario").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdUbicacionNumeracion).HasColumnName("id_ubicacion_numeracion");
            builder.Property(e => e.NumCertifPrincipal).HasColumnName("num_cert_principal").IsUnicode(false).HasMaxLength(100); ;
            builder.Property(e => e.NumCertifSecundario).HasColumnName("num_cert_secundario").IsUnicode(false).HasMaxLength(100); ;
            builder.Property(e => e.AnioPrincipal).HasColumnName("anio_principal");
            builder.Property(e => e.AnioSecundario).HasColumnName("anio_secundario");
            builder.Property(e => e.NumeroInterior).HasColumnName("num_interior").IsUnicode(false).HasMaxLength(50); ;
            builder.Property(e => e.IdTipoInterior).HasColumnName("id_tipo_interior");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.TipoPuerta).WithMany(b => b.Puertas).HasForeignKey(c => c.IdTipoPuerta);
            builder.HasOne(e => e.UbicacionPredio).WithMany(b => b.Puertas).HasForeignKey(c => c.IdUbicacionPredio);
            builder.HasOne(e => e.TipoInterior).WithMany(b => b.Puertas).HasForeignKey(c => c.IdTipoInterior);
            builder.HasOne(e => e.Via).WithMany(b => b.Puertas).HasForeignKey(c => c.IdVia);
            builder.HasOne(e => e.CondicionNumeracion).WithMany(b => b.Puertas).HasForeignKey(c => c.IdCondNumPrincipal);
        }
    }
}
