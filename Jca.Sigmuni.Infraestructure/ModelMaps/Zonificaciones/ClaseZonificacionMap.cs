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
    internal class ClaseZonificacionMap : IEntityTypeConfiguration<ClaseZonificacion>
    {
        public void Configure(EntityTypeBuilder<ClaseZonificacion> builder)
        {
            builder.ToTable("clase_zonificacion", "zo"); 
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_clase_zonificacion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
