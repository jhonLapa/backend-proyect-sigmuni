using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TIpoNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITipoNormaService
    {
        Task<IList<TipoNormaDto>> findAll();

    }
}
