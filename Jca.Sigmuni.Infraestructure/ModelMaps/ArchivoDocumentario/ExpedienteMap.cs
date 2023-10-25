using System;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ArchivoDocumentario
{
    public class ExpedienteMap : IEntityTypeConfiguration<Expediente>
    {
        public void Configure(EntityTypeBuilder<Expediente> builder)
        {
            builder.ToTable("expediente", "doc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_expediente").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdDocumento).HasColumnName("id_documento");
            builder.Property(t => t.IdInfDocumento).HasColumnName("id_inf_documento");
            builder.Property(t => t.Folios).HasColumnName("folios");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.InfDocumento).WithMany(b => b.Expediente).HasForeignKey(c => c.IdInfDocumento);
            builder.HasOne(t => t.Documento).WithMany(b => b.Expediente).HasForeignKey(c => c.IdDocumento);


        }
    }
}
