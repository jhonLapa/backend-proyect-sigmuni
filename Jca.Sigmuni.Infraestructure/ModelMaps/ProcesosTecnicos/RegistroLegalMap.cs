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
    public class RegistroLegalMap : IEntityTypeConfiguration<RegistroLegal>
    {
        public void Configure(EntityTypeBuilder<RegistroLegal> builder)
        {
            builder.ToTable("registro_legal", "fic");
            builder.HasKey(t => t.IdRegistroLegal);
            builder.Property(t => t.IdRegistroLegal).HasColumnName("id_registro_legal").UseIdentityAlwaysColumn();
            builder.Property(e => e.Notaria).HasColumnName("notaria").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.Kardex).HasColumnName("kardex").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.FechaEscritura).HasColumnName("fecha_escritura");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.IdTipoDocNotarial).HasColumnName("id_tipo_doc_notarial").IsRequired(); ;
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.RegistroLegales).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoDocNotarial).WithMany(b => b.RegistroLegales).HasForeignKey(c => c.IdTipoDocNotarial);
        }
    }
}
