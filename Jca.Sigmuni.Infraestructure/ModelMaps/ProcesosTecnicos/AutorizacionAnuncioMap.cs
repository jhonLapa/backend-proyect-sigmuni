using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class AutorizacionAnuncioMap : IEntityTypeConfiguration<AutorizacionAnuncio>
    {
        public void Configure(EntityTypeBuilder<AutorizacionAnuncio> builder)
        {
            builder.ToTable("autorizacion_anuncio","fic");
            builder.HasKey(t => t.IdAutorizacionAnuncio);
            builder.Property(t => t.IdAutorizacionAnuncio).HasColumnName("id_autorizacion_anuncio").UseIdentityAlwaysColumn();
            builder.Property(t => t.NumeLados).HasColumnName("nume_lados");
            builder.Property(t => t.AreaAutorizada).HasColumnName("area_autorizada");
            builder.Property(t => t.AreaVerificada).HasColumnName("area_verificada");
            builder.Property(t => t.NumeExpediente).HasColumnName("nume_expediente");
            builder.Property(t => t.NumeLicencia).HasColumnName("nume_licencia");
            builder.Property(t => t.IdTipoAnuncio).HasColumnName("id_tipo_anuncio");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.IdCondicionAnuncio).HasColumnName("id_condicion_anuncio");
            builder.Property(t => t.AnioAutorizacion).HasColumnName("anio_autorizacion");
            builder.Property(t => t.FechaExpedicion).HasColumnName("fecha_expedicion");
            builder.Property(t => t.FechaVencimiento).HasColumnName("fecha_vencimiento");
            
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.TipoAnuncio).WithMany(b => b.AutorizacionAnuncios).HasForeignKey(c => c.IdTipoAnuncio);
            builder.HasOne(e => e.CondicionAnuncio).WithMany(b => b.AutorizacionAnuncios).HasForeignKey(c => c.IdCondicionAnuncio);
            builder.HasOne(e => e.Ficha).WithMany(b => b.AutorizacionAnuncios).HasForeignKey(c => c.IdFicha);
        }
    }
}
