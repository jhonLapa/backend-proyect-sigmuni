using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario
{
    public class TramiteDocumentoMap : IEntityTypeConfiguration<TramiteDocumento>
    {
        public void Configure(EntityTypeBuilder<TramiteDocumento> builder)
        {
            builder.ToTable("tramite_documento", "trd");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tramite_documento").UseIdentityAlwaysColumn();
            builder.Property(t => t.Numero).HasColumnName("numero");
            builder.Property(t => t.Anio).HasColumnName("anio");
            builder.Property(t => t.FechaPrestamo).HasColumnName("fecha_prestamo");
            builder.Property(t => t.FechaDevolucion).HasColumnName("fecha_devolucion");
            builder.Property(t => t.IdInfDocumento).HasColumnName("id_inf_documento");
            builder.Property(t => t.IdUsuario).HasColumnName("id_usuario");
            builder.Property(t => t.IdSolicitante).HasColumnName("id_solicitante");
            builder.Property(t => t.FlagDevuelto).HasColumnName("flag_devolucion");
            builder.Property(t => t.FoliosPrestados).HasColumnName("folios_prestados");
            builder.Property(t => t.FoliosDevueltos).HasColumnName("folios_devueltos");
            builder.Property(t => t.DocumentoSolicita).HasColumnName("documento_solicita");
            builder.Property(t => t.DocumentoRetorna).HasColumnName("documento_retorna");
            builder.Property(t => t.IdTipoPrestamo).HasColumnName("id_tipo_prestamo");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
            builder.Property(t => t.FlagPrestamo).HasColumnName("flag_prestamo");
            builder.Property(t => t.FlagCopiaDigital).HasColumnName("flag_copia_digital");
            builder.Property(t => t.FlagConsulta).HasColumnName("flag_consulta");

            builder.HasOne(e => e.InfDocumento).WithMany(b => b.TramiteDocumento).HasForeignKey(c => c.IdInfDocumento);
            builder.HasOne(e => e.TipoPrestamo).WithMany(b => b.TramiteDocumento).HasForeignKey(c => c.IdTipoPrestamo);
            builder.HasOne(e => e.Persona).WithMany(b => b.TramiteDocumento).HasForeignKey(c => c.IdSolicitante);



        }
    }
}
