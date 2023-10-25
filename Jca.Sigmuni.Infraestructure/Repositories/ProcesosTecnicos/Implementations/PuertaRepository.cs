using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class PuertaRepository : IPuertaRepository
    {
        private readonly ApplicationDbContext _context;

        public PuertaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Puerta>> ListarPorUbicacionPredioAsync(int idUbicacionPredio)
        => await _context.ViaPuertas.Where(e => e.IdUbicacionPredio == idUbicacionPredio).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.ViaPuertas.FindAsync(id);

            if (model != null)
            {
                _context.ViaPuertas.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<Puerta> Create(Puerta entity)
        {
            _context.ViaPuertas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Puerta?> Find(int id)
        => await _context.ViaPuertas.DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.IdPuerta.Equals(id));

        public async Task<IList<Puerta>> FindAll()
       => await _context.ViaPuertas

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<Puerta?> Edit(int id, Puerta entity)
        {
            var model = await _context.ViaPuertas.FindAsync(id);

            if (model != null)
            {
                model.CodigoPuerta = entity.CodigoPuerta;
                model.NumeracionMunicipal = entity.NumeracionMunicipal;
                model.IdTipoPuerta = entity.IdTipoPuerta;
                //model.IdVia = entity.IdVia;
                model.IdLoteCartografia = entity.IdLoteCartografia;
                model.IdUbicacionPredio = entity.IdUbicacionPredio;
                model.IdCondNumPrincipal = entity.IdCondNumPrincipal;
                model.IdCondNumSecundario = entity.IdCondNumSecundario;
                model.IdTipoNumPrincipal = entity.IdTipoNumPrincipal;
                model.IdTipoNumSecundario = entity.IdTipoNumSecundario;
                model.LtPrincipal = entity.LtPrincipal;
                model.LtScundario = entity.LtScundario;
                model.IdUbicacionNumeracion = entity.IdUbicacionNumeracion;
                model.NumCertifPrincipal = entity.NumCertifPrincipal;
                model.NumCertifSecundario = entity.NumCertifSecundario;
                //model.AnioPrincipal = entity.AnioPrincipal;
                model.AnioSecundario = entity.AnioSecundario;
                model.NumeroInterior = entity.NumeroInterior;
                model.IdTipoInterior = entity.IdTipoInterior;

                _context.ViaPuertas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<Puerta?> Disable(int id)
        {
            throw new NotImplementedException();
        }
    }
}
