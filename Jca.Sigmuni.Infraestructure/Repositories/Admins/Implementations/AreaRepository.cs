using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Area> _paginator;

        public AreaRepository(ApplicationDbContext context, IPaginator<Area> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Area> Create(Area entity)
        {
            _context.Areas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Area?> Edit(int id, Area entity)
        {
            var model = await _context.Areas.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;

                _context.Areas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Area?> Disable(int id)
        {
            var model = await _context.Areas.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Areas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Area?> Find(int id)
        => await _context.Areas.FindAsync(id);

        public async Task<IList<Area>> FindAll()
        => await _context.Areas
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Area>> PaginatedSearch(RequestPagination<Area> entity)
        {

            var filter = entity.Filter;
            var query = _context.Areas.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }

        public async Task<IList<Area>> SelectAll()
        {
            IList<Area> data = new List<Area>();

            string sqlQuery = "SELECT * from adm.area_select_all()";

            using DbConnection connection = _context.Database.GetDbConnection();

            using DbCommand command = connection.CreateCommand();

            command.CommandText = sqlQuery;

            await connection.OpenAsync();

            using IDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                var item = new Area()
                {
                    Id = !reader.IsDBNull(reader.GetOrdinal("id_area")) ? reader.GetInt32(reader.GetOrdinal("id_area")) : 0,
                    Descripcion = !reader.IsDBNull(reader.GetOrdinal("descripcion")) ? reader.GetString(reader.GetOrdinal("descripcion")) : null,
                    FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("fecha_registro")) ? reader.GetDateTime(reader.GetOrdinal("fecha_registro")) : DateTime.UtcNow,
                    Estado = !reader.IsDBNull(reader.GetOrdinal("estado")) ? reader.GetBoolean(reader.GetOrdinal("estado")) : false,
                };

                data.Add(item);
            }

            await connection.CloseAsync();
            return data;
        }

        public async Task<ResponsePagination<Area>> SelectPaginatedSearch(RequestPagination<Area> entity)
        {
            IList<Area> data = new List<Area>();

            string sqlQuery = "SELECT * from adm.area_select_paginate(@p_descripcion, @p_estado, @p_page, @p_per_page)";
            var filter = entity?.Filter;
            int total = 0;

            using DbConnection connection = _context.Database.GetDbConnection();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = sqlQuery;

            // Parameters start
            var p_descripcion = command.CreateParameter();
            p_descripcion.ParameterName = "@p_descripcion";
            p_descripcion.Value = filter?.Descripcion ?? (object)DBNull.Value;
            command.Parameters.Add(p_descripcion);

            var p_estado = command.CreateParameter();
            p_estado.ParameterName = "@p_estado";
            p_estado.Value = filter?.Estado ?? (object)DBNull.Value;
            command.Parameters.Add(p_estado);


            var p_page = command.CreateParameter();
            p_page.ParameterName = "@p_page";
            p_page.Value = entity.Page;
            command.Parameters.Add(p_page);

            var p_per_page = command.CreateParameter();
            p_per_page.ParameterName = "@p_per_page";
            p_per_page.Value = entity.PerPage;
            command.Parameters.Add(p_per_page);
            // Parameters end


            await connection.OpenAsync();

            using IDataReader reader = await command.ExecuteReaderAsync();

            if (reader.Read())
                total = !reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0;

            while (reader.Read())
            {
                var item = new Area()
                {
                    Id = !reader.IsDBNull(reader.GetOrdinal("id_area")) ? reader.GetInt32(reader.GetOrdinal("id_area")) : 0,
                    Descripcion = !reader.IsDBNull(reader.GetOrdinal("descripcion")) ? reader.GetString(reader.GetOrdinal("descripcion")) : null,
                    FechaRegistro = !reader.IsDBNull(reader.GetOrdinal("fecha_registro")) ? reader.GetDateTime(reader.GetOrdinal("fecha_registro")) : DateTime.UtcNow,
                    Estado = !reader.IsDBNull(reader.GetOrdinal("estado")) ? reader.GetBoolean(reader.GetOrdinal("estado")) : false,
                };

                data.Add(item);
            }

            var pagination = new Pagination(total, entity.Page, entity.PerPage);

            var response = new ResponsePagination<Area>(pagination)
            {
                Data = data
            };

            return response;
        }

    }
}
