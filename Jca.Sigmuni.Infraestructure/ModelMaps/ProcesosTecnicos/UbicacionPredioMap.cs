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
    public class UbicacionPredioMap : IEntityTypeConfiguration<UbicacionPredio>
    {
        public void Configure(EntityTypeBuilder<UbicacionPredio> builder)
        {
            builder.ToTable("ubicacion_predio", "loc");
            builder.HasKey(t => t.IdUbicacionPredio);
            builder.Property(t => t.IdUbicacionPredio).HasColumnName("id_ubicacion_predio").UseIdentityAlwaysColumn();
            builder.Property(e => e.DenominacionPredio).HasColumnName("denominacion_predio");
            builder.Property(t => t.IdEdificacion).HasColumnName("id_edificacion");
            builder.Property(e => e.IdHabilitacionUrbana).HasColumnName("id_habilitacion");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Edificacion).WithMany(b => b.UbicacionPredios).HasForeignKey(c => c.IdEdificacion);
            builder.HasOne(e => e.Ficha).WithMany(b => b.UbicacionPredios).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.HabilitacionUrbana).WithMany(b => b.UbicacionPredios).HasForeignKey(c => c.IdHabilitacionUrbana);
        }
    }
}
