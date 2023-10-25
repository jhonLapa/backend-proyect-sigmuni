using Jca.Sigmuni.Domain.Admins;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Admins
{
    public class MenuMap: IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("menu", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_menu");
            builder.Property(t => t.Id_menu_padre).HasColumnName("id_menu_padre");
            builder.Property(e => e.Nombre).HasColumnName("nombre").IsUnicode(false).HasMaxLength(500);
            builder.Property(t => t.Orden).HasColumnName("orden");
            builder.Property(t => t.Nivel).HasColumnName("nivel");
            builder.Property(e => e.Icono).HasColumnName("icono");
            builder.Property(e => e.url_menu).HasColumnName("url_menu").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Visible).HasColumnName("visible");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
