using Jca.Sigmuni.Domain.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Admins
{
    public class DomicilioMap : IEntityTypeConfiguration<Domicilio>
    {
        public void Configure(EntityTypeBuilder<Domicilio> builder) 
        {
            builder.ToTable("domicilio","adm");
            builder.HasKey(t => t.IdDomicilio);
            builder.Property(t => t.IdDomicilio).HasColumnName("id_domicilio").IsRequired();
            builder.Property(e => e.NumMunicipal).HasColumnName("num_municipal").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.LtPrincipal).HasColumnName("lt_principal").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.LtSecundario).HasColumnName("lt_secundario").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.IdTipoInterior).HasColumnName("id_tipo_interior");
            builder.Property(e => e.NumInterior).HasColumnName("num_interior").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.LtInterior).HasColumnName("lt_interior").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdEdificacion).HasColumnName("id_edificacion");
            builder.Property(e => e.CasillaPostal).HasColumnName("casilla_postal").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdTipoVia).HasColumnName("id_tipo_via");
            builder.Property(e => e.IdVia).HasColumnName("id_via");
            builder.Property(e => e.NombreVia).HasColumnName("nombre_via").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.IdTipoHU).HasColumnName("id_tipo_hu");
            
            builder.Property(e => e.NombreHU).HasColumnName("nombre_habilitacion_urbana").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.IdDenominacionInterior).HasColumnName("id_denominacion_interior");
            builder.Property(e => e.IdLoteCarto).HasColumnName("id_lote_carto").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.Manzana).HasColumnName("manzana").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdPuerta).HasColumnName("id_puerta");
            builder.Property(e => e.IdHabilitacionUrbana).HasColumnName("id_habilitacion_urbana");

            builder.HasOne(e => e.HabilitacionUrbana).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdHabilitacionUrbana);
            builder.HasOne(e => e.Edificacion).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdEdificacion);
            builder.HasOne(e => e.Persona).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.TipoInterior).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdTipoInterior);
            builder.HasOne(e => e.Via).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdVia);
            builder.HasOne(e => e.Ubigeo).WithMany(b => b.Domicilios).HasForeignKey(c => c.CodigoUbigeo);
           // builder.HasOne(e => e.DenominacionInterior).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdDenominacionInterior);
            builder.HasOne(e => e.TipoVia).WithMany(b => b.Domicilios).HasForeignKey(c => c.IdTipoVia);
           // builder.HasOne(e => e.TipoHabilitacionUrbana).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdTipoHabilitacionUrbana);
            builder.HasOne(e => e.Lote).WithMany(b => b.Domicilios).HasForeignKey(c => c.IdLoteCarto);
            builder.HasOne(e => e.Puerta).WithMany(b => b.Domicilio).HasForeignKey(c => c.IdPuerta);

        }
    }
}
