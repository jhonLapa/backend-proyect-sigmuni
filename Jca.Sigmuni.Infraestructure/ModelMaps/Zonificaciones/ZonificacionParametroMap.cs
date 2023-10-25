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
    public class ZonificacionParametroMap : IEntityTypeConfiguration<ZonificacionParametro>
    {
        public void Configure(EntityTypeBuilder<ZonificacionParametro> builder)
        {
            builder.ToTable("zonificacion", "zo");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_zonificacion").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.AmbitoPlano).HasColumnName("ambito_plano").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.Fuente).HasColumnName("fuente").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.Resolucion).HasColumnName("resolucion").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(e => e.Editor).HasColumnName("editor").IsUnicode(false).HasMaxLength(200);
            builder.Property(e => e.Plano).HasColumnName("plano");
            builder.Property(e => e.Nota).HasColumnName("nota").IsUnicode(false).HasMaxLength(4000);
            builder.Property(e => e.Observacion).HasColumnName("observacion").IsUnicode(false).HasMaxLength(4000);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.Ip).HasColumnName("ip_accion");
            builder.Property(e => e.IdClaseZonificacion).HasColumnName("id_clase_zonificacion");
            builder.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo"); // cambiar a codigo_ubigeo en tabla
            builder.Property(e => e.IdAreaTratamiento).HasColumnName("id_area_trat_normativo");
            builder.Property(e => e.IdZonificacionCarto).HasColumnName("id_zonificacion_carto");

            //builder.HasOne(a => a.ParametroUrbanistico).WithOne(b => b.ZonificacionParametro).HasForeignKey<ParametroUrbanistico>(b => b.Id);
            builder.HasOne(e => e.ClaseZonificacion).WithMany(b => b.ZonificacionParametros).HasForeignKey(c => c.IdClaseZonificacion);
            builder.HasOne(e => e.Ubigeo).WithMany(b => b.ZonificacionParametros).HasForeignKey(c => c.CodigoUbigeo);
            builder.HasOne(e => e.AreaTratamiento).WithMany(b => b.ZonificacionParametros).HasForeignKey(c => c.IdAreaTratamiento);
        }
    }
}
