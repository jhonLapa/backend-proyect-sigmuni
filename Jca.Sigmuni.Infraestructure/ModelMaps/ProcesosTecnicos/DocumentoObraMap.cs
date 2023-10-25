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
    public class DocumentoObraMap : IEntityTypeConfiguration<DocumentoObra>
    {
        public void Configure(EntityTypeBuilder<DocumentoObra> builder)
        {
            builder.ToTable("documento_obra", "fic");
            builder.HasKey(t => t.IdDocumentoObra);
            builder.Property(t => t.IdDocumentoObra).HasColumnName("id_documento_obra").UseIdentityAlwaysColumn();
            builder.Property(e => e.NumeroDocumento).HasColumnName("num_documento").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.Piso).HasColumnName("piso").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.AreaAutorizada).HasColumnName("area_autorizada");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.IdTipoDocumentoObra).HasColumnName("id_tipo_documento_obra");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.DocumentoObras).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoDocumentoObra).WithMany(b => b.DocumentoObras).HasForeignKey(c => c.IdTipoDocumentoObra);
        }
    }
}
