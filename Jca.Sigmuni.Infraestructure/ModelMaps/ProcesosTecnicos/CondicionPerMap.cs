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
    public class CondicionPerMap : IEntityTypeConfiguration<CondicionPer>
    {
        public void Configure(EntityTypeBuilder<CondicionPer> builder)
        {
            builder.ToTable("condicion_per", "fic");
            builder.HasKey(t => t.IdCondicionPer);
            builder.Property(e => e.IdCondicionPer).HasColumnName("id_condicion_per").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
        }
    }
}
