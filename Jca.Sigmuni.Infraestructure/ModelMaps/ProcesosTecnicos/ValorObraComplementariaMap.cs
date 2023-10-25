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
    public class ValorObraComplementariaMap : IEntityTypeConfiguration<ValorObraComplementaria>
    {
        public void Configure(EntityTypeBuilder<ValorObraComplementaria> builder)
        {
            builder.ToTable("complementaria_inst", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_complementaria_inst").UseIdentityAlwaysColumn();
            builder.Property(e => e.Anio).HasColumnName("anio").IsUnicode(false).HasMaxLength(4);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(300);
            builder.Property(e => e.UnidadMedida).HasColumnName("unidad_medida").HasMaxLength(10);
            builder.Property(e => e.Valor).HasColumnName("valor");
            builder.Property(e => e.Item).HasColumnName("item");
            builder.Property(e => e.IdTipoOtrasInstalaciones).HasColumnName("id_tipo_otras_instalaciones");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.TipoOtraInstalacion).WithMany(b => b.ValorObraComplementarias).HasForeignKey(c => c.IdTipoOtrasInstalaciones);
        }
    }
}
