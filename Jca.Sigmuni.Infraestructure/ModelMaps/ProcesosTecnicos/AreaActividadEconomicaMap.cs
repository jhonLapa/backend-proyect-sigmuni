using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class AreaActividadEconomicaMap : IEntityTypeConfiguration<AreaActividadEconomica>
    {
        public void Configure(EntityTypeBuilder<AreaActividadEconomica> builder)
        {
            builder.ToTable("area_actividad_economica", "fic");
            builder.HasKey(t => t.IdAreaActividadEconomica);
            builder.Property(t => t.IdAreaActividadEconomica).HasColumnName("id_area_actividad_economica").UseIdentityAlwaysColumn();
            builder.Property(t => t.PredioCatAutorizada).HasColumnName("predio_cat_autorizada");
            builder.Property(t => t.PredioCatVerificada).HasColumnName("predio_cat_verificada");
            builder.Property(t => t.BienComunAutorizada).HasColumnName("bien_comun_autorizda");
            builder.Property(t => t.BienComunVerificada).HasColumnName("bien_comun_verificada");
            builder.Property(t => t.TotalAutorizada).HasColumnName("total_autorizada");
            builder.Property(t => t.TotalVerificada).HasColumnName("total_verificada");
            builder.Property(t => t.NumExpediente).HasColumnName("num_expediente");
            builder.Property(t => t.NumLicencia).HasColumnName("num_licencia");
            builder.Property(t => t.InicioActividad).HasColumnName("inicio_actividad");
            builder.Property(t => t.FechaExpedicion).HasColumnName("fecha_expedicion");
            builder.Property(t => t.FechaVencimiento).HasColumnName("fecha_vencimiento");

            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.NumResolucion).HasColumnName("num_resolucion");
            builder.Property(t => t.CodCatAsigCorrect).HasColumnName("cod_cat_asig_correct");
            builder.Property(t => t.AnioAutorizacion).HasColumnName("anio_autorizacion");

            builder.Property(t => t.ViaPubAutorizada).HasColumnName("via_pub_autorizada");
            builder.Property(t => t.ViaPubVerificada).HasColumnName("via_pub_verificada");

            builder.HasOne(e => e.Ficha).WithMany(b => b.AreaActividadEconomicas).HasForeignKey(c => c.IdFicha);
            
        }
    }
}
