using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class AreaTerrenoInvalidMap : IEntityTypeConfiguration<AreaTerrenoInvalid>
    {
        public void Configure(EntityTypeBuilder<AreaTerrenoInvalid> builder)
        {
            builder.ToTable("area_terreno_invalid","fic");
            builder.HasKey(t => t.IdEvaluacion);
            builder.Property(t => t.IdEvaluacion).HasColumnName("id_evaluacion");
            builder.Property(t => t.LoteColindante).HasColumnName("lote_colindante");
            builder.Property(t => t.JardinAislamiento).HasColumnName("jardin_aislamiento");
            builder.Property(t => t.AreaPublica).HasColumnName("area_publica");
            builder.Property(t => t.AreaIntangible).HasColumnName("area_intagible");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");

            builder.HasOne(t=>t.Ficha).WithMany(b=>b.AreaTerrenoInvalids).HasForeignKey(t => t.IdFicha);
        }
    }
}
