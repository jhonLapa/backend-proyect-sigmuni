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
    public class TipoTramiteMap : IEntityTypeConfiguration<TipoTramite>
    {
        public void Configure(EntityTypeBuilder<TipoTramite> builder)
        {
            builder.ToTable("tipo_tramite", "trd");
            builder.HasKey(t => t.IdTipoTramite);
            builder.Property(t => t.IdTipoTramite).HasColumnName("id_tipo_tramite").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
