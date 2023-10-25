using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class AutorizacionAnuncioRepository : IAutorizacionAnuncioRepository
    {
        private readonly ApplicationDbContext _context;

        public AutorizacionAnuncioRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<List<AutorizacionAnuncio>> BuscarPorIdTipoAnuncioAsync(int IdTipoAnuncio)
         => await _context.AutorizacionAnuncios.Where(x => x.IdTipoAnuncio == IdTipoAnuncio && x.Estado == true).ToListAsync();

        public async Task<AutorizacionAnuncio> Create(AutorizacionAnuncio entity)
        {
            _context.AutorizacionAnuncios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AutorizacionAnuncio?> Disable(int id)
        {
            var model = await _context.AutorizacionAnuncios.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.AutorizacionAnuncios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AutorizacionAnuncio?> Edit(int id, AutorizacionAnuncio entity)
        {
            var model = await _context.AutorizacionAnuncios.FindAsync(id);

            if (model != null)
            {
                model.IdTipoAnuncio = entity.IdTipoAnuncio;
                model.NumeLados = entity.NumeLados;
                model.AreaAutorizada = entity.AreaAutorizada;
                model.AreaVerificada = entity.AreaVerificada;
                model.NumeExpediente = entity.NumeExpediente;
                model.NumeLicencia = entity.NumeLicencia;
                model.FechaExpedicion = entity.FechaExpedicion;
                model.FechaVencimiento = entity.FechaVencimiento;
                model.IdCondicionAnuncio = entity.IdCondicionAnuncio;
                model.IdFicha = entity.IdFicha;
                model.AnioAutorizacion = entity.AnioAutorizacion;


                _context.AutorizacionAnuncios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<AutorizacionAnuncio?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AutorizacionAnuncio>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AutorizacionAnuncio>> ListarPorIdFichaAsync(int idFicha)
        => await _context.AutorizacionAnuncios.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.AutorizacionAnuncios.FindAsync(id);

            if (model != null)
            {
                _context.AutorizacionAnuncios.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
