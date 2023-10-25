using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jca.Sigmuni.Domain.Habilitaciones;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Habilitaciones
{
    public class HabilitacionUrbanaMap : IEntityTypeConfiguration<HabilitacionUrbana>
    {
        public void Configure(EntityTypeBuilder<HabilitacionUrbana> builder)
        {
            builder.ToTable("habilitacion_urbana", "hu");
            builder.HasKey(t => t.IdHabilitacionUrbana);
            builder.Property(t => t.IdHabilitacionUrbana).HasColumnName("id_habilitacion_urbana");
            builder.Property(t => t.CodigoHabilitacioUrbana).HasColumnName("codigo_habilitacion_urbana");
            builder.Property(t => t.Nombre).HasColumnName("nombre");
            builder.Property(t => t.NumeroExpediente).HasColumnName("numero_expediente");
            builder.Property(t => t.PredioMatriz).HasColumnName("predio_matriz");
            builder.Property(t => t.ResolucionLicencia).HasColumnName("resolucion_licencia");
            builder.Property(t => t.ResolucionRecepcion).HasColumnName("resolucion_recepcion");
            //builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            //builder.Property(t => t.FechaAprobacion).HasColumnName("fecha_aprobacion");
            builder.Property(t => t.CodigoOrden).HasColumnName("codigo_orden");
            builder.Property(t => t.NumTotalManzanas).HasColumnName("num_total_manzana");
            builder.Property(t => t.NumTotalLotes).HasColumnName("num_total_lotes");
            builder.Property(t => t.PartidaParcelaRegistral).HasColumnName("partida_parcela_registral");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.Nota).HasColumnName("nota");
            //builder.Property(t => t.FechaAprobacionHU).HasColumnName("fecha_aprovacion_hu");
            builder.Property(t => t.Fundo).HasColumnName("fundo");
            builder.Property(t => t.SubLote).HasColumnName("sub_lote");
            builder.Property(t => t.IdTipoHU).HasColumnName("id_tipo_hu");
            builder.Property(t => t.IdEtapaHU).HasColumnName("id_etapa_hu");
            builder.Property(t => t.CodigoUbigeo).HasColumnName("codigo_ubigeo");
            builder.Property(t => t.IdPersona).HasColumnName("id_persona");
            builder.Property(t => t.IdEstadoHU).HasColumnName("id_estado_hu");
            builder.Property(t => t.IdHUCarto).HasColumnName("id_hu_carto");
            builder.Property(t => t.PropietarioHistorico).HasColumnName("propietario_historico");
            builder.Property(t => t.IdUsuario).HasColumnName("id_usuario");
            builder.Property(t => t.IdAccion).HasColumnName("id_accion");

            builder.HasOne(e => e.Ubigeo).WithMany(b => b.HabilitacionesUrbanas).HasForeignKey(c => c.CodigoUbigeo);
            builder.HasOne(e => e.Persona).WithMany(b => b.HabilitacionesUrbanas).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.TipoHabilitacionUrbana).WithMany(b => b.HabilitacionesUrbanas).HasForeignKey(c => c.IdTipoHU);
            // builder.HasOne(e => e.Domicilio).WithOne(b => b.HabilitacionUrbana).HasForeignKey(c => c.Id);
            //builder.HasMany(e => e.UbicacionPredios).WithOne(b => b.HabilitacionUrbana).HasForeignKey(c => c.IdPersona);
        }
    }
}
