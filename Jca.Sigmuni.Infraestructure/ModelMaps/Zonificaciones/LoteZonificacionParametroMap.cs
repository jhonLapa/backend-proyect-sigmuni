using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.Zonificaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Zonificaciones
{
    public class LoteZonificacionParametroMap : IEntityTypeConfiguration<LoteZonificacionParametro>
    {
        public void Configure(EntityTypeBuilder<LoteZonificacionParametro> builder)
        {
            builder.ToTable("lote_zonificacion", "zo");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_lote_zonificacion").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdLote).HasColumnName("id_lote_carto");
            builder.Property(t => t.IdZonificacionParametro).HasColumnName("id_zonificacion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.AlineamientoFachada).HasColumnName("alineamiento_fachada");
            builder.Property(e => e.UbiCHL).HasColumnName("ubi_chl");
            builder.Property(e => e.UbiZRE).HasColumnName("ubi_zre");
            builder.Property(e => e.Normativa).HasColumnName("normativa");
            builder.Property(e => e.IdClasificacionBien).HasColumnName("id_clasificacion_bien");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            //builder.HasOne(e => e.Lote).WithMany(b => b.LoteZonificacionParametros).HasForeignKey(c => c.IdLote);
            builder.HasOne(e => e.ZonificacionParametro).WithMany(b => b.LoteZonificacionParametros).HasForeignKey(c => c.IdZonificacionParametro);
            //builder.HasOne(e => e.ClasificacionBien).WithMany(b => b.LoteZonificacionParametro).HasForeignKey(c => c.IdClasificacionBien);
        }
    }
}
