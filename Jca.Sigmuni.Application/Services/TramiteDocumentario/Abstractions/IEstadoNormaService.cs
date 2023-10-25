using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.EstadoNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IEstadoNormaService
    {
        Task<IList<EstadoNormaDto>>findAll();
    }
}
