using Jca.Sigmuni.Domain.Habilitaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Habilitaciones
{
    public class TipoHabilitacionUrbanaMap : IEntityTypeConfiguration<TipoHabilitacionUrbana>
    {
        public void Configure(EntityTypeBuilder<TipoHabilitacionUrbana> builder)
        {
            builder.ToTable("tipo_hu", "hu");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tipo_hu");
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
