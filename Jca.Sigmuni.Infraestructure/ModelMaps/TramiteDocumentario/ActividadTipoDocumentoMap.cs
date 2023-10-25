using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class ActividadTipoDocumentoMap : IEntityTypeConfiguration<ActividadTipoDocumento>
    {
        public void Configure(EntityTypeBuilder<ActividadTipoDocumento> builder)
        {
            builder.ToTable("actividad_tipo_documento", "trd");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_actividad_tipo_documento").IsRequired();

            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdActividad).HasColumnName("id_actividad");
            builder.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");

            //builder.HasOne(p => p.Actividad).WithMany(b => b.ActividadTipoDocumentos).HasForeignKey(c => c.IdActividad);
            builder.HasOne(p => p.TipoDocumento).WithMany(b => b.ActividadTipoDocumentos).HasForeignKey(c => c.IdTipoDocumento);

        }
    }
}
