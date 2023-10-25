using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Solicitud> _paginator;

        public SolicitudRepository(ApplicationDbContext context,IPaginator<Solicitud> paginator) 
        { 
            _context= context;
            _paginator= paginator;
        }

        public async Task<Solicitud> BuscarPorNumeroSolicitudAsync(string numeroSolitud, int? anioSolicitud)
        => await _context.Solicitudes.Where(x => x.NumeroSolicitud.Contains(numeroSolitud) && x.Estado == true && (!anioSolicitud.HasValue || x.AnioSolicitud == anioSolicitud)).FirstOrDefaultAsync();

        public Task<Solicitud> Create(Solicitud entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Solicitud?> Disable(int id)
        {
            var model = await _context.Solicitudes.FindAsync(id);
            if (model != null)
            {
                model.Estado= false;
                _context.Solicitudes.Update(model);
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public Task<Solicitud?> Edit(int id, Solicitud entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Solicitud?> Find(int id)
        =>  await _context.Solicitudes
            .Include(e=>e.TipoTramite)
            .Include(e=>e.Procedimiento)
            .Include(e=>e.Solicitante)
            .Include(e=>e.SolicitudCuc)
            .Include(e => e.SolicitudCuc).ThenInclude(e=>e.TipoPartidaRegistral)
            .Include(e => e.SolicitudCuc).ThenInclude(e => e.UnidadCatastral)
            .Include(e => e.SolicitudCuc).ThenInclude(e => e.UnidadCatastral).ThenInclude(e=>e.TblCodigo)
            .Include(e => e.SolicitudRequisitos).ThenInclude(x=>x.Documento)
            .Include(e => e.SolicitudRequisitos).ThenInclude(x => x.ProcedimientoRequisito)
            .Include(e => e.SolicitudRequisitos).ThenInclude(x => x.ProcedimientoRequisito).ThenInclude(x=>x.Requisito)
            .Include(e => e.TipoDocumentoSimple)
            .Include(e => e.Solicitante).ThenInclude(x=>x.DocumentoIdentidad)
            .Include(e => e.Solicitante).ThenInclude(x=>x.TipoPersona)
            .Include(e => e.Solicitante).ThenInclude(x=>x.Domicilio)
            .Include(e => e.Solicitante).ThenInclude(x => x.Domicilio).ThenInclude(x=>x.TipoVia)
            .Include(e => e.Solicitante).ThenInclude(x => x.Domicilio).ThenInclude(x => x.Ubigeo)
            .Include(e => e.Solicitante).ThenInclude(x => x.Domicilio).ThenInclude(x => x.Via)
            .Include(e => e.Solicitante).ThenInclude(x => x.Domicilio).ThenInclude(x => x.Edificacion).ThenInclude(x=>x.TipoAgrupacion)
            .Include(e => e.Solicitante).ThenInclude(x => x.Domicilio).ThenInclude(x => x.HabilitacionUrbana)
            .Include(e => e.Solicitante).ThenInclude(x => x.InfoContacto)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.DocumentoIdentidad)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.TipoPersona)
            .Include(e=>e.RepresentanteLegal).ThenInclude(x=>x.Domicilio)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.Domicilio).ThenInclude(x => x.TipoVia)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.Domicilio).ThenInclude(x => x.Ubigeo)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.Domicilio).ThenInclude(x => x.Via)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.Domicilio).ThenInclude(x => x.Edificacion).ThenInclude(x => x.TipoAgrupacion)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.Domicilio).ThenInclude(x => x.HabilitacionUrbana)
            .Include(e => e.RepresentanteLegal).ThenInclude(x => x.InfoContacto)
            .Include(e => e.Pagos).ThenInclude(x=>x.Moneda)
            .Include(e => e.Pagos).ThenInclude(x => x.MedioPago)
            .DefaultIfEmpty()
            .Where(x=>x.Id==id)
            .FirstOrDefaultAsync();

        public async Task<IList<Solicitud>> FindAll()
        =>await _context.Solicitudes
            .Include(e => e.InfDocumento)
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Solicitud>> PaginatedSearch(RequestPagination<Solicitud> entity)
        {
            var filter =entity.Filter;
            var query = _context.Solicitudes
                .Include(x=>x.Procedimiento)
                .Include(x=>x.Solicitante)
                .Include(x=>x.TipoTramite)

                .AsQueryable();
            if (filter != null)
            { 
                query =query.Where(e=>(!filter.Estado.HasValue|| e.Estado==filter.Estado)
                &&(!filter.IdTipoTramite.HasValue|| e.IdTipoTramite==filter.IdTipoTramite)
                &&(!filter.IdProcedimiento.HasValue || e.IdProcedimiento == filter.IdProcedimiento)
                && (string.IsNullOrWhiteSpace(filter.NumeroSolicitud) || e.NumeroSolicitud.ToUpper().Contains(filter.NumeroSolicitud.ToUpper()))
                && (string.IsNullOrWhiteSpace(filter.NumeroSolicitud) || e.NumeroExpediente.ToUpper().Contains(filter.NumeroSolicitud.ToUpper()))
                && (!filter.AnioSolicitud.HasValue||e.AnioSolicitud==filter.AnioSolicitud)
                );
            }
            query = query.OrderByDescending(e => e.Id);
            var response =await _paginator.Paginate(query, entity);
            return response;
        }

        public async Task<Solicitud> BuscarxNumeroSolicitudCucAsync(string numeroSolicitud)
        {
            var response = await _context.Solicitudes
                    .Include(s => s.Procedimiento)
                    .Include(s => s.Solicitante)

                    .Where(s => s.NumeroSolicitud == numeroSolicitud 
                    //&& (
                    //s.Procedimiento.TipoTramite.Descripcion == "TUPA" ||
                     // s.Procedimiento.TipoTramite.Descripcion == "TUSNE")
                    && s.Estado == true)
                    .FirstOrDefaultAsync();
            return response;
        }

        public async Task<List<SolicitudRequisito>> ListarxSolicitudAsync(int idSolicitud)
        {
            var response = await _context.SolicitudRequisitos
                    .Include(c => c.ProcedimientoRequisito).ThenInclude(e => e.Requisito)
                    .Include(c => c.Documento)
                    .Where(c => c.IdSolicitud == idSolicitud && c.Estado == true)
                    .ToListAsync();

            return response;
        }

        public async Task<Solicitud> ObtenerPorNumeroSolicitud(string numeroSolicitud)
        => await  _context.Solicitudes.Where(e=>e.NumeroSolicitud==numeroSolicitud).FirstOrDefaultAsync();


        public async Task<List<Solicitud>> ObtenerPorAnioSolicitud(int anio)
        {
            var response = await _context.Solicitudes
                  .Include(c => c.Solicitante)
                    .Where(c => c.AnioSolicitud == anio && c.Estado == true)
                    .ToListAsync();

            return response;
        }

        public async Task<Solicitud> ObtenerUltimoSolicitud()
        {
            string sqlQuery = "SELECT * from trd.generar_numero_solicitud()";
            Solicitud data=new Solicitud();
            using DbConnection dbConnection = _context.Database.GetDbConnection();

            using DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            await dbConnection.OpenAsync();
            using IDataReader reader = await dbCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                data.NumeroSolicitud = !reader.IsDBNull(reader.GetOrdinal("numero_correlativo")) ? reader.GetString(reader.GetOrdinal("numero_correlativo")) : null;
                data.AnioSolicitud = !reader.IsDBNull(reader.GetOrdinal("anio")) ? reader.GetInt32(reader.GetOrdinal("anio")) : 0;
            }
            reader.Close();

            return data;

        }

        public async Task<ResponsePagination<SolicitudBusqueda>> PaginatedSearhSolicitud(RequestPagination<SolicitudBusqueda> entity)
        {
            IList<SolicitudBusqueda> data=new List<SolicitudBusqueda>();
            string sqlQuery = "SELECT * from trd.solicitud_select_paginated(@p_id_tramite ,@p_asunto ,@p_numero_solicitud ,@p_anio ,@p_creacion_desde ,@p_creacion_hasta ,@p_id_area ,@p_estado ,@p_id_tipo_documento_simple ,@p_id_tipo_persona ,@p_num_doc ,@p_nombres ,@p_page , @p_per_page )";
            var filter = entity?.Filter;
            int total = 0;

            using DbConnection dbConnection= _context.Database.GetDbConnection();

            using DbCommand dbCommand= dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;

            //Parameters start
            var p_id_tramite = dbCommand.CreateParameter();
            p_id_tramite.ParameterName = "@p_id_tramite";
            p_id_tramite.Value=filter?.IdTipoTramite?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_id_tramite);

            var p_asunto = dbCommand.CreateParameter();
            p_asunto.ParameterName = "@p_asunto";
            p_asunto.Value = filter?.IdProcedimiento ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_asunto);

            var p_numero_solicitud = dbCommand.CreateParameter();
            p_numero_solicitud.ParameterName = "@p_numero_solicitud";
            p_numero_solicitud.Value = filter?.NumeroSolicitud ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_numero_solicitud);

            var p_anio = dbCommand.CreateParameter();
            p_anio.ParameterName = "@p_anio";
            p_anio.Value = filter?.AnioSolicitud ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_anio);

            var p_creacion_desde = dbCommand.CreateParameter();
            p_creacion_desde.ParameterName = "@p_creacion_desde";
            p_creacion_desde.Value = filter?.FechaRegistroDesde ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_creacion_desde);

            var p_creacion_hasta = dbCommand.CreateParameter();
            p_creacion_hasta.ParameterName = "@p_creacion_hasta";
            p_creacion_hasta.Value = filter?.FechaRegistroHasta ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_creacion_hasta);

            var p_id_area = dbCommand.CreateParameter();
            p_id_area.ParameterName = "@p_id_area";
            p_id_area.Value = filter?.IdArea ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_id_area);

            var p_estado = dbCommand.CreateParameter();
            p_estado.ParameterName = "@p_estado";
            p_estado.Value = filter?.Estado ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_estado);

            var p_id_tipo_documento_simple = dbCommand.CreateParameter();
            p_id_tipo_documento_simple.ParameterName = "@p_id_tipo_documento_simple";
            p_id_tipo_documento_simple.Value = filter?.IdTipoDocumentoSimple ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_id_tipo_documento_simple);

            var p_id_tipo_persona = dbCommand.CreateParameter();
            p_id_tipo_persona.ParameterName = "@p_id_tipo_persona";
            p_id_tipo_persona.Value = filter?.IdTipoPersona ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_id_tipo_persona);

            var p_num_doc = dbCommand.CreateParameter();
            p_num_doc.ParameterName = "@p_num_doc";
            p_num_doc.Value = filter?.NumDoc ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_num_doc);

            var p_nombres = dbCommand.CreateParameter();
            p_nombres.ParameterName = "@p_nombres";
            p_nombres.Value = filter?.Nombres ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_nombres);

            var p_page = dbCommand.CreateParameter();
            p_page.ParameterName = "@p_page";
            p_page.Value = entity.Page;
            dbCommand.Parameters.Add(p_page);

            var p_per_page = dbCommand.CreateParameter();
            p_per_page.ParameterName = "@p_per_page";
            p_per_page.Value = entity.PerPage;
            dbCommand.Parameters.Add(p_per_page);
            //Parameters end

            await dbConnection.OpenAsync();
            using IDataReader reader= await dbCommand.ExecuteReaderAsync();

            //if (reader.Read())
            //    total = !reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0;

            while (reader.Read())
            {
                total = !reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0;
                var item = new SolicitudBusqueda()
                {
                    Id= !reader.IsDBNull(reader.GetOrdinal("id_solicitud")) ? reader.GetInt32(reader.GetOrdinal("id_solicitud")) : 0,
                    NumeroSolicitud= !reader.IsDBNull(reader.GetOrdinal("numero_solicitud")) ? reader.GetString(reader.GetOrdinal("numero_solicitud")) : null,
                    AnioSolicitud= !reader.IsDBNull(reader.GetOrdinal("anio_solicitud")) ? reader.GetInt32(reader.GetOrdinal("anio_solicitud")) : 0,
                    TipoTramite= !reader.IsDBNull(reader.GetOrdinal("tipo_tramite")) ? reader.GetString(reader.GetOrdinal("tipo_tramite")) : null,
                    Asunto= !reader.IsDBNull(reader.GetOrdinal("asunto_tramite")) ? reader.GetString(reader.GetOrdinal("asunto_tramite")) : null,
                    Solicitante= !reader.IsDBNull(reader.GetOrdinal("solicitante")) ? reader.GetString(reader.GetOrdinal("solicitante")) : null,
                    TipoDocumento = !reader.IsDBNull(reader.GetOrdinal("tipo_documento")) ? reader.GetString(reader.GetOrdinal("tipo_documento")) : null,
                    FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("fecha_registro")) ? reader.GetDateTime(reader.GetOrdinal("fecha_registro")) : new DateTime?(),
                    Estado= !reader.IsDBNull(reader.GetOrdinal("estado")) ? reader.GetBoolean(reader.GetOrdinal("estado")) : null,
                    NumeroDocumento= !reader.IsDBNull(reader.GetOrdinal("numero_documento")) ? reader.GetString(reader.GetOrdinal("numero_documento")) : null,
                };
                data.Add(item);
            }
            reader.Close();
            var pagination = new Pagination(total, entity.Page, entity.PerPage);
            var response = new ResponsePagination<SolicitudBusqueda>(pagination)
            {
                Data = data
            };
            return response;
        }
    }
}
