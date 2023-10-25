using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class SupervisorMap : IEntityTypeConfiguration<Supervisor>
    {
        public void Configure(EntityTypeBuilder<Supervisor> builder)
        {
            builder.ToTable("supervisor", "ge");
            builder.HasKey(t => t.IdSupervisor);
            builder.Property(t => t.IdSupervisor).HasColumnName("id_supervisor").UseIdentityAlwaysColumn();
            builder.Property(e => e.Fecha).HasColumnName("fecha").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdPersona).HasColumnName("id_persona").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Firma).HasColumnName("firma").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.TieneFirma).HasColumnName("tiene_firma").IsUnicode(false).HasMaxLength(100);
           

            builder.HasOne(e => e.Ficha).WithMany(b => b.Supervisores).HasForeignKey(c => c.IdFicha);

            builder.HasOne(e => e.Persona).WithMany(b => b.Supervisores).HasForeignKey(c => c.IdPersona);
           
        }
    }
}
