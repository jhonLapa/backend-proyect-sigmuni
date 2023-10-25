using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class CategoriaOrganizacionMap : IEntityTypeConfiguration<CategoriaOrganizacion>
    {
        public void Configure(EntityTypeBuilder<CategoriaOrganizacion> builder)
        {
            builder.ToTable("categoria_organizacion", "loc");
            builder.HasKey(t => t.IdCategoriaOrganizacion);
            builder.Property(t => t.IdCategoriaOrganizacion).HasColumnName("id_categoria_organizacion");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Estado).HasColumnName("estado").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdTipoPersona).HasColumnName("id_tipo_persona").IsUnicode(false).HasMaxLength(100);
            

            builder.HasOne(e => e.TipoPersona).WithMany(b => b.CategoriaOrganizacion).HasForeignKey(c => c.IdTipoPersona);

            //builder.HasMany(e => e.Persona).WithOne(b => b.CategoriaOrganizacion).HasForeignKey(c => c.);
           
        }
    }
}
