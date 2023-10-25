using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITipoTramiteService
    {
        Task<IList<TipoTramiteDto>> findAll();
    }
}
