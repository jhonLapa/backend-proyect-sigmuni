using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.PadronNumeraciones.Numeraciones
{
    public class NumeracionMap : IEntityTypeConfiguration<Numeracion>
    {
        public void Configure(EntityTypeBuilder<Numeracion> builder)
        {
            builder.ToTable("numeracion", "nu");
            builder.HasKey(t => t.IdNumeracion);
            builder.Property(t => t.IdNumeracion).HasColumnName("id_numeracion").UseIdentityAlwaysColumn();
            builder.Property(t => t.NumResolucion).HasColumnName("num_resolucion");
            builder.Property(t => t.AnioResolucion).HasColumnName("anio_resolucion");
            builder.Property(t => t.NumExpediente).HasColumnName("num_expediente");
            builder.Property(t => t.AnioExpediente).HasColumnName("anio_expediente");
            builder.Property(t => t.NumInforme).HasColumnName("num_informe");
            builder.Property(t => t.FechaEmision).HasColumnName("fecha_emision");
            builder.Property(t => t.Solicitante).HasColumnName("solicitante");
            builder.Property(t => t.Numero).HasColumnName("numero");
            builder.Property(t => t.IdOrigenNumeracion).HasColumnName("id_origen_numeracion");
            builder.Property(t => t.IdTipoPuerta).HasColumnName("id_tipo_puerta");
            builder.Property(t => t.MeAnteriorI).HasColumnName("me_anterior_i");
            builder.Property(t => t.MeAnteriorII).HasColumnName("me_anterior_ii");
            builder.Property(t => t.MeAnteriorIII).HasColumnName("me_anterior_iii");
            builder.Property(t => t.MeAnteriorIV).HasColumnName("me_anterior_iv");
            builder.Property(t => t.MeVigente).HasColumnName("me_vigente");
            builder.Property(t => t.MiAnteriorI).HasColumnName("mi_anterior_i");
            builder.Property(t => t.MiAnteriorII).HasColumnName("mi_anterior_ii");
            builder.Property(t => t.MiAnteriorIII).HasColumnName("mi_anterior_iii");
            builder.Property(t => t.MiAnteriorIV).HasColumnName("mi_anterior_iv");
            builder.Property(t => t.MiVigente).HasColumnName("vigente");
            builder.Property(t => t.Nivel).HasColumnName("nivel");
            builder.Property(t => t.Uso).HasColumnName("uso");
            builder.Property(t => t.Folio).HasColumnName("folio");
            builder.Property(t => t.IdTblCodigo).HasColumnName("id_tbl_codigo");
            builder.Property(t => t.IdAreaTratNormativo).HasColumnName("id_area_trat_normativo");
            builder.Property(t => t.IdClaseZonificacion).HasColumnName("id_clase_zonificacion");
            builder.Property(t => t.TotalUnidadCatastral).HasColumnName("total_unidad_catastral");
            builder.Property(t => t.IdTipoEdificacion).HasColumnName("id_tipo_edificacion");
            builder.Property(t => t.IdTipoInteriorNUm).HasColumnName("id_tipo_interior_num");
            builder.Property(t => t.IdDocumento).HasColumnName("id_documento");
            builder.Property(t => t.IdUsuario).HasColumnName("id_usuario");
            builder.Property(t => t.CodDistrito).HasColumnName("cod_distrito");
            builder.Property(t => t.CodSector).HasColumnName("cod_sector");
            builder.Property(t => t.CodManzana).HasColumnName("cod_manzana");
            builder.Property(t => t.CodLote).HasColumnName("cod_lote");
            builder.Property(t => t.IdUnidadCatastral).HasColumnName("id_unidad_catastral");
            builder.Property(t => t.IdTipoAsignacion).HasColumnName("id_tipo_asignacion");
            builder.Property(t => t.Ubicacion).HasColumnName("ubicacion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.Ip).HasColumnName("ip_accion");

            builder.HasOne(e => e.TipoAsignacion)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdTipoAsignacion);

            builder.HasOne(e => e.OrigenNumeracion)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdOrigenNumeracion);

            builder.HasOne(e => e.TipoPuerta)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdTipoPuerta);

            builder.HasOne(e => e.TblCodigo)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdTblCodigo);

            builder.HasOne(e => e.AreaTratamiento)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdAreaTratNormativo);

            builder.HasOne(e => e.ClaseZonificacion)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdClaseZonificacion);

            builder.HasOne(e => e.TipoEdificacion)
                .WithMany(b => b.Numeraciones)
                .HasForeignKey(c => c.IdTipoEdificacion);

            //builder.HasOne(e => e.TipoInteriorNuInterior)
            //    .WithMany(b => b.Numeracion)
            //    .HasForeignKey(c => c.IdTipoInteriorNUm);

            //builder.HasOne(e => e.Documento)
            //    .WithMany(b => b.Numeracion)
            //    .HasForeignKey(c => c.IdDocumento);

            //builder.HasOne(e => e.HuPredio)
            //    .WithOne(b => b.Numeracion)
            //    .HasForeignKey<HUPredio>(c => c.Id);

            //builder.HasOne(e => e.PadronRegistro)
            //    .WithOne(b => b.Numeracion)
            //    .HasForeignKey<PadronRegistro>(c => c.Id);

            //builder.HasOne(e => e.NomenclaturaPredio)
            //    .WithOne(b => b.Numeracion)
            //    .HasForeignKey<NomenclaturaPredio>(c => c.Id);

            builder.HasOne(e => e.Certificado)
                .WithOne(b => b.Numeracion)
                .HasForeignKey<Certificado>(c => c.Id);
        }
    }
}
