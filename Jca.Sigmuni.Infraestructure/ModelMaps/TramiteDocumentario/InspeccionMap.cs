using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class InspeccionMap : IEntityTypeConfiguration<Inspeccion>
    {
        public void Configure(EntityTypeBuilder<Inspeccion> builder)
        {
            builder.ToTable("inspeccion", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_inspeccion");
            builder.Property(e => e.FechaAsignacion).HasColumnName("fecha_asignacion").IsUnicode(false);
            builder.Property(e => e.Fecha).HasColumnName("fecha").IsUnicode(false);
            builder.Property(e => e.FechaCulminacion).HasColumnName("fecha_culminacion");
            builder.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            builder.Property(e => e.HoraFin).HasColumnName("hora_fin");

            builder.Property(e => e.IdMotivo).HasColumnName("id_motivo");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.IdTurno).HasColumnName("id_turno_inspeccion");
            builder.Property(e => e.IdInspector).HasColumnName("id_inspector");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.TipoInspector).HasColumnName("tipo_inspector");
            builder.Property(e => e.TipoInspeccion).HasColumnName("tipo_inspeccion").IsRequired();

            builder.HasOne(e => e.Motivo).WithMany(b => b.Inspecciones).HasForeignKey(c => c.IdMotivo);
            builder.HasOne(e => e.Solicitud).WithMany(b => b.Inspecciones).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.Inspector).WithMany(b => b.Inspecciones).HasForeignKey(c => c.IdInspector);
            builder.HasOne(e => e.TurnoInspeccion).WithMany(b => b.Inspecciones).HasForeignKey(c => c.IdTurno);


        }
    }
}
