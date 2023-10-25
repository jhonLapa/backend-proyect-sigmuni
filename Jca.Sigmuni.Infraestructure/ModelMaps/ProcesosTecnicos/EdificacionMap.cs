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
    public class EdificacionMap : IEntityTypeConfiguration<Edificacion>
    {
        public void Configure(EntityTypeBuilder<Edificacion> builder)
        {
            builder.ToTable("edificacion", "loc");
            builder.HasKey(t => t.IdEdificacion);
            builder.Property(t => t.IdEdificacion).HasColumnName("id_edificacion").UseIdentityAlwaysColumn();
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Manzana).HasColumnName("manzana").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.NumLote).HasColumnName("num_lote").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.LoteUrbano).HasColumnName("lote_urbano").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.SubLote).HasColumnName("sub_lote").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.IdTipoEdificacion).HasColumnName("id_tipo_edificacion");
            builder.Property(e => e.IdTipoAgrupacion).HasColumnName("id_tipo_agrupacion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.TipoAgrupacion).WithMany(b => b.Edificaciones).HasForeignKey(c => c.IdTipoAgrupacion);
            builder.HasOne(e => e.TipoEdificacion).WithMany(b => b.Edificaciones).HasForeignKey(c => c.IdTipoEdificacion);
        }
    }
}
