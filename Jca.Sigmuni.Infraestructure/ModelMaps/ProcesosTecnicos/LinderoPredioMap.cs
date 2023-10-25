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
    internal class LinderoPredioMap : IEntityTypeConfiguration<LinderoPredio>
    {
        public void Configure(EntityTypeBuilder<LinderoPredio> builder)
        {
            builder.ToTable("lindero_predio", "loc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_lindero_predio").UseIdentityAlwaysColumn();
            builder.Property(e => e.MedidaFrenteCampo).HasColumnName("frente_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaFrenteTitulo).HasColumnName("frente_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaFrenteCampo).HasColumnName("frente_colinda_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaFrenteTitulo).HasColumnName("frente_colinda_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaDerechaCampo).HasColumnName("derecha_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaDerechaTitulo).HasColumnName("derecha_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaDerechaCampo).HasColumnName("derecha_colinda_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaDerechaTitulo).HasColumnName("derecha_colinda_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaIzquierdaCampo).HasColumnName("izquierda_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaIzquierdaTitulo).HasColumnName("izquierda_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaIzquierdaCampo).HasColumnName("izquierda_colinda_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaIzquierdaTitulo).HasColumnName("izquierda_colinda_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaFondoCampo).HasColumnName("fondo_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.MedidaFondoTitulo).HasColumnName("fondo_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaFondoCampo).HasColumnName("fondo_colinda_campo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.ColindaFondoTitulo).HasColumnName("fondo_colinda_titulo").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
