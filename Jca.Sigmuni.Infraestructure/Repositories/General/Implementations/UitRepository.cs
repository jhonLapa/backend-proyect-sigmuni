using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class UitRepository : IUitRepository
    {
        private readonly ApplicationDbContext _context;

        public UitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Uit> BuscarPorAnioTupaAsunc(int anio)
        => await _context.Uits
            .Where(x => x.AnioUit == anio).FirstOrDefaultAsync();

    }
}
