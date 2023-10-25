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
    public class LitiganteMap : IEntityTypeConfiguration<Litigante>
    {
        public void Configure(EntityTypeBuilder<Litigante> builder)
        {
            builder.ToTable("litigante", "fic");
            builder.HasKey(t => t.IdLitigante);
            builder.Property(t => t.IdLitigante).HasColumnName("id_litigante").UseIdentityAlwaysColumn();
            builder.Property(e => e.CodigoContribuyente).HasColumnName("cod_contribuyente").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.IdFicha).HasColumnName("ficha_id_ficha").IsRequired();
            builder.Property(e => e.CondLitigante).HasColumnName("cod_litigante").IsUnicode(false).HasMaxLength(45);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Persona).WithMany(b => b.Litigantes).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.Ficha).WithMany(b => b.Litigantes).HasForeignKey(c => c.IdFicha);
        }
    }
}
