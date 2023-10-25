using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Jca.Sigmuni.Domain.Vias;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.Vias
{
    public class ViaMap : IEntityTypeConfiguration<Via>
    {
        public void Configure(EntityTypeBuilder<Via> builder)
        {
            builder.ToTable("via", "loc");
            builder.HasKey(t => t.IdVia);
            builder.Property(t => t.IdVia).HasColumnName("id_via");
            builder.Property(e => e.CodVia).HasColumnName("cod_via").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.NumeroCuadra).HasColumnName("numero_cuadra").IsUnicode(false).HasMaxLength(20);
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Frente).HasColumnName("frente").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Nota).HasColumnName("nota").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.Observacion).HasColumnName("observacion").IsUnicode(false).HasMaxLength(100);
            builder.Property(e => e.IdLado).HasColumnName("id_lado").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo");
            builder.Property(e => e.IdTipoVia).HasColumnName("id_tipo_via");
            builder.Property(e => e.NomenclaturaHistoricoI).HasColumnName("nomenclatura_historico_i");
            builder.Property(e => e.NomenclaturaHistoricoII).HasColumnName("nomenclatura_historico_ii");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario").IsUnicode(false).HasMaxLength(100);
            builder.HasOne(e => e.TipoVia).WithMany(b => b.Vias).HasForeignKey(c => c.IdTipoVia);


            //builder.HasOne(e => e.Ubigeo).WithMany(b => b.Via).HasForeignKey(c => c.CodigoUbigeo);

            //builder.HasMany(e => e.Domicilio).WithOne(b => b.Via).HasForeignKey(c => c.Id);

        }
    }
}
