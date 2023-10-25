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
    public class InformeTecnicoMap : IEntityTypeConfiguration<InformeTecnico>
    {
        public void Configure(EntityTypeBuilder<InformeTecnico> builder)
        {
            builder.ToTable("informe_tecnico", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_informe_tecnico");
            builder.Property(e => e.NumCorrelativo).HasColumnName("num_correlativo").HasMaxLength(20);
            builder.Property(e => e.FechaInforme).HasColumnName("fecha_informe");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdEspecialista).HasColumnName("id_especialista");
            builder.Property(e => e.IdTipoInforme).HasColumnName("id_tipo_informe");
            builder.Property(e => e.JsonDatosSolicitud).HasColumnName("json_datos_solicitud").HasColumnType("NCLOB");
            builder.Property(e => e.JsonNumeracion).HasColumnName("json_numeracion").HasColumnType("NCLOB");
            builder.Property(e => e.JsonZonificacion).HasColumnName("json_zonificacion").HasColumnType("NCLOB");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.EsInforme).HasColumnName("es_informe");


            builder.HasOne(e => e.Solicitud).WithMany(b => b.InformeTecnico).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.Especialista).WithMany(b => b.InformeTecnico).HasForeignKey(c => c.IdEspecialista);
            builder.HasOne(e => e.TipoInforme).WithMany(b => b.InformeTecnico).HasForeignKey(c => c.IdTipoInforme);
        }
    }
}
