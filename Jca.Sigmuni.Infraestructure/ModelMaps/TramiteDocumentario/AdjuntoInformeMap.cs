using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class AdjuntoInformeMap : IEntityTypeConfiguration<AdjuntoInforme>
    {
        public void Configure(EntityTypeBuilder<AdjuntoInforme> builder)
        {
            builder.ToTable("documento_informe", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_adjuntos_informes");
            builder.Property(e => e.IdInformeTecnico).HasColumnName("id_informe");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Documento).WithMany(b => b.AdjuntoInforme).HasForeignKey(c => c.IdDocumento);
            builder.HasOne(e => e.InformeTecnico).WithMany(b => b.AdjuntoInforme).HasForeignKey(c => c.IdInformeTecnico);
        }
    }
}