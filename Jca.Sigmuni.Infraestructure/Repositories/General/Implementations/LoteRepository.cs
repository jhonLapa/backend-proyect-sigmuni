using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class LoteRepository : ILoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Lote> _paginator;

        public LoteRepository(ApplicationDbContext context, IPaginator<Lote> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<Lote>> FindAll()
       => await _context.Lotes
            .Include(x => x.Manzana).ThenInclude(t => t.Sector).ThenInclude(p => p.Ubigeo)
           .Where(e => e.Estado == true)
           .OrderByDescending(e => e.Id)
           .ToListAsync();

        public async Task<Lote?> Find(string id)
      => await _context.Lotes

          .Include(x => x.Manzana).ThenInclude(t => t.Sector).ThenInclude(p => p.Ubigeo)
          .DefaultIfEmpty()
              .FirstOrDefaultAsync(i => i.Id.Equals(id));
        //public async Task<Lote?> Find(string id)
        //{
        //    var response = await _context.Lotes.Where(i => i.Id == id).FirstOrDefaultAsync();

        //    return response;
        //}

        public async Task<ResponsePagination<Lote>> PaginatedSearch(RequestPagination<Lote> entity)
        {

            var filter = entity.Filter;
            var query = _context.Lotes
            .Include(x => x.Manzana).ThenInclude(t => t.Sector).ThenInclude(p => p.Ubigeo)
            .AsQueryable();

            if (filter != null)
            {
                var CodMzn = filter.Manzana?.Codigo;
                var CodSec = filter.Manzana?.Sector?.Codigo;
                var CodUbigeo = filter.Manzana?.Sector?.Ubigeo?.Codigo;
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(CodMzn) || e.Manzana.Codigo == filter.Manzana.Codigo)
                    && (string.IsNullOrWhiteSpace(CodSec) || e.Manzana.Sector.Codigo == filter.Manzana.Sector.Codigo)
                    && (string.IsNullOrWhiteSpace(CodUbigeo) || e.Manzana.Sector.Ubigeo.Codigo == filter.Manzana.Sector.Ubigeo.Codigo)
                //&& (string.IsNullOrWhiteSpace(filter.Manzana.Sector.Codigo) || e.Manzana.Sector.Codigo.ToUpper().Contains(filter.Manzana.Sector.Codigo.ToUpper().Trim()))
                //&& (string.IsNullOrWhiteSpace(filter.Manzana.Sector.Ubigeo.Codigo) || e.Manzana.Sector.Ubigeo.Codigo.ToUpper().Contains(filter.Manzana.Sector.Ubigeo.Codigo.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }

        public async Task<Lote?> BuscarCucMaximo()
        => await _context.Lotes.OrderByDescending(e => e.CUC).FirstOrDefaultAsync();

        public async Task<bool?> EditLote(Lote entity)
        {

            _context.Update(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }


        public async Task<LoteDetalle> ObtenerCabeceraPorLote(string idLoteCarto)
        {
            var data = new LoteDetalle();
            string sqlQuery = "SELECT * from loc.busqueda_por_lote_general(@P_ID_LOTE_CARTO)";

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                bool wasOpen = cmd.Connection.State == ConnectionState.Open;
                if (!wasOpen) cmd.Connection.Open();
                try
                {
                    cmd.CommandText = sqlQuery;
                    var p_id = cmd.CreateParameter();
                    p_id.ParameterName = "@P_ID_LOTE_CARTO";
                    p_id.Value = idLoteCarto ?? (object)DBNull.Value;
                    cmd.Parameters.Add(p_id);

                    using IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new LoteDetalle()
                        {
                            Ubigeo = !reader.IsDBNull(reader.GetOrdinal("CODIGO_UBIGEO")) ? reader.GetString(reader.GetOrdinal("CODIGO_UBIGEO")) : null,
                            Sector = !reader.IsDBNull(reader.GetOrdinal("SECTOR")) ? reader.GetString(reader.GetOrdinal("SECTOR")) : null,
                            Manzana = !reader.IsDBNull(reader.GetOrdinal("MANZANA")) ? reader.GetString(reader.GetOrdinal("MANZANA")) : null,
                            Lote = !reader.IsDBNull(reader.GetOrdinal("LOTE")) ? reader.GetString(reader.GetOrdinal("LOTE")) : null,
                            PartidaRegistral = !reader.IsDBNull(reader.GetOrdinal("NUM_PARTIDA_REGISTRAL")) ? reader.GetString(reader.GetOrdinal("NUM_PARTIDA_REGISTRAL")) : null,
                            CodigoUnicoCatastral = !reader.IsDBNull(reader.GetOrdinal("CODIGO_CATASTRAL")) ? reader.GetString(reader.GetOrdinal("CODIGO_CATASTRAL")) : null,
                            TotalUnidadCatastral = !reader.IsDBNull(reader.GetOrdinal("TOTAL_UNIDAD")) ? reader.GetInt32(reader.GetOrdinal("TOTAL_UNIDAD")) : null,
                            CodigoZonificacion = !reader.IsDBNull(reader.GetOrdinal("COD_ZONIFICACION")) ? reader.GetString(reader.GetOrdinal("COD_ZONIFICACION")) : null,
                            Zonificacion = !reader.IsDBNull(reader.GetOrdinal("ZONIFICACION")) ? reader.GetString(reader.GetOrdinal("ZONIFICACION")) : null,
                            CodigoHabilitacionUrbana = !reader.IsDBNull(reader.GetOrdinal("CODIGO_HABILITACION_URBANA")) ? reader.GetString(reader.GetOrdinal("COD_HABILITACION_URBANA")) : null,
                            HabilitacionUrbana = !reader.IsDBNull(reader.GetOrdinal("HABILITACION_URBANA")) ? reader.GetString(reader.GetOrdinal("HABILITACION_URBANA")) : null,
                            FrenteCampo = !reader.IsDBNull(reader.GetOrdinal("FRENTE_CAMPO")) ? reader.GetString(reader.GetOrdinal("FRENTE_CAMPO")) : null,
                            DerechaCampo = !reader.IsDBNull(reader.GetOrdinal("DERECHA_CAMPO")) ? reader.GetString(reader.GetOrdinal("DERECHA_CAMPO")) : null,
                            IzquierdaCampo = !reader.IsDBNull(reader.GetOrdinal("IZQUIERDA_CAMPO")) ? reader.GetString(reader.GetOrdinal("IZQUIERDA_CAMPO")) : null,
                            FondoCampo = !reader.IsDBNull(reader.GetOrdinal("FONDO_CAMPO")) ? reader.GetString(reader.GetOrdinal("FONDO_CAMPO")) : null,
                            AreaLibre = !reader.IsDBNull(reader.GetOrdinal("AREA_LIBRE")) ? reader.GetString(reader.GetOrdinal("AREA_LIBRE")) : null,
                            LoteAntirreglamentario = !reader.IsDBNull(reader.GetOrdinal("LOTE_ANTIRREGLAMENTARIO")) ? reader.GetString(reader.GetOrdinal("LOTE_ANTIRREGLAMENTARIO")) : null,
                            AreaVerificada = !reader.IsDBNull(reader.GetOrdinal("AREA_VERIFICADA")) ? reader.GetString(reader.GetOrdinal("AREA_VERIFICADA")) : null,
                            EstadoConservacion = !reader.IsDBNull(reader.GetOrdinal("ESTADO_CONSERVACION")) ? reader.GetString(reader.GetOrdinal("ESTADO_CONSERVACION")) : null,
                            NumeroPiso = !reader.IsDBNull(reader.GetOrdinal("NUME_PISO")) ? reader.GetString(reader.GetOrdinal("NUM_PISO")) : null,
                            TotalAreaTechada = !reader.IsDBNull(reader.GetOrdinal("TOTAL_AREA_TECHADA")) ? reader.GetInt32(reader.GetOrdinal("TOTAL_AREA_TECHADA")) : null,
                            Arancel = !reader.IsDBNull(reader.GetOrdinal("ARANCEL")) ? reader.GetString(reader.GetOrdinal("ARANCEL")) : null,
                            MzUrbana = !reader.IsDBNull(reader.GetOrdinal("MANZANA_URBANO")) ? reader.GetString(reader.GetOrdinal("MANZANA_URBANO")) : null,
                            LoteUrbano = !reader.IsDBNull(reader.GetOrdinal("LOTE_URBANO")) ? reader.GetString(reader.GetOrdinal("LOTE_URBANO")) : null,
                            UsoPredominante = !reader.IsDBNull(reader.GetOrdinal("USO_PREDOMINANTE")) ? reader.GetString(reader.GetOrdinal("USO_PREDOMINANTE")) : null,
                        };

                        data = item;
                    }
                    return data;
                }
                finally
                {
                    if (!wasOpen) cmd.Connection.Close();
                }
            }
        }

        public async Task<List<LoteDetalleVia>> ObtenerDetallePorLote(string idLoteCarto)
        {
            var data = new List<LoteDetalleVia>();
            string sqlQuery = "SELECT * from loc.BUSQUEDA_POR_LOTE_VIAS(@P_ID_LOTE_CARTO)";

            using DbConnection connection = _context.Database.GetDbConnection();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = sqlQuery;

            // Parameters start
            var p_id = command.CreateParameter();
            p_id.ParameterName = "@P_ID_LOTE_CARTO";
            p_id.Value = idLoteCarto ?? (object)DBNull.Value;
            command.Parameters.Add(p_id);

            await connection.OpenAsync();

            using IDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                var item = new LoteDetalleVia
                {
                    Id = !reader.IsDBNull(reader.GetOrdinal("ID_LOTE_DIRECCION")) ? reader.GetString(reader.GetOrdinal("ID_LOTE_DIRECCION")) : null,
                    NombreVia = !reader.IsDBNull(reader.GetOrdinal("NOMBRE_VIA")) ? reader.GetString(reader.GetOrdinal("NOMBRE_VIA")) : null,
                    NumeroMunicipal = !reader.IsDBNull(reader.GetOrdinal("NUMERO_MUNICIPAL")) ? reader.GetString(reader.GetOrdinal("NUMERO_MUNICIPAL")) : null
                };
                data.Add(item);
            }
            return data;
        }
    }
}
