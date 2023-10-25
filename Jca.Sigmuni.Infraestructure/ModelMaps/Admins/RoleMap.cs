using System;
using Jca.Sigmuni.Domain.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Admins
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role","adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(t => t.Nombre).HasColumnName("name");
            builder.Property(t => t.Descripcion).HasColumnName("description");
            builder.Property(t => t.FechaRegistro).HasColumnName("registrationdate");
            builder.Property(t => t.Estado).HasColumnName("state");
        }
    }
}

