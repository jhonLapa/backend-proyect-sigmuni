using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class LoteMap : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable("lote", "loc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_lote");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.CUC).HasColumnName("cuc").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Editor).HasColumnName("editor").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Anio).HasColumnName("anio").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.VersionFinal).HasColumnName("ver_final").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Observacion).HasColumnName("observacion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.FechaEdicion).HasColumnName("fecha_edicion");
            builder.Property(e => e.Estado).HasColumnName("estado");
            
            builder.Property(e => e.IdManzanaCarto).HasColumnName("id_manzana_carto");
            builder.Property(e => e.EstadoObservacion).HasColumnName("estado_observacion");
            builder.Property(e => e.NumeroPartidaRegistral).HasColumnName("num_partida_registral");
            builder.Property(e => e.IdUbicacionLote).HasColumnName("id_ubicacion_lote");
            

            builder.Property(e => e.AreaConstruida).HasColumnName("area_construida");
            builder.Property(e => e.AreaGrafica).HasColumnName("area_grafica");
            builder.Property(e => e.IdEstructura).HasColumnName("id_estructura");


            builder.Property(e => e.ValorArancelario).HasColumnName("valor_arancelario");

            builder.HasOne(e => e.Manzana).WithMany(b => b.Lote).HasForeignKey(c => c.IdManzanaCarto);
        }
    }
}
