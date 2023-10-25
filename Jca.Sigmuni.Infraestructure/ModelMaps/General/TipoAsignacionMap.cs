using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    internal class TipoAsignacionMap : IEntityTypeConfiguration<TipoAsignacion>
    {
        public void Configure(EntityTypeBuilder<TipoAsignacion> builder)
        {
            builder.ToTable("tipo_asignacion", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tipo_asignacion");
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.Abreviatura).HasColumnName("abreviatura");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
