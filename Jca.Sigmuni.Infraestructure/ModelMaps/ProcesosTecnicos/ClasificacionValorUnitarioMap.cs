using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ClasificacionValorUnitarioMap : IEntityTypeConfiguration<ClasificacionValorUnitario>
    {
        public void Configure(EntityTypeBuilder<ClasificacionValorUnitario> builder)
        {
            builder.ToTable("clasificacion_unitario", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasColumnName("id_clasificacion_unitario").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
