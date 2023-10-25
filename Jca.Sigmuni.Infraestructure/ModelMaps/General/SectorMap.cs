using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class SectorMap : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("sector", "loc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_sector");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(20);
             builder.Property(e => e.AreaGrafica).HasColumnName("area_grafica");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo");


            builder.HasOne(e => e.Ubigeo).WithMany(b => b.Sector).HasForeignKey(c => c.CodigoUbigeo);


        }
    }
}
