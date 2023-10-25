using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Producto> _paginator;

        public ProductoRepository(ApplicationDbContext context, IPaginator<Producto> paginator)
        {
            _context = context;
            _paginator = paginator;
        }


        public async Task<Producto> BuscarPorIdAsync(int id)
           => await _context.Productos.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<Producto> BuscarMaxCertificadoAsync(int flag)
     => await _context.Productos
         .Where(e => e.Estado == true && e.Flag == flag)
         .OrderByDescending(e => e.Id)
         .FirstOrDefaultAsync();


        public async Task<Producto> BuscarMaxNumeroCorrelativoAsyn(int flag)
         => await _context.Productos
              .Where(e => e.Flag == flag)
              .OrderByDescending(e => e.Id)
              .FirstOrDefaultAsync();

        public async Task<Producto> BuscarPorNumeroCorrelativoAsync(string numCorrelativo, int flag)
           => await _context.Productos.Where(x => x.NumCorrelativo == numCorrelativo && x.Flag == flag)
               .FirstOrDefaultAsync();

        public async Task<Producto> BuscarSolicitudRegistradaAsync(int idSolicitud)
        => await _context.Productos.Where(x => x.IdSolicitud == idSolicitud && x.Estado == true)
            .FirstOrDefaultAsync();


        public async Task<Producto> ObtenerSolicitudPorNumSolicitud(string numSolicitud)
          => await _context.Productos.Include(x => x.Solicitud).Where(e => e.Estado == true && e.Solicitud.NumeroSolicitud == numSolicitud).FirstOrDefaultAsync();

        public async Task<Producto> Create(Producto entity)
        {
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Producto?> EstadoGeneradoProducto(int id)
        {
            var model = await _context.Productos.FindAsync(id);

            if (model != null)
            {
                model.EsProducto = true;
                _context.Productos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Producto?> Edit(int id, Producto entity)
        {
            var model = await _context.Productos.FindAsync(id);

            _context.Productos.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }



        public async Task<ResponsePagination<Producto>> PaginatedSearch(RequestPagination<Producto> entity)
        {
            var filter = entity.Filter;
            var query = _context.Productos
                .Include(x => x.Solicitud).ThenInclude(x => x.Procedimiento).ThenInclude(x => x.TipoTramite)
                .Include(x => x.Solicitud).ThenInclude(x => x.Solicitante)
                .Where(x => x.EsProducto == true)
                 
                .AsQueryable();
            if (filter != null)
            {
                query = query.Where(e => (!filter.Estado.HasValue || e.Estado == filter.Estado)
                && (string.IsNullOrWhiteSpace(filter.NumCorrelativo) || e.NumCorrelativo.ToUpper().Contains(filter.NumCorrelativo.ToUpper().Trim()))

                //&& (!filter.IdTipoTramite.HasValue || e.IdTipoTramite == filter.IdTipoTramite)
                //&& (!filter.IdProcedimiento.HasValue || e.IdProcedimiento == filter.IdProcedimiento)


                );
            }
            query = query.OrderByDescending(e => e.Id);
            var response = await _paginator.Paginate(query, entity);
            return response;
        }


        public async Task<ResponsePagination<ProductoInformeBusqueda>> PaginatedSearhProducto(RequestPagination<ProductoInformeBusqueda> entity)
        {
            IList<ProductoInformeBusqueda> data = new List<ProductoInformeBusqueda>();
            string sqlQuery = "select * from  trd.producto_informe_select_paginate(@p_id_tipo_tramite ,@p_id_procedimiento ,@p_numero_expediente ,@p_solicitante,@p_creacion_desde , @p_creacion_hasta ,@p_estado  ,@p_page , @p_per_page )";
            var filter = entity?.Filter;
            int total = 0;

            using DbConnection dbConnection = _context.Database.GetDbConnection();

            using DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;

            //Parameters start
            var p_id_tipo_tramite = dbCommand.CreateParameter();
            p_id_tipo_tramite.ParameterName = "@p_id_tipo_tramite";
            p_id_tipo_tramite.Value = filter?.IdTipoTramite ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_id_tipo_tramite);

            var p_id_procedimiento = dbCommand.CreateParameter();
            p_id_procedimiento.ParameterName = "@p_id_procedimiento";
            p_id_procedimiento.Value = filter?.IdProcedimiento ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_id_procedimiento);

            var p_numero_expediente = dbCommand.CreateParameter();
            p_numero_expediente.ParameterName = "@p_numero_expediente";
            p_numero_expediente.Value = filter?.NumeroExpediente ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_numero_expediente);

            var p_solicitante = dbCommand.CreateParameter();
            p_solicitante.ParameterName = "@p_solicitante";
            p_solicitante.Value = filter?.Nombre ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_solicitante);

            var p_creacion_desde = dbCommand.CreateParameter();
            p_creacion_desde.ParameterName = "@p_creacion_desde";
            p_creacion_desde.Value = filter?.FechaRegistroDesde ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_creacion_desde);

            var p_creacion_hasta = dbCommand.CreateParameter();
            p_creacion_hasta.ParameterName = "@p_creacion_hasta";
            p_creacion_hasta.Value = filter?.FechaRegistroHasta ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_creacion_hasta);

            var p_estado = dbCommand.CreateParameter();
            p_estado.ParameterName = "@p_estado";
            p_estado.Value = filter?.Estado ?? (object)DBNull.Value;
            dbCommand.Parameters.Add(p_estado);

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
            using IDataReader reader = await dbCommand.ExecuteReaderAsync();

            //if (reader.Read())
            //    total =!reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0  ;

           
            
            while (reader.Read())
            {
                total = !reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0;

                var item = new ProductoInformeBusqueda()
                {


                    TipoTramite = !reader.IsDBNull(reader.GetOrdinal("tipo_tramite")) ? reader.GetString(reader.GetOrdinal("tipo_tramite")) : null,
                    AsuntoTramite = !reader.IsDBNull(reader.GetOrdinal("asunto_tramite")) ? reader.GetString(reader.GetOrdinal("asunto_tramite")) : null,


                    IdProducto = !reader.IsDBNull(reader.GetOrdinal("id_producto")) ? reader.GetInt32(reader.GetOrdinal("id_producto")) : 0,
                    IdInformeTecnico = !reader.IsDBNull(reader.GetOrdinal("id_informe_tecnico")) ? reader.GetInt32(reader.GetOrdinal("id_informe_tecnico")) : 0,

                    NumeroExpediente = !reader.IsDBNull(reader.GetOrdinal("numero_expediente")) ? reader.GetString(reader.GetOrdinal("numero_expediente")) : null,
                    Nombre = !reader.IsDBNull(reader.GetOrdinal("solicitante")) ? reader.GetString(reader.GetOrdinal("solicitante")) : null,
                    IdDocumento = !reader.IsDBNull(reader.GetOrdinal("id_documento")) ? reader.GetInt32(reader.GetOrdinal("id_documento")) : 0,
                    IdDocumentoInforme = !reader.IsDBNull(reader.GetOrdinal("id_documento_informe")) ? reader.GetInt32(reader.GetOrdinal("id_documento_informe")) : 0,              
                    FechaEmision = !reader.IsDBNull(reader.GetOrdinal("fecha_emision")) ? reader.GetDateTime(reader.GetOrdinal("fecha_emision")) : new DateTime?(),
                    Estado = !reader.IsDBNull(reader.GetOrdinal("estado")) ? reader.GetBoolean(reader.GetOrdinal("estado")) : null,

                };
                data.Add(item);
            }
            reader.Close();

            var pagination = new Pagination(total, entity.Page, entity.PerPage);
            var response = new ResponsePagination<ProductoInformeBusqueda>(pagination)
            {
                Data = data
            };
            return response;
        }



    }
}

