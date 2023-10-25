using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ErrorCartograficoSolicitudMap : IEntityTypeConfiguration<ErrorCartograficoSolicitud>
    {
        public void Configure(EntityTypeBuilder<ErrorCartograficoSolicitud> builder)
        {
            builder.ToTable("error_cartografico_solicitud", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_error_cartografico_solicitud");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.NroRevision).HasColumnName("nro_revision");
            builder.Property(e => e.Conformidad).HasColumnName("conformidad");
            builder.Property(e => e.Observacion).HasColumnName("observacion");
            builder.Property(e => e.flag).HasColumnName("flag");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

            builder.HasOne(e => e.Solicitud).WithMany(b => b.ErrorCartograficoSolicituds).HasForeignKey(c => c.IdSolicitud);


        }
    }
}