using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ClasificacionMap : IEntityTypeConfiguration<ClasificacionNorma>
    {
        public void Configure(EntityTypeBuilder<ClasificacionNorma> builder)
        {
            builder.ToTable("clasificacion_norma", "trd");
            builder.HasKey(t => t.IdClasificacionNorma);
            builder.Property(t => t.IdClasificacionNorma).HasColumnName("id_clasificacion_norma").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
