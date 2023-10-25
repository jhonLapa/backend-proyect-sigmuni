using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.PadronNumeraciones.Numeraciones
{
    public class OrigenNumeracionMap : IEntityTypeConfiguration<OrigenNumeracion>
    {
        public void Configure(EntityTypeBuilder<OrigenNumeracion> builder)
        {
            builder.ToTable("origen_numeracion", "nu");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_origen_numeracion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.Flag).HasColumnName("flag");
        }
    }
}
