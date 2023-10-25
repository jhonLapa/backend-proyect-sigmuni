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
    public class FichaDocumentoMap : IEntityTypeConfiguration<FichaDocumento>
    {
        public void Configure(EntityTypeBuilder<FichaDocumento> builder)
        {
            builder.ToTable("ficha_documento", "fic");
            builder.HasKey(t => t.IdFichaDocumento);
            builder.Property(t => t.IdFichaDocumento).HasColumnName("id_ficha_documento").UseIdentityAlwaysColumn();
            builder.Property(e => e.NumeroDocumento).HasColumnName("num_documento").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.IdArea).HasColumnName("id_area");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            builder.Property(e => e.TotalArea).HasColumnName("total_area");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Area).WithMany(b => b.FichaDocumentos).HasForeignKey(c => c.IdArea);
            builder.HasOne(e => e.Ficha).WithMany(b => b.FichaDocumentos).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoDocumentoPresentado).WithMany(b => b.FichaDocumentos).HasForeignKey(c => c.IdTipoDocumento);
        }
    }
}
