using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public  class ArchivoCartograficoMap : IEntityTypeConfiguration<ArchivoCartografico>
    {
        public void Configure(EntityTypeBuilder<ArchivoCartografico> builder)
        {
            builder.ToTable("archivo_cartografico", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_archivo_cartografico").IsRequired();
            builder.Property(e => e.Descripcion).HasColumnName("descripcion");
            builder.Property(e => e.IdDocumento).HasColumnName("id_documento");
            builder.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            builder.Property(e => e.flag).HasColumnName("flag");
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Documento).WithMany(b => b.ArchivoCartografico).HasForeignKey(c => c.IdDocumento);
            //builder.HasOne(e => e.ProductoCarto).WithMany(b => b.ProductoCartoArchivo).HasForeignKey(c => c.IdProductoCartografico);
        }
    }
}
