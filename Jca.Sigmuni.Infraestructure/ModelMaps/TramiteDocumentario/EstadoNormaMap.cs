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
    public class EstadoNormaMap : IEntityTypeConfiguration<EstadoNorma>
    {
        public void Configure(EntityTypeBuilder<EstadoNorma> builder)
        {
            builder.ToTable("estado_norma", "ni");
            builder.HasKey(t => t.IdEstadoNorma);
            builder.Property(t => t.IdEstadoNorma).HasColumnName("id_estado_norma").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.Grupo).HasColumnName("grupo");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
