using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ConductorMap : IEntityTypeConfiguration<Conductor>
    {
        public void Configure(EntityTypeBuilder<Conductor> builder)
        {
            builder.ToTable("conductor", "fic");
            builder.HasKey(t => t.IdConductor);
            builder.Property(t => t.IdConductor).HasColumnName("id_conductor").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdCondicionConductor).HasColumnName("id_condicion_conductor");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.IdPersona).HasColumnName("id_persona");
            builder.Property(t => t.IdRepresentanteLegal).HasColumnName("id_representante_legal");
            builder.Property(t => t.NombreComercial).HasColumnName("nombre_comercial");
            builder.Property(t => t.NombreAsociacion).HasColumnName("nombre_asociacion");
            builder.Property(t => t.NumTrabajadores).HasColumnName("num_trabajadores");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Persona).WithMany(b => b.Conductores).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.CondicionConductor).WithMany(b => b.Conductores).HasForeignKey(c => c.IdCondicionConductor);
            builder.HasOne(e => e.Ficha).WithMany(b => b.Conductores).HasForeignKey(c => c.IdFicha);
        }
    }
}
