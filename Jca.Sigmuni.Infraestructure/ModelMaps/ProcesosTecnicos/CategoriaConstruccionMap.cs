using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class CategoriaConstruccionMap : IEntityTypeConfiguration<CategoriaConstruccion>
    {
        public void Configure(EntityTypeBuilder<CategoriaConstruccion> builder)
        {
            builder.ToTable("categoria_construccion", "loc");
            builder.HasKey(t => t.IdCategoriaConstruccion);
            builder.Property(t => t.IdCategoriaConstruccion).HasColumnName("id_categoria_construccion").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
