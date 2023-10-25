using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class InfoContactoMap : IEntityTypeConfiguration<InfoContacto>
    {
        public void Configure(EntityTypeBuilder<InfoContacto> builder) 
        {
            builder.ToTable("info_contacto", "ge");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id_info_contacto");
            builder.Property(e => e.Telefono).HasColumnName("telefono").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Correo).HasColumnName("correo").IsUnicode(false).HasMaxLength(400);
            builder.Property(e => e.Anexo).HasColumnName("anexo").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Fax).HasColumnName("fax").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdPersona).HasColumnName("id_persona").IsRequired();
            builder.Property(e => e.IdTipoPersona).HasColumnName("id_tipo_persona").IsRequired();
            builder.Property(e => e.IdUsuarioAccion).HasColumnName("id_usuario_accion");
            builder.Property(e => e.Ip).HasColumnName("ip_accion");
            builder.HasOne(e => e.Persona).WithMany(b => b.InfoContacto).HasForeignKey(c => c.IdPersona);
            builder.HasOne(e => e.TipoPersona).WithMany(b => b.InfoContacto).HasForeignKey(c => c.IdTipoPersona);
        }
    }
}
