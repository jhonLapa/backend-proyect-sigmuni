using System;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ArchivoDocumentario
{
    public class MarcadorMap : IEntityTypeConfiguration<Marcador>
    {
        public void Configure(EntityTypeBuilder<Marcador> builder)
        {
            builder.ToTable("marcador", "doc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_marcador").UseIdentityAlwaysColumn();
            builder.Property(t => t.Pagina).HasColumnName("pagina");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.IdExpediente).HasColumnName("id_expediente");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Expediente).WithMany(b => b.Marcador).HasForeignKey(c => c.IdExpediente);
        }
    }
}
