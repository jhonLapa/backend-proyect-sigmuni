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
    public class TipoNormaMap : IEntityTypeConfiguration<TipoNorma>
    {
        public void Configure(EntityTypeBuilder<TipoNorma> builder)
        {
            builder.ToTable("tipo_norma", "ni");
            builder.HasKey(t => t.IdTipoNorma);
            builder.Property(t => t.IdTipoNorma).HasColumnName("id_tipo_norma").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.flag).HasColumnName("flag");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
