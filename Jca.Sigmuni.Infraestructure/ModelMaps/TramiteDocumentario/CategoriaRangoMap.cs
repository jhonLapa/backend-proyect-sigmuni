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
    public class CategoriaRangoMap : IEntityTypeConfiguration<CategoriaRango>
    {
        public void Configure(EntityTypeBuilder<CategoriaRango> builder)
        {
            builder.ToTable("categoria_rango","trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_categoria_rango");
            builder.Property(e => e.PorcentajeUit).HasColumnName("porcentaje_uit");
            builder.Property(e => e.Importe).HasColumnName("import");
            builder.Property(e => e.Anio).HasColumnName("anio");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            builder.Property(e => e.IdRango).HasColumnName("id_rango");
            builder.Property(e => e.IdProcedimiento).HasColumnName("id_procedimiento");
            builder.Property(e => e.PlazoResolver).HasColumnName("plazo_resolver");

            builder.HasOne(e => e.Categoria).WithMany(b => b.CategoriaRango).HasForeignKey(c => c.IdCategoria);
            builder.HasOne(e => e.Rango).WithMany(b => b.CategoriaRango).HasForeignKey(c => c.IdRango);
            builder.HasOne(e => e.Procedimiento).WithMany(b => b.CategoriaRango).HasForeignKey(c => c.IdProcedimiento);
        }
    }
}
