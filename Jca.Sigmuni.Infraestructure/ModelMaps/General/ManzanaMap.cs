using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class ManzanaMap : IEntityTypeConfiguration<Manzana>
    {
        public void Configure(EntityTypeBuilder<Manzana> builder)
        {
            builder.ToTable("manzana", "loc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_manzana");
            builder.Property(e => e.Codigo).HasColumnName("codi_mzna").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Mantenimiento).HasColumnName("mantenimiento").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Editor).HasColumnName("editor").IsUnicode(false).HasMaxLength(100);
           
            builder.Property(e => e.Observacion).HasColumnName("observacion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.IdSectorCarto).HasColumnName("id_sector_carto");
          
            builder.Property(e => e.AreaGrafica).HasColumnName("area_grafica");

            builder.HasOne(e => e.Sector).WithMany(b => b.Manzana).HasForeignKey(c => c.IdSectorCarto);

        }
    }
}
