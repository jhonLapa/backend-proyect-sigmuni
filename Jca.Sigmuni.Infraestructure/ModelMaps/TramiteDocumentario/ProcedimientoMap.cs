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
    public class ProcedimientoMap : IEntityTypeConfiguration<Procedimiento>
    {
        public void Configure(EntityTypeBuilder<Procedimiento> builder)
        {
            builder.ToTable("procedimiento", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_procedimiento").IsRequired();
            builder.Property(e => e.AsuntoTramite).HasColumnName("asunto_tramite").IsRequired();
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario").IsRequired();
            builder.Property(e => e.IdTipoTramite).HasColumnName("id_tipo_tramite").IsRequired();
            builder.Property(e => e.Normativa).HasColumnName("normativa");
            builder.Property(e => e.PlazoResolver).HasColumnName("plazo_resolver");
            builder.Property(e => e.PlazoReconsAdministrativo).HasColumnName("plazo_recons_administrado");
            builder.Property(e => e.PlazoReconsIcl).HasColumnName("plazo_recons_icl");
            builder.Property(e => e.PlazoApelAdministrativo).HasColumnName("plazo_apel_administrado");
            builder.Property(e => e.PlazoApelIcl).HasColumnName("plazo_apel_icl");
            builder.Property(e => e.PlazoRevAdministrativo).HasColumnName("plazo_rev_administrado");
            builder.Property(e => e.PlazoRevIcl).HasColumnName("plazo_rev_icl");
            builder.Property(e => e.RequiereCuc).HasColumnName("requiere_cuc");
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.EsParaVirtual).HasColumnName("es_para_virtual");

            builder.HasOne(e => e.TipoTramite).WithMany(b => b.Procedimiento).HasForeignKey(c => c.IdTipoTramite);
            builder.HasOne(e => e.Usuario).WithMany(b => b.Procedimientos).HasForeignKey(c => c.IdUsuario);

        }
    }
}
