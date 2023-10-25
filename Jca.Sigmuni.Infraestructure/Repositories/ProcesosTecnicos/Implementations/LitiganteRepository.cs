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
    public class LitiganteRepository : ILitiganteRepository
    {
        private readonly ApplicationDbContext _context;

        public LitiganteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Litigante> Create(Litigante entity)
        {
            _context.Litigantes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Litigante?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Litigante>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Litigante>> ListarPorIdFichaAsync(int idFicha)
        => await _context.Litigantes.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Litigantes.FindAsync(id);

            if (model != null)
            {
                _context.Litigantes.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
