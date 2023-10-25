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
    public class ResolucionMap : IEntityTypeConfiguration<Resolucion>
    {
        public void Configure(EntityTypeBuilder<Resolucion> builder)
        {
            builder.ToTable("resolucion", "loc");
            builder.HasKey(t => t.IdResolucion);
            builder.Property(t => t.IdResolucion).HasColumnName("id_resolucion").UseIdentityAlwaysColumn();
            builder.Property(e => e.NumeroResolucion).HasColumnName("num_resolucion").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Anio).HasColumnName("anio").IsUnicode(false).HasMaxLength(4);
            builder.Property(e => e.NumeroPlano).HasColumnName("num_plano").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdTipoResolucion).HasColumnName("id_tipo_resolucion");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.Resoluciones).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoResolucion).WithMany(b => b.Resoluciones).HasForeignKey(c => c.IdTipoResolucion);
        }
    }
}
