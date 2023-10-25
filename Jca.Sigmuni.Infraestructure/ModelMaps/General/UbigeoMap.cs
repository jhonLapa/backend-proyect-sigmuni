using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class UbigeoMap : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("ubigeo", "loc");
            builder.HasKey(t => t.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("codigo_ubigeo").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.CodigoPadre).HasColumnName("codigo_padre").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.CodigoParcial).HasColumnName("codigo_parcial").IsUnicode(false).HasMaxLength(100);

            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Nivel).HasColumnName("nivel");
            builder.Property(e => e.NombreCompleto).HasColumnName("nombre_completo");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

            builder.Property(e => e.Estado).HasColumnName("estado");

           



        }
    }
}
