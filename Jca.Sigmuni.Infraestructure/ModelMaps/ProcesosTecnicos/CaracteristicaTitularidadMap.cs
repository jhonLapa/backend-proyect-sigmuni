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
    public class CaracteristicaTitularidadMap : IEntityTypeConfiguration<CaracteristicaTitularidad>
    {
        public void Configure(EntityTypeBuilder<CaracteristicaTitularidad> builder)
        {
            builder.ToTable("caracteristica_titularidad", "fic");
            builder.HasKey(t => t.IdCaracteristicaTitularidad);
            builder.Property(t => t.IdCaracteristicaTitularidad).HasColumnName("id_caracteristica_titularidad").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdCondicionTitular).HasColumnName("id_condicion_titular");
            builder.Property(t => t.IdExoneracionPredio).HasColumnName("id_exoneracion_predio");
            builder.Property(t => t.IdFormaAdquisicion).HasColumnName("id_forma_adquisicion");
            builder.Property(t => t.CondicionTitularOtros).HasColumnName("condicion_titular_otros");
            builder.Property(t => t.FormaAdquisicionOtros).HasColumnName("forma_adquisicion_otros");
            builder.Property(t => t.PorcentajeTitularidad).HasColumnName("porcentaje_titularidad");
            builder.Property(t => t.FechaAdquisicion).HasColumnName("fecha_adquisicion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.CondicionTitular).WithMany(b => b.CaracteristicaTitularidades).HasForeignKey(c => c.IdCondicionTitular);
            builder.HasOne(e => e.FormaAdquisicion).WithMany(b => b.CaracteristicaTitularidades).HasForeignKey(c => c.IdFormaAdquisicion);
            builder.HasOne(e => e.ExoneracionPredio).WithMany(b => b.CaracteristicaTitularidades).HasForeignKey(c => c.IdExoneracionPredio);
        }
    }
}
