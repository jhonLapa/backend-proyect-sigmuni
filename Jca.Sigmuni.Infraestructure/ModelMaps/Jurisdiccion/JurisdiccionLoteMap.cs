using Jca.Sigmuni.Domain.Jurisdiccion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Jurisdiccion
{
    public class JurisdiccionLoteMap : IEntityTypeConfiguration<JurisdiccionLote>
    {
        public void Configure(EntityTypeBuilder<JurisdiccionLote> builder)
        {
            builder.ToTable("jurisdiccion", "ju");
           
            builder.HasKey(t => t.IdJurisdiccion);
            builder.Property(t => t.IdJurisdiccion).HasColumnName("id_jurisdiccion");
            builder.Property(e => e.NumeroOficioIcl).HasColumnName("numero_oficio_icl");
            builder.Property(e => e.NumeroOficioImp).HasColumnName("numero_oficio_imp");
            builder.Property(e => e.Nota).HasColumnName("nota");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdLoteCarto).HasColumnName("id_lote_carto");
            builder.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");

            builder.Property(e => e.numPlanoIGN).HasColumnName("num_plano_ign");
            builder.Property(e => e.FechaOficioIMP).HasColumnName("fecha_oficio_imp");

            builder.HasOne(e => e.Lote)
                .WithMany(b => b.JurisdiccionLote).HasForeignKey(c
                    => c.IdLoteCarto);

            builder.HasOne(e => e.Solicitud)
               .WithMany(b => b.JurisdiccionLote).HasForeignKey(c
                   => c.IdSolicitud);

            builder.HasOne(e => e.Ubigeo)
                .WithMany(b => b.JurisdiccionLote).HasForeignKey(c
                    => c.CodigoUbigeo);


           

        }
    }
}
