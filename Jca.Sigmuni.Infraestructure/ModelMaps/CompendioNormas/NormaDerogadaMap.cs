using Jca.Sigmuni.Domain.CompendioNormas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.CompendioNormas
{
    public class NormaDerogadaMap : IEntityTypeConfiguration<NormaDerogada>
    {
        public void Configure(EntityTypeBuilder<NormaDerogada> builder)
        {
            builder.ToTable("norma_derogada", "ni");
            builder.HasKey(t => t.IdNormaDerogada);
            builder.Property(t=>t.IdNormaDerogada).HasColumnName("id_norma_derogada");
            builder.Property(t => t.ArticuloModificado).HasColumnName("articulo_modificado");
            builder.Property(t => t.NotaObservacion).HasColumnName("nota_observacion");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registrada");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.IdNormaInteres).HasColumnName("id_norma_interes");
            builder.Property(t => t.IdEstadoNorma).HasColumnName("id_estado_norma");
            builder.Property(t => t.IdNormaInteresDerogada).HasColumnName("id_norma_interes_derogada");

            builder.HasOne(e => e.NormaInteres).WithMany(b => b.NormaDerogadas).HasForeignKey(c => c.IdNormaInteres);
            builder.HasOne(e => e.NormaInteresDerogada).WithMany(b => b.NormaInteresDerogadas).HasForeignKey(c => c.IdNormaInteresDerogada);
        }
    }
}
