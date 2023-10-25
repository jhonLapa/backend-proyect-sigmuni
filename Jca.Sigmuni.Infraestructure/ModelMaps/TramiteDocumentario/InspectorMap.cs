using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class InspectorMap : IEntityTypeConfiguration<Inspector>
    {
        public void Configure(EntityTypeBuilder<Inspector> builder)
        {
            builder.ToTable("inspector", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_inspector");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.IdTipoInspector).HasColumnName("id_tipo_inspector").IsRequired();
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdSupervisorInsp).HasColumnName("id_supervisor_insp");

            builder.HasOne(e => e.TipoInspector).WithMany(b => b.Inspector).HasForeignKey(c => c.IdTipoInspector);
            builder.HasOne(e => e.SupervisorInsp).WithMany(b => b.Inspectores).HasForeignKey(c => c.IdSupervisorInsp);
        }
    }
}

