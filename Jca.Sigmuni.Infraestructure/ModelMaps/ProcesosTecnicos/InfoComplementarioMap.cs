using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class InfoComplementarioMap : IEntityTypeConfiguration<InfoComplementario>
    {
        public void Configure(EntityTypeBuilder<InfoComplementario> builder)
        {
            builder.ToTable("info_complementario", "fic");
            builder.HasKey(t => t.IdInfoComplementario);
            builder.Property(t => t.IdInfoComplementario).HasColumnName("id_info_complementario");
            builder.Property(e => e.NumHabitantes).HasColumnName("num_habitantes").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.NumFamilias).HasColumnName("num_familias").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Observaciones).HasColumnName("observaciones").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdObservacion).HasColumnName("id_observacion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdTipoMantenimiento).HasColumnName("id_tipo_mantenimiento").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdEstadoLlenado).HasColumnName("id_estado_llenado").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.NumComunicacion).HasColumnName("num_comunicacion");
            builder.Property(e => e.IdTipoInspeccion).HasColumnName("id_tipo_inspeccion");
            builder.Property(e => e.IdMotivo).HasColumnName("id_motivo");
            builder.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
           

            builder.HasOne(e => e.EstadoLLenado).WithMany(b => b.InfoComplementarios).HasForeignKey(c => c.IdEstadoLlenado);
            builder.HasOne(e => e.Ficha).WithMany(b => b.InfoComplementarios).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoInspeccion).WithMany(b => b.InfoComplementarios).HasForeignKey(c => c.IdTipoInspeccion);
            builder.HasOne(e => e.TipoMantenimiento).WithMany(b => b.InfoComplementarios).HasForeignKey(c => c.IdTipoMantenimiento);
            builder.HasOne(e => e.Observacion).WithMany(b => b.InfoComplementarios).HasForeignKey(c => c.IdObservacion);
        }
    }
}
