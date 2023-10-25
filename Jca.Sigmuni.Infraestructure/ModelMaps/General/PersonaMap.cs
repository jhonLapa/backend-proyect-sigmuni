using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("persona", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_persona");
            builder.Property(e => e.NumeroDoc).HasColumnName("nume_doc").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.NumeroRuc).HasColumnName("numero_ruc").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Nombre).HasColumnName("nombres");
            builder.Property(e => e.Paterno).HasColumnName("ape_paterno").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Materno).HasColumnName("ape_materno").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.RazonSocial).HasColumnName("razon_social").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Direccion).HasColumnName("direccion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.IdTipoPersona).HasColumnName("id_tipo_persona");
            builder.Property(e => e.IdDocNatural).HasColumnName("id_doc_juridica");
            builder.Property(e => e.IdDocIdentidad).HasColumnName("id_doc_identidad");
            builder.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo");
            builder.Property(e => e.IdEstadoCivil).HasColumnName("id_estado_civil");
            builder.Property(e => e.CodigoContribuyente).HasColumnName("cod_contribuyente").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Asociacion).HasColumnName("asociacion").IsUnicode(false).HasMaxLength(100);

            builder.Property(e => e.IdCategoriaOrganizacion).HasColumnName("id_categoria_organizacion");
            builder.Property(e => e.IdExoneracionTitular).HasColumnName("id_exoneracion_titular");
            builder.Property(e => e.NumCartaPoder).HasColumnName("num_carta_poder");

            
            builder.Property(e => e.IdUsuarioAccion).HasColumnName("id_usuario_accion");
            builder.Property(e => e.IdRepresentanteLegal).HasColumnName("id_representante_legal");
            builder.Property(e => e.CartaPoder).HasColumnName("carta_poder");
            builder.Property(e => e.Ip).HasColumnName("ip_accion");

            builder.HasOne(e => e.RepresentanteLegalDD).WithMany(b => b.PersonaRL).HasForeignKey(c => c.IdRepresentanteLegal);

            builder.HasOne(e => e.DocumentoIdentidad).WithMany(b => b.Persona).HasForeignKey(c => c.IdDocIdentidad);
            builder.HasOne(e => e.TipoPersona).WithMany(b => b.Persona).HasForeignKey(c => c.IdTipoPersona);
            builder.HasOne(e => e.EstadoCivil).WithMany(b => b.Persona).HasForeignKey(c => c.IdEstadoCivil);
            builder.HasOne(e => e.CategoriaOrganizacion).WithMany(b => b.Persona).HasForeignKey(c => c.IdCategoriaOrganizacion);
            builder.HasOne(a => a.Usuario).WithOne(b => b.Persona).HasForeignKey<Usuario>(b => b.Id);
            builder.HasOne(a => a.Inspector).WithOne(b => b.Persona).HasForeignKey<Inspector>(b => b.Id);

            builder.HasOne(a => a.Ocupante).WithOne(b => b.Persona).HasForeignKey<Ocupante>(b => b.Id);
        }
    }
}
