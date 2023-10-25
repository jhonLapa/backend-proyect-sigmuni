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
    public class OtraInstalacionRepository : IOtraInstalacionRepository
    {
        private readonly ApplicationDbContext _context;

        public OtraInstalacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OtraInstalacion> Create(OtraInstalacion entity)
        {
            _context.OtraInstalaciones.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<OtraInstalacion?> Find(int id)
        => await _context.OtraInstalaciones.DefaultIfEmpty()
                                           .FirstOrDefaultAsync(i => i.IdOtraInstalacion.Equals(id));

        public Task<IList<OtraInstalacion>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<OtraInstalacion>> ListarPorIdFichaAsync(int idFicha)
        => await _context.OtraInstalaciones.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.OtraInstalaciones.FindAsync(id);

            if (model != null)
            {
                _context.OtraInstalaciones.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
