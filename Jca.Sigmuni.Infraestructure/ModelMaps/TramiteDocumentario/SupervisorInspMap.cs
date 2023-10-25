using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class SupervisorInspMap : IEntityTypeConfiguration<SupervisorInsp>
    {
        public void Configure(EntityTypeBuilder<SupervisorInsp> builder)
        {
           builder.ToTable("supervisor_insp", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_supervisor_insp");
            builder.Property(e => e.IdPersona).HasColumnName("id_persona");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.Flag).HasColumnName("flag");

            //builder.HasOne(e => e.Persona).WithMany(b => b.SupervisorInspectores).HasForeignKey(c => c.IdPersona);
        }
    }
}
