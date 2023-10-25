using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class MonumentoColonialMap : IEntityTypeConfiguration<MonumentoColonial>
    {
        public void Configure(EntityTypeBuilder<MonumentoColonial> builder)
        {
            builder.ToTable("monumento_colonial","loc");
            builder.HasKey(t => t.IdMonumentoColonial);
            builder.Property(t => t.IdMonumentoColonial).HasColumnName("id_monumento_colonial").IsRequired();
            builder.Property(e => e.PatrimonioCultural).HasColumnName("patrimonio_cultural").IsUnicode(false).HasMaxLength(2);
            builder.Property(e => e.Denominacion).HasColumnName("denominacion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.IdFichaBienCultural).HasColumnName("id_ficha_bien_cultural").IsRequired();
            builder.Property(e => e.DescripcionFachada).HasColumnName("descripcion_fachada");
            builder.Property(e => e.DescripcionInterior).HasColumnName("descripcion_interior");
            builder.Property(e => e.ReseniaHistorica).HasColumnName("resenia_historica").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.IdTiempoConstruccion).HasColumnName("id_tiempo_construccion");
            builder.Property(e => e.IdElementoArquitectonico).HasColumnName("id_elemento_arquitectonico");
            builder.Property(e => e.IdFiliacionEstilistica).HasColumnName("id_filiacion_estilistica");
            builder.Property(e => e.IdIntervencionInmueble).HasColumnName("id_intervencion_inmueble");
            builder.Property(e => e.OtroElementoArquitectonico).HasColumnName("otro_elemento_arquitectonico");
            builder.Property(e => e.OtroFiliacionEstilistica).HasColumnName("otro_filiacion_estilistica");
            builder.Property(e => e.IdCimiento).HasColumnName("id_cimiento");
            builder.Property(e => e.IdMuro).HasColumnName("id_muro");
            builder.Property(e => e.IdPiso).HasColumnName("id_piso");
            builder.Property(e => e.IdTecho).HasColumnName("id_techo");
            builder.Property(e => e.IdPilastra).HasColumnName("id_pilastra");
            builder.Property(e => e.IdRevestimiento).HasColumnName("id_revestimiento");
            builder.Property(e => e.IdBalcon).HasColumnName("id_balcon");
            builder.Property(e => e.IdPuerta).HasColumnName("id_puerta");
            builder.Property(e => e.IdVentana).HasColumnName("id_ventana");
            builder.Property(e => e.IdReja).HasColumnName("id_reja");
            builder.Property(e => e.IdOtro).HasColumnName("id_otro");
            builder.Property(e => e.OtroEstadoAcabado).HasColumnName("otro_estado_acabado");
            builder.Property(e => e.IdObservacion).HasColumnName("id_observacion");
            builder.Property(e => e.IdUsoPredio).HasColumnName("id_uso");
            builder.Property(e => e.IdUsoOrginalPredio).HasColumnName("id_uso_original");
            builder.Property(e => e.FechaConstruccion).HasColumnName("fecha_construccion");
            builder.Property(e => e.AreaTerrenoTitulo).HasColumnName("area_terreno_titulo");
            builder.Property(e => e.AreaTechadaVerificada).HasColumnName("area_techada_verificada");
            builder.Property(e => e.AreaLibre).HasColumnName("area_libre");
            builder.Property(e => e.IdTipoArquitectura).HasColumnName("id_tipo_arquitectura");
            builder.Property(e => e.NumeroPisoCifra).HasColumnName("num_piso_cifra");
            builder.Property(e => e.NumeroPisoLiteral).HasColumnName("num_piso_literal");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.FichaBienCultural).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdFichaBienCultural);
            builder.HasOne(e => e.TiempoConstruccion).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdTiempoConstruccion);
            builder.HasOne(e => e.ElementoArquitectonico).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdElementoArquitectonico);
            builder.HasOne(e => e.FiliacionEstilistica).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdFiliacionEstilistica);
            builder.HasOne(e => e.IntervencionInmueble).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdIntervencionInmueble);
            builder.HasOne(e => e.EstadoCimiento).WithMany(b => b.MonumentoColonialCimiento).HasForeignKey(c => c.IdCimiento);
            builder.HasOne(e => e.EstadoMuro).WithMany(b => b.MonumentoColonialMuro).HasForeignKey(c => c.IdMuro);
            builder.HasOne(e => e.EstadoPiso).WithMany(b => b.MonumentoColonialPiso).HasForeignKey(c => c.IdPiso);
            builder.HasOne(e => e.EstadoTecho).WithMany(b => b.MonumentoColonialTecho).HasForeignKey(c => c.IdTecho);
            builder.HasOne(e => e.EstadoPilastra).WithMany(b => b.MonumentoColonialPilastra).HasForeignKey(c => c.IdPilastra);
            builder.HasOne(e => e.EstadoRevestimiento).WithMany(b => b.MonumentoColonialRevestimiento).HasForeignKey(c => c.IdRevestimiento);
            builder.HasOne(e => e.EstadoBalcon).WithMany(b => b.MonumentoColonialBalcon).HasForeignKey(c => c.IdBalcon);
            builder.HasOne(e => e.EstadoPuerta).WithMany(b => b.MonumentoColonialPuerta).HasForeignKey(c => c.IdPuerta);
            builder.HasOne(e => e.EstadoVentana).WithMany(b => b.MonumentoColonialVentana).HasForeignKey(c => c.IdVentana);
            builder.HasOne(e => e.EstadoReja).WithMany(b => b.MonumentoColonialReja).HasForeignKey(c => c.IdReja);
            builder.HasOne(e => e.EstadoOtro).WithMany(b => b.MonumentoColonialOtro).HasForeignKey(c => c.IdOtro);
            builder.HasOne(e => e.Observacion).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdObservacion);
            builder.HasOne(e => e.UsoPredio).WithMany(b => b.MonumentoColonialUso).HasForeignKey(c => c.IdUsoPredio);
            builder.HasOne(e => e.UsoPredioOrginal).WithMany(b => b.MonumentoColonialUsoOrginal).HasForeignKey(c => c.IdUsoOrginalPredio);
            builder.HasOne(e => e.TipoArquitectura).WithMany(b => b.MonumentoColonial).HasForeignKey(c => c.IdTipoArquitectura);


        }
    }
}
