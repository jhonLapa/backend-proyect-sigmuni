using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ActualizacionCartograficoMap : IEntityTypeConfiguration<ActualizacionCartografico>
    {
        public void Configure(EntityTypeBuilder<ActualizacionCartografico> builder)
        {
            builder.ToTable("actualizacion_cartografico", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_actualizacion_cartografico").IsRequired();
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Fecha).HasColumnName("fecha");
            builder.Property(e => e.EsObservado).HasColumnName("es_observado");
            builder.Property(e => e.ObservacionError).HasColumnName("observacion_error");
            builder.Property(e => e.InicioCalidad).HasColumnName("inicio_calidad");
            builder.Property(e => e.FinCalidad).HasColumnName("fin_calidad");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdInspectorCalidad).HasColumnName("ID_INSPECTOR_CALIDAD");
            builder.Property(e => e.Flag).HasColumnName("flag");

            builder.HasOne(e => e.Solicitud).WithMany(b => b.ActualizacionCartografico).HasForeignKey(c => c.IdSolicitud);

        }
    }
}
