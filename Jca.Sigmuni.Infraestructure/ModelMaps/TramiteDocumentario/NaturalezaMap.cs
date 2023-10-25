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
    public class NaturalezaMap : IEntityTypeConfiguration<Naturaleza>
    {
        public void Configure(EntityTypeBuilder<Naturaleza> builder)
        {
            builder.ToTable("naturaleza", "trd");
            builder.HasKey(t => t.IdNaturaleza);
            builder.Property(t => t.IdNaturaleza).HasColumnName("id_naturaleza").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
