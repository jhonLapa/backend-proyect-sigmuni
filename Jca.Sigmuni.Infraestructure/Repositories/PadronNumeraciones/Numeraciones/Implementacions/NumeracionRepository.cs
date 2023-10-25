using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.PadronNumeraciones.Numeraciones.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.PadronNumeraciones.Numeraciones.Implementacions
{
    public class NumeracionRepository : INumeracionRepository
    {
        private readonly ApplicationDbContext _context;

        public NumeracionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Numeracion?> ObtenerPorIdTblCodigoYTipoPuerta(int id, int idTipoPuerta)
        => await _context.Numeraciones.Include(e => e.Certificado).Where(e => e.IdTblCodigo == id && e.IdTipoPuerta == idTipoPuerta).FirstOrDefaultAsync();
    }
}
