using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ConstruccionRepository : IConstruccionRepository
    {
        private readonly ApplicationDbContext _context;

        public ConstruccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Construccion> Create(Construccion entity)
        {
            _context.Construcciones.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Construccion?> Find(int id)
        => await _context.Construcciones.DefaultIfEmpty()
                                        .FirstOrDefaultAsync(i => i.IdConstruccion.Equals(id));

        public Task<IList<Construccion>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Construcciones.FindAsync(id);

            if (model != null)
            {
                _context.Construcciones.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<Construccion>> ListarPorIdFichaAsync(int idFicha)
        => await _context.Construcciones.Include(f => f.Mep)
                                        .Include(f => f.Ecs)
                                        .Where(e => e.IdFicha == idFicha).ToListAsync();

        //public async Task<List<Construccion>> BuscarPorIdLoteCartografiaAsync(string IdLoteCartografia)
        //  => await _context.Construcciones.Where(x => x.Ficha.IdLoteCarto == IdLoteCartografia && x.Estado == true)
        //    .ToListAsync();

        public async Task<List<Construccion>> BuscarPorIdLoteCartografiaAsync(string IdLoteCartografia)
        {
            var data = new List<Construccion>();

            string sqlQuery = "select * from loc.obtener_construccion_lote_ficha(@P_ID_LOTE_CARTO)";

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                bool wasOpen = cmd.Connection.State == ConnectionState.Open;
                if (!wasOpen) cmd.Connection.Open();
                try
                {
                    cmd.CommandText = sqlQuery;
                    var p_id = cmd.CreateParameter();
                    p_id.ParameterName = "@P_ID_LOTE_CARTO";
                    p_id.Value = IdLoteCartografia ?? (object)DBNull.Value;
                    cmd.Parameters.Add(p_id);

                    using IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new Construccion()
                        {
                            NumeroPiso = !reader.IsDBNull(reader.GetOrdinal("nume_piso")) ? reader.GetString(reader.GetOrdinal("nume_piso")) : null,
                            EstructuraMuroColumna = !reader.IsDBNull(reader.GetOrdinal("estr_muro_col")) ? reader.GetString(reader.GetOrdinal("estr_muro_col")) : null,
                            EstructuraTecho = !reader.IsDBNull(reader.GetOrdinal("estr_techo")) ? reader.GetString(reader.GetOrdinal("estr_techo")) : null,
                            AcabadoPiso = !reader.IsDBNull(reader.GetOrdinal("acab_piso")) ? reader.GetString(reader.GetOrdinal("acab_piso")) : null,
                            AcabadoPuertaVentana = !reader.IsDBNull(reader.GetOrdinal("acab_puerta_ven")) ? reader.GetString(reader.GetOrdinal("acab_puerta_ven")) : null,
                            AcabadoRevestimiento = !reader.IsDBNull(reader.GetOrdinal("acab_revest")) ? reader.GetString(reader.GetOrdinal("acab_revest")) : null,
                            AcabadoBanio = !reader.IsDBNull(reader.GetOrdinal("acab_bano")) ? reader.GetString(reader.GetOrdinal("acab_bano")) : null,
                            InstalacionElectricaSanitaria = !reader.IsDBNull(reader.GetOrdinal("ins_elect_sanita")) ? reader.GetString(reader.GetOrdinal("ins_elect_sanita")) : null,
                            AreaVerificada = !reader.IsDBNull(reader.GetOrdinal("area_verificada")) ? reader.GetDecimal(reader.GetOrdinal("area_verificada")) : null,
                            AreaTechadaDeclarada = !reader.IsDBNull(reader.GetOrdinal("area_declarada")) ? reader.GetDecimal(reader.GetOrdinal("area_declarada")) : null,
                        };

                        data.Add(item);
                    }

                    return data;
                }
                finally
                {
                    if (!wasOpen) cmd.Connection.Close();
                }
            }
        }

        public async Task<Construccion?> Edit(int id, Construccion entity)
        {
            var model = await _context.Construcciones.FindAsync(id);

            if (model != null)
            {
                model.NumeroPiso = entity.NumeroPiso;
                model.EstructuraMuroColumna = entity.EstructuraMuroColumna;
                model.EstructuraTecho = entity.EstructuraTecho;
                model.AcabadoPiso = entity.AcabadoPiso;
                model.AcabadoPuertaVentana = entity.AcabadoPuertaVentana;
                model.AcabadoRevestimiento = entity.AcabadoRevestimiento;
                model.AcabadoBanio = entity.AcabadoBanio;
                model.InstalacionElectricaSanitaria = entity.InstalacionElectricaSanitaria;
                model.AreaVerificada = entity.AreaVerificada;
                model.AreaTechadaDeclarada = entity.AreaTechadaDeclarada;
                model.ValorUnitario = entity.ValorUnitario;
                model.PorcentajeValorDepreciado = entity.PorcentajeValorDepreciado;
                model.ValorDepreciado = entity.ValorDepreciado;
                model.PorcentajeAreaComun = entity.PorcentajeAreaComun;
                model.ValorAreaComun = entity.ValorAreaComun;
                model.ValorConstruccion = entity.ValorConstruccion;
                model.IdMep = entity.IdMep;
                model.IdEcs = entity.IdEcs;
                model.IdEcc = entity.IdEcc;
                model.IdUca = entity.IdUca;
                model.IdFicha = entity.IdFicha;
                model.IdEd = entity.IdEd;
                model.IdEdificacionIndustrial = entity.IdEdificacionIndustrial;
                model.MesAnio = entity.MesAnio;
                model.Estado = entity.Estado;

                _context.Construcciones.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<Construccion?> Disable(int id)
        {
            throw new NotImplementedException();
        }
    }
}
