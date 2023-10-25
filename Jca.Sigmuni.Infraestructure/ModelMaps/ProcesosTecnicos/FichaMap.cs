using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class FichaMap : IEntityTypeConfiguration<Ficha>
    {
        public void Configure(EntityTypeBuilder<Ficha> builder)
        {
            builder.ToTable("ficha", "fic");
            builder.HasKey(t => t.IdFicha);
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha").UseIdentityAlwaysColumn();
            builder.Property(t => t.NumExpediente).HasColumnName("num_expediente");
            builder.Property(t => t.NtTf).HasColumnName("nt_tf");
            builder.Property(t => t.NumFicha).HasColumnName("num_ficha");
            builder.Property(t => t.Dc).HasColumnName("dc");
            builder.Property(t => t.IdTipoFicha).HasColumnName("id_tipo_ficha");
            builder.Property(t => t.IdUnidadCatastral).HasColumnName("id_unidad_catastral");
            builder.Property(t => t.IdLoteCarto).HasColumnName("id_lote_carto");
            builder.Property(t => t.AnioFicha).HasColumnName("anio_ficha");
            builder.Property(t => t.IdFichaPadre).HasColumnName("id_ficha_padre");
            builder.Property(t => t.TipoBienComun).HasColumnName("tipo_bien_comun");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.IdUsuario).HasColumnName("id_usuario");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Usuario).WithMany(b => b.Fichas).HasForeignKey(c => c.IdUsuario);
            builder.HasOne(e => e.TipoFicha).WithMany(b => b.Fichas).HasForeignKey(c => c.IdTipoFicha);
            builder.HasOne(e => e.UnidadCatastral).WithMany(b => b.Fichas).HasForeignKey(c => c.IdUnidadCatastral);
        }
    }
}
