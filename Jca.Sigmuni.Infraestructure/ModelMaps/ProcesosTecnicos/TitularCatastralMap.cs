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
    public class TitularCatastralMap : IEntityTypeConfiguration<TitularCatastral>
    {
        public void Configure(EntityTypeBuilder<TitularCatastral> builder)
        {
            builder.ToTable("titular_catastral", "fic");
            builder.HasKey(t => t.IdTitularCatastral);
            builder.Property(t => t.IdTitularCatastral).HasColumnName("id_titular_catastral").IsRequired();
            builder.Property(e => e.IdPersona).HasColumnName("id_pesona");
            builder.Property(e => e.IdDomicilio).HasColumnName("id_domicilio");
            builder.Property(e => e.IdCaracteristicaTitularidad).HasColumnName("id_caracteristica_titularidad");
            builder.Property(e => e.IdCondicionPer).HasColumnName("id_condicion_per");
            builder.Property(e => e.CodContribuyente).HasColumnName("codi_contribuyente");
            builder.Property(e => e.Asociacion).HasColumnName("asociacion");
            builder.Property(e => e.NumTitularidad).HasColumnName("nume_titular");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();

            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Persona).WithMany(b => b.TitularCatastral).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.CaracteristicaTitularidad).WithMany(b => b.TitularCatastrales).HasForeignKey(c => c.IdCaracteristicaTitularidad);
            builder.HasOne(e => e.CondicionPer).WithMany(b => b.TitularCatastral).HasForeignKey(c => c.IdCondicionPer);
            builder.HasOne(e => e.Ficha).WithMany(b => b.TitularCatastral).HasForeignKey(c => c.IdFicha);

        }
    }
}
