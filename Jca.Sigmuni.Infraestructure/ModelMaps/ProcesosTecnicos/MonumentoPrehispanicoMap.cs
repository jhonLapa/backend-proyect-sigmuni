using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class MonumentoPrehispanicoMap : IEntityTypeConfiguration<MonumentoPrehispanico>
    {
        public void Configure(EntityTypeBuilder<MonumentoPrehispanico> builder)
        {
            builder.ToTable("monumento_preinspanico","loc");
            builder.HasKey(t => t.IdMonumentoPrehispanico);
            builder.Property(t => t.IdMonumentoPrehispanico).HasColumnName("id_monumento_pre").IsRequired();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Area).HasColumnName("area");
            builder.Property(e => e.Perimetro).HasColumnName("perimetro");
            builder.Property(e => e.PresenciaArquitectura).HasColumnName("presencia_arquitectura").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.IdTipoMaterial).HasColumnName("id_tipo_material");
            builder.Property(e => e.IdFichaBienCultural).HasColumnName("id_ficha_bien_cultural");
            builder.Property(e => e.IdUnidadMedida).HasColumnName("id_unidad_medida");
            builder.Property(e => e.IdCategoriaInmueble).HasColumnName("id_categoria_inmueble");
            builder.Property(e => e.IdFiliacionCronologica).HasColumnName("id_filiacion_cronologica");
            builder.Property(e => e.IdAfectacionNatural).HasColumnName("id_afectacion_natural");
            builder.Property(e => e.IdAfectacionAntropica).HasColumnName("id_afectacion_antropica");
            builder.Property(e => e.OtroTipoMaterial).HasColumnName("otro_tipo_material").IsUnicode(false).HasMaxLength(2000);
            builder.Property(e => e.OtroAfectacionNatural).HasColumnName("otro_afectacion_natural").IsUnicode(false).HasMaxLength(2000);
            builder.Property(e => e.OtroAfectacionAntropica).HasColumnName("otro_afectacion_antropica").IsUnicode(false).HasMaxLength(2000);
            builder.Property(e => e.IdObservacion).HasColumnName("id_observacion");
            builder.Property(e => e.ObservacionOtros).HasColumnName("observacion_otros");
            builder.Property(e => e.IdIntervencionConservacion).HasColumnName("id_intervencion_conservacion");
            builder.Property(e => e.IdTipoArquitectura).HasColumnName("id_tipo_arquitectura");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.TipoMaterial).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdTipoMaterial);
            builder.HasOne(e => e.FichaBienCultural).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdFichaBienCultural);
            builder.HasOne(e => e.UnidadMedida).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdUnidadMedida);
            builder.HasOne(e => e.CategoriaInmueble).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdCategoriaInmueble);
            builder.HasOne(e => e.FiliacionCronologica).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdFiliacionCronologica);
            builder.HasOne(e => e.AfectacionNatural).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdAfectacionNatural);
            builder.HasOne(e => e.AfectacionAntropica).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdAfectacionAntropica);
            builder.HasOne(e => e.Observacion).WithMany(b => b.MonumentoPrehispanico).HasForeignKey(c => c.IdObservacion);
            builder.HasOne(e => e.IntervencionConservacion).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdIntervencionConservacion);
            builder.HasOne(e => e.TipoArquitectura).WithMany(b => b.MonumentoPreinspanico).HasForeignKey(c => c.IdTipoArquitectura);


        }
    }
}
