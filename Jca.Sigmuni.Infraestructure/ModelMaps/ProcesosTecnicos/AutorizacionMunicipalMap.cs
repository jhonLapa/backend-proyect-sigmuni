using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class AutorizacionMunicipalMap : IEntityTypeConfiguration<AutorizacionMunicipal>
    {
        public void Configure(EntityTypeBuilder<AutorizacionMunicipal> builder)
        {
            builder.ToTable("aut_municipal", "fic");
            builder.HasKey(t => t.IdAutMunicipal);
            builder.Property(t => t.IdAutMunicipal).HasColumnName("id_aut_municipal").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.IdGiroAutorizado).HasColumnName("id_giro_autorizado");
            builder.Property(t => t.IdActividadVerificada).HasColumnName("id_actividad_verificada");
            
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.AutorizacionMunicipales).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.GiroAutorizado).WithMany(b => b.AutorizacionMunicipales).HasForeignKey(c => c.IdGiroAutorizado);
            builder.HasOne(e => e.ActividadVerificada).WithMany(b => b.AutorizacionMunicipales).HasForeignKey(c => c.IdActividadVerificada);
        }
    }
}
