using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class SunarpMap : IEntityTypeConfiguration<Sunarp>
    {
        public void Configure(EntityTypeBuilder<Sunarp> builder)
        {
            builder.ToTable("sunarp", "fic");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_sunarp").UseIdentityAlwaysColumn();
            builder.Property(e => e.NumeroPartida).HasColumnName("nume_partida");
            builder.Property(e => e.Fojas).HasColumnName("fojas");
            builder.Property(e => e.Asiento).HasColumnName("asiento");
            builder.Property(e => e.FechaInscripcion).HasColumnName("fecha_inscripcion");
            builder.Property(e => e.AsientoFabrica).HasColumnName("asie_fabrica");
            builder.Property(e => e.DeclaratoriaFabrica).HasColumnName("declaratoria_fabrica");
            builder.Property(e => e.FechaFabrica).HasColumnName("fecha_fabrica");
            builder.Property(e => e.IdTipoPartidaRegistral).HasColumnName("id_tipo_partida_registral");
            builder.Property(e => e.IdTipoTituloInscrito).HasColumnName("id_tipo_titulo_inscrito");
            builder.Property(e => e.IdFicha).HasColumnName("id_ficha");
            builder.Property(e => e.IdMonumentoPre).HasColumnName("id_monumento_pre");
            builder.Property(e => e.IdMonumentoColonial).HasColumnName("id_monumento_colonial");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.Sunarps).HasForeignKey(c => c.IdFicha);    
            builder.HasOne(e => e.TipoPartidaRegistral).WithMany(b => b.Sunarps).HasForeignKey(c => c.IdTipoPartidaRegistral);
            builder.HasOne(e => e.TipoTituloInscrito).WithMany(b => b.Sunarps).HasForeignKey(c => c.IdTipoTituloInscrito);
            builder.HasOne(e => e.MonumentoPreinspanico).WithMany(b => b.Sunarp).HasForeignKey(c => c.IdMonumentoPre);
            builder.HasOne(e => e.MonumentoColonial).WithMany(b => b.Sunarp).HasForeignKey(c => c.IdMonumentoColonial);

        }
    }
}
