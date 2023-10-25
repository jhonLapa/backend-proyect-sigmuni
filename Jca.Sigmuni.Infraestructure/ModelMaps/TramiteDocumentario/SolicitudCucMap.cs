using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class SolicitudCucMap : IEntityTypeConfiguration<SolicitudCuc>
    {
        public void Configure(EntityTypeBuilder<SolicitudCuc> builder)
        {
            builder.ToTable("solicitud_cuc", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_solicitud_cuc");
            builder.Property(t => t.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(t => t.IdUnidadCatastral).HasColumnName("id_unidad_catastral");
            builder.Property(t => t.IdTipoDigitacion).HasColumnName("id_tipo_digitacion");
            builder.Property(t => t.IdDocumento).HasColumnName("id_documento");
            builder.Property(t => t.IdLoteCarto).HasColumnName("id_lote_carto");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");

            builder.Property(t => t.DireccionReferencial).HasColumnName("direccion_referencial");
            builder.Property(t => t.Modificacion).HasColumnName("modificacion");
            builder.Property(t => t.IdResultado).HasColumnName("id_resultado");
            builder.Property(t => t.AreaConstruida).HasColumnName("area_construida");
            builder.Property(t => t.AreaTerreno).HasColumnName("area_terreno");
            builder.Property(t => t.IdTipoInspeccion).HasColumnName("id_tipo_inspeccion");
            builder.Property(t => t.IdTipoPartidaRegistral).HasColumnName("id_tipo_partida_registral");
            builder.Property(t => t.Numero).HasColumnName("numero");
            builder.Property(t => t.Fojas).HasColumnName("fojas");
            builder.Property(t => t.Asiento).HasColumnName("asiento");
            builder.Property(t => t.CodigoDistrito).HasColumnName("codigo_distrito");
            builder.Property(t => t.NombreHu).HasColumnName("nombre_hu");
            builder.Property(t => t.Mz).HasColumnName("mz");
            builder.Property(t => t.LoteDireccion).HasColumnName("lote_direc");
            builder.Property(t => t.NombreVia).HasColumnName("nombre_via");
            builder.Property(t => t.Nro).HasColumnName("nro");
            builder.Property(t => t.Interior).HasColumnName("interior");
            builder.Property(t => t.AnioUnidadCatastral).HasColumnName("anio_unidad_catastral");

            builder.HasOne(t => t.Solicitud).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdSolicitud);
            builder.HasOne(t => t.UnidadCatastral).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdUnidadCatastral);
            builder.HasOne(t => t.TipoDigitacion).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdTipoDigitacion);
            builder.HasOne(t => t.Documento).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdDocumento);
            builder.HasOne(t => t.Lote).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdLoteCarto);
            builder.HasOne(t => t.TipoInspeccion).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdTipoInspeccion);
            builder.HasOne(t => t.TipoPartidaRegistral).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdTipoPartidaRegistral);
            builder.HasOne(t => t.Resultados).WithMany(b => b.SolicitudCuc).HasForeignKey(c => c.IdResultado);
        }
    }
}
