using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class AccionGenerarMap : IEntityTypeConfiguration<AccionGenerar>
    {
        public void Configure(EntityTypeBuilder<AccionGenerar> builder)
        {
            builder.ToTable("accion_generar", "trd");
            builder.HasKey(t => t.IdAccionGenerar);
            builder.Property(t => t.IdAccionGenerar).HasColumnName("id_accion_generar").UseIdentityAlwaysColumn();
            builder.Property(t => t.Tipo).HasColumnName("tipo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
