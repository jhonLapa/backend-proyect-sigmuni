using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class UitMap : IEntityTypeConfiguration<Uit>
    {
        public void Configure(EntityTypeBuilder<Uit> builder)
        {
            builder.ToTable("uit", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_uit");
            builder.Property(e => e.Monto).HasColumnName("monto");
            builder.Property(e => e.Porcentaje).HasColumnName("porcentaje");
            builder.Property(e => e.AnioUit).HasColumnName("anio_uit");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}

