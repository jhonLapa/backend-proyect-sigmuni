using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ActividadMap : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(EntityTypeBuilder<Actividad> builder)
        {
            builder.ToTable("actividad", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_actividad").IsRequired();
            builder.Property(e => e.NumeroActividad).HasColumnName("num_actividad");
            builder.Property(e => e.NumeroActividadAnterior).HasColumnName("num_actividad_anterior");
            builder.Property(e => e.NumeroActividadSiguiente).HasColumnName("num_actividad_siguiente");
            builder.Property(e => e.Descripcion).HasColumnName("desc_actividad");
            builder.Property(e => e.PlazoAtencion).HasColumnName("plazo_atencionint");
            builder.Property(e => e.NotificacionCorreo).HasColumnName("notificacion_correo");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Flag).HasColumnName("flag");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdTipoActividad).HasColumnName("id_tipo_actividad");
            builder.Property(e => e.IdProcedimiento).HasColumnName("id_procedimiento");
            builder.Property(e => e.IdAccionGenerar).HasColumnName("id_accion_generar");

            builder.Property(e => e.IdAreaCargo).HasColumnName("id_area_cargo");

            builder.Property(e => e.UltimoPaso).HasColumnName("ultimo_paso").HasMaxLength(2);
            builder.Property(e => e.Observacion).HasColumnName("observacion").HasMaxLength(3000);
            builder.Property(e => e.IdResultado).HasColumnName("id_resultado");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.IdResultadoII).HasColumnName("id_resultado_2");
            builder.Property(e => e.IdArea).HasColumnName("id_area");

            builder.HasOne(e => e.TipoActividad).WithMany(b => b.Actividad).HasForeignKey(c => c.IdTipoActividad);
            builder.HasOne(e => e.Procedimiento).WithMany(b => b.Actividad).HasForeignKey(c => c.IdProcedimiento);
            builder.HasOne(e => e.AccionGenerar).WithMany(b => b.Actividad).HasForeignKey(c => c.IdAccionGenerar);
            builder.HasOne(e => e.Resultado).WithMany(b => b.Actividades).HasForeignKey(c => c.IdResultado);
            builder.HasOne(e => e.ResultadoII).WithMany(b => b.ActividadesResultado2).HasForeignKey(c => c.IdResultadoII);
            builder.HasOne(e => e.Solicitud).WithMany(b => b.Actividades).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(e => e.Area).WithMany(b => b.Actividad).HasForeignKey(c => c.IdArea);    

        }
    }
}
