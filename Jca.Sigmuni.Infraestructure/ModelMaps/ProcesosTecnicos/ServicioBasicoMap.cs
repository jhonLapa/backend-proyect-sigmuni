using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos
{
    public class ServicioBasicoMap : IEntityTypeConfiguration<ServicioBasico>
    {
        public void Configure(EntityTypeBuilder<ServicioBasico> builder)
        {
            builder.ToTable("servicio_basico", "fic");
            builder.HasKey(t => t.IdServicioBasico);
            builder.Property(t => t.IdServicioBasico).HasColumnName("id_servicio_basico").UseIdentityAlwaysColumn();
            builder.Property(t => t.IdLuz).HasColumnName("id_luz");
            builder.Property(t => t.IdAgua).HasColumnName("id_agua");
            builder.Property(t => t.IdTelefono).HasColumnName("id_telefono");
            builder.Property(t => t.IdDesague).HasColumnName("id_desague");
            builder.Property(t => t.IdInternet).HasColumnName("id_internet");
            builder.Property(t => t.IdCable).HasColumnName("id_cable");
            builder.Property(t => t.IdGas).HasColumnName("id_gas");
            builder.Property(t => t.IdFicha).HasColumnName("id_ficha");
            builder.Property(t => t.SuministroLuz).HasColumnName("nume_sum_luz");
            builder.Property(t => t.NumContratoAgua).HasColumnName("nume_contrato_agua");
            builder.Property(t => t.NumTelefono).HasColumnName("nume_telefono");
            builder.Property(t => t.SuministroGas).HasColumnName("suministro_gas");
            builder.Property(t => t.Anexo).HasColumnName("anexo");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(e => e.Ficha).WithMany(b => b.ServicioBasicos).HasForeignKey(c => c.IdFicha);
            builder.HasOne(e => e.TipoServicioBasicoAgua).WithMany(b => b.ServicioBasicoAgua).HasForeignKey(c => c.IdAgua);
            builder.HasOne(e => e.TipoServicioBasicoCable).WithMany(b => b.ServicioBasicoCable).HasForeignKey(c => c.IdCable);
            builder.HasOne(e => e.TipoServicioBasicoDesague).WithMany(b => b.ServicioBasicoDesague).HasForeignKey(c => c.IdDesague);
            builder.HasOne(e => e.TipoServicioBasicoGas).WithMany(b => b.ServicioBasicoGas).HasForeignKey(c => c.IdGas);
            builder.HasOne(e => e.TipoServicioBasicoInternet).WithMany(b => b.ServicioBasicoInternet).HasForeignKey(c => c.IdInternet);
            builder.HasOne(e => e.TipoServicioBasicoLuz).WithMany(b => b.ServicioBasicoLuz).HasForeignKey(c => c.IdLuz);
            builder.HasOne(e => e.TipoServicioBasicoTelefono).WithMany(b => b.ServicioBasicoTelefono).HasForeignKey(c => c.IdTelefono);
        }
    }
}
