using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class DependienteMap : IEntityTypeConfiguration<Dependiente>
    {
        public void Configure(EntityTypeBuilder<Dependiente> builder)
        {
            builder.ToTable("dependiente", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_dependiente").UseIdentityAlwaysColumn();
            builder.Property(e => e.Relacion).HasColumnName("relacion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.IdTitularCatastral).HasColumnName("id_titular_catastral");
            builder.Property(e => e.IdLitigante).HasColumnName("id_litigante");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Persona).WithMany(b => b.Dependientes).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.Litigante).WithMany(b => b.Dependientes).HasForeignKey(c => c.IdLitigante);
            builder.HasOne(e => e.TitularCatastral).WithMany(b => b.Dependientes).HasForeignKey(c => c.IdTitularCatastral);
        }
    }
}
