using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class OtraInstalacionMap : IEntityTypeConfiguration<OtraInstalacion>
    {
        public void Configure(EntityTypeBuilder<OtraInstalacion> builder)
        {
            builder.ToTable("otras_instalaciones", "fic");
            builder.HasKey(t => t.IdOtraInstalacion);
            builder.Property(t => t.IdOtraInstalacion).HasColumnName("id_otras_instalaciones").UseIdentityAlwaysColumn();
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.ProductoTotal).HasColumnName("prod_total");
            builder.Property(e => e.IdUca).HasColumnName("id_uca");
            builder.Property(e => e.IdTipoOtrasInstalaciones).HasColumnName("id_tipo_otras_instalaciones");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsRequired();
            builder.Property(e => e.IdEcc).HasColumnName("id_ecc");
            builder.Property(e => e.IdEcs).HasColumnName("id_ecs");
            builder.Property(e => e.IdMep).HasColumnName("id_mep");
            builder.Property(e => e.IdUnidadMedida).HasColumnName("id_unidad_medida");
            builder.Property(e => e.MesAnio).HasColumnName("mes_anio");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.Largo).HasColumnName("largo");
            builder.Property(e => e.Ancho).HasColumnName("ancho");
            builder.Property(e => e.Alto).HasColumnName("alto");

            builder.HasOne(e => e.Uca).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdUca);
            builder.HasOne(e => e.Ecc).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdEcc);
            builder.HasOne(e => e.Ecs).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdEcs);
            builder.HasOne(e => e.Mep).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdMep);
            builder.HasOne(e => e.Ficha).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.UnidadMedida).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdUnidadMedida);
            builder.HasOne(e => e.TipoOtraInstalacion).WithMany(b => b.OtraInstalaciones).HasForeignKey(c => c.IdTipoOtrasInstalaciones);
        }
    }
}
