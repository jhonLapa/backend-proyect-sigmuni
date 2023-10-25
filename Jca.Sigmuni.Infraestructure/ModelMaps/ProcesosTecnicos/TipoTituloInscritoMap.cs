﻿using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class TipoTituloInscritoMap : IEntityTypeConfiguration<TipoTituloInscrito>
    {
        public void Configure(EntityTypeBuilder<TipoTituloInscrito> builder)
        {
            builder.ToTable("tipo_titulo_inscrito", "fic");
            builder.HasKey(t => t.IdTipoTituloInscrito);
            builder.Property(t => t.IdTipoTituloInscrito).HasColumnName("id_tipo_titulo_inscrito").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
