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
    public class TipoResolucionMap : IEntityTypeConfiguration<TipoResolucion>
    {
        public void Configure(EntityTypeBuilder<TipoResolucion> builder)
        {
            builder.ToTable("tipo_resolucion", "loc");
            builder.HasKey(t => t.IdTipoResolucion);
            builder.Property(t => t.IdTipoResolucion).HasColumnName("id_tipo_resolucion").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
