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
    public class FichaDocumentoRepository : IFichaDocumentoRepository
    {
        private readonly ApplicationDbContext _context;

        public FichaDocumentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FichaDocumento> Create(FichaDocumento entity)
        {
            _context.FichaDocumentos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<FichaDocumento?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FichaDocumento>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<FichaDocumento>> ListarPorIdFichaAsync(int idFicha)
        => await _context.FichaDocumentos.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.FichaDocumentos.FindAsync(id);

            if (model != null)
            {
                _context.FichaDocumentos.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
