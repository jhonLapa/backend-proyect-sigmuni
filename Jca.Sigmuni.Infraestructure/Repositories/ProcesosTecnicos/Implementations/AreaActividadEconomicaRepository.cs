using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class AreaActividadEconomicaRepository: IAreaActividadEconomicaRepository
    {
        private readonly ApplicationDbContext _context;

        public AreaActividadEconomicaRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<AreaActividadEconomica> Create(AreaActividadEconomica entity)
        {
            _context.AreaActividadEconomicas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AreaActividadEconomica?> Disable(int id)
        {
            var model = await _context.AreaActividadEconomicas.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.AreaActividadEconomicas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AreaActividadEconomica?> Edit(int id, AreaActividadEconomica entity)
        {
            var model = await _context.AreaActividadEconomicas.FindAsync(id);

            if (model != null)
            {
                model.PredioCatAutorizada = entity.PredioCatAutorizada;
                model.ViaPubAutorizada = entity.ViaPubAutorizada;
                model.BienComunAutorizada = entity.BienComunAutorizada;
                model.TotalAutorizada = entity.TotalAutorizada;
                model.PredioCatVerificada = entity.PredioCatVerificada;
                model.ViaPubVerificada = entity.ViaPubVerificada;
                model.BienComunVerificada = entity.BienComunVerificada;
                model.TotalVerificada = entity.TotalVerificada;
                model.NumExpediente = entity.NumExpediente;
                model.IdFicha = entity.IdFicha;
                model.AnioAutorizacion = entity.AnioAutorizacion;
                model.NumLicencia = entity.NumLicencia;
                model.FechaExpedicion = entity.FechaExpedicion;
                model.FechaVencimiento = entity.FechaVencimiento;
                model.InicioActividad = entity.InicioActividad;
                model.NumResolucion = entity.NumResolucion;
                model.CodCatAsigCorrect = entity.CodCatAsigCorrect;
                

                model.AnioAutorizacion = entity.AnioAutorizacion;


                _context.AreaActividadEconomicas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AreaActividadEconomica> BuscarPorIdAsync(int id)
        => await _context.AreaActividadEconomicas.Where(e => e.IdAreaActividadEconomica == id).FirstOrDefaultAsync();

        public Task<AreaActividadEconomica?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AreaActividadEconomica>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
