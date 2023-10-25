using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoActividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITipoActividadService
    {
        Task<IList<TipoActividadDto>> findAll();
    }
}
