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
    public class CondicionEspecialTitularMap : IEntityTypeConfiguration<CondicionEspecialTitular>
    {
        public void Configure(EntityTypeBuilder<CondicionEspecialTitular> builder)
        {
            builder.ToTable("cond_esp_titular", "ge");
            builder.HasKey(t => t.IdCondicionEspecialTitular);
            builder.Property(t => t.IdCondicionEspecialTitular).HasColumnName("id_cond_esp_titular").UseIdentityAlwaysColumn();
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
