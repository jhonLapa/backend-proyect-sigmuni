using Jca.Sigmuni.Domain.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Admins
{
    public class AreaCargoMap : IEntityTypeConfiguration<AreaCargo>
    {
        public void Configure(EntityTypeBuilder<AreaCargo> builder)
        {
            builder.ToTable("area_cargo", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_area_cargo");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdArea).HasColumnName("id_area");
            builder.Property(e => e.IdCargo).HasColumnName("id_cargo");

            builder.HasOne(e => e.Area).WithMany(b => b.AreaCargos).HasForeignKey(c => c.IdArea);
            builder.HasOne(e => e.Cargo).WithMany(b => b.AreaCargos).HasForeignKey(c => c.IdCargo);
        }
    }
}

