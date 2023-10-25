﻿using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TipoTramiteRepository : ITipoTramiteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoTramite> _paginator;

        public TipoTramiteRepository(ApplicationDbContext context, IPaginator<TipoTramite> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<TipoTramite>> FindAll()
        =>await _context.TipoTramites
            .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
