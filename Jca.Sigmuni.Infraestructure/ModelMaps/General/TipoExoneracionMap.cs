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
    public class TipoExoneracionMap : IEntityTypeConfiguration<TipoExoneracion>
    {
        public void Configure(EntityTypeBuilder<TipoExoneracion> builder)
        {
            builder.ToTable("tipo_exoneracion", "ge");
            builder.HasKey(t => t.IdTipoExoneracion);
            builder.Property(t => t.IdTipoExoneracion).HasColumnName("id_tipo_exoneracion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
