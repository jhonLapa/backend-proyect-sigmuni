using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.CompendioNormas
{
    public class NormaInteresMap : IEntityTypeConfiguration<NormaInteres>
    {
        public void Configure(EntityTypeBuilder<NormaInteres> builder)
        {
            builder.ToTable("norma_interes", "ni");
            builder.HasKey(t => t.IdNormaInteres);
            builder.Property(t => t.IdNormaInteres).HasColumnName("id_norma_interes");
            builder.Property(t => t.PaginasInteres).HasColumnName("paginas_interes");
            builder.Property(t => t.observacion).HasColumnName("observacion");
            builder.Property(t => t.IdNormaDerogado).HasColumnName("id_norma_modificado_derogado");
            builder.Property(t => t.ArticuloNormaDerogado).HasColumnName("articulo_modificado_derogado");
            builder.Property(t => t.ObservacionNormaDerogado).HasColumnName("obs_modificado_derogado");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdNormaDiaDetalle).HasColumnName("id_norma_dia_detalle");
            builder.Property(t => t.IdAutoridad).HasColumnName("id_autoridad");
            builder.Property(t => t.IdNaturaleza).HasColumnName("id_naturaleza");
            builder.Property(t => t.EstadoNotificacion).HasColumnName("estado_notificacion");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(t => t.IdEstadoNorma).HasColumnName("id_estado_norma");
            builder.Property(t => t.IdEstadoDerogado).HasColumnName("id_estado_modificado_derogado");
            builder.Property(e => e.IdClasificacion).HasColumnName("id_clasificacion");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Sumilla).HasColumnName("sumilla");
            builder.Property(e => e.IdTipoNorma).HasColumnName("id_tipo_norma");



            builder.HasOne(e => e.NormaDiaDetalles)
               .WithMany(b => b.NormaInteres)
               .HasForeignKey(c => c.IdNormaDiaDetalle);
            // builder.HasMany(e => e.NormaDerogadas).WithOne(e => e.NormaInteres).HasForeignKey(x => x.IdNormaDerogada);
        }
    }
}
