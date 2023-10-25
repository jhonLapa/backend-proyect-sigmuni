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
    public class OcupanteMap : IEntityTypeConfiguration<Ocupante>
    {
        public void Configure(EntityTypeBuilder<Ocupante> builder)
        {
            builder.ToTable("ocupante", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_ocupante").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdCondicionPer).HasColumnName("id_condicion_per");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");

            builder.HasOne(e => e.CondicionPer).WithMany(b => b.Ocupantes).HasForeignKey(c => c.IdCondicionPer);
            builder.HasOne(e => e.Ficha).WithMany(b => b.Ocupantes).HasForeignKey(c => c.IdFicha);
        }
    }
}
