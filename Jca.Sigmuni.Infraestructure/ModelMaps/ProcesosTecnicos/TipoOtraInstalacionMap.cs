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
    public class TipoOtraInstalacionMap : IEntityTypeConfiguration<TipoOtraInstalacion>
    {
        public void Configure(EntityTypeBuilder<TipoOtraInstalacion> builder)
        {
            builder.ToTable("tipo_otras_instalaciones", "fic");
            builder.HasKey(t => t.IdTipoOtraInstalacion);
            builder.Property(t => t.IdTipoOtraInstalacion).HasColumnName("id_tipo_otras_instalaciones").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.IdUnidadMedida).HasColumnName("id_unidad_medida");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.UnidadMedida).WithMany(b => b.TipoOtraInstalaciones).HasForeignKey(c => c.IdUnidadMedida);
        }
    }
}
