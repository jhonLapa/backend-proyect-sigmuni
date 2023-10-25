using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.CompendioNormas
{
    public class NormaInteresMenuMap : IEntityTypeConfiguration<NormaInteresMenu>
    {
        public void Configure(EntityTypeBuilder<NormaInteresMenu> builder)
        {
            builder.ToTable("norma_interes_menu", "ni");
            builder.HasKey(t => t.IdNormaInteresMenu);
            builder.Property(t => t.IdNormaInteresMenu).HasColumnName("id_norma_interes_menu");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.IdNormaInteres).HasColumnName("id_norma_interes");
            builder.Property(t => t.IdMenu).HasColumnName("id_menu");

            builder.HasOne(e => e.Menu).WithMany(b => b.NormaInteresMenus).HasForeignKey(c => c.IdMenu);

        }
    }
}
