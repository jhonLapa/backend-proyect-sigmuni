using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class AreaTratamientoMap : IEntityTypeConfiguration<AreaTratamiento>
    {
        public void Configure(EntityTypeBuilder<AreaTratamiento> builder)
        {
            builder.ToTable("area_trat_normativo", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_area_trat_normativo").UseIdentityAlwaysColumn();
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.NormaAtn).HasColumnName("nomra_atn");
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
