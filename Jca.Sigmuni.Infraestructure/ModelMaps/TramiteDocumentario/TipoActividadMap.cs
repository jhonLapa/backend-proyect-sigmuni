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
    internal class TipoActividadMap : IEntityTypeConfiguration<TipoActividad>
    {
        public void Configure(EntityTypeBuilder<TipoActividad> builder)
        {
            builder.ToTable("tipo_actividad", "trd");
            builder.HasKey(t => t.IdTipoActividad);
            builder.Property(t => t.IdTipoActividad).HasColumnName("id_tipo_actividad").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Nombre).HasColumnName("nombre");
            builder.Property(t => t.Categoria).HasColumnName("categoria");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
