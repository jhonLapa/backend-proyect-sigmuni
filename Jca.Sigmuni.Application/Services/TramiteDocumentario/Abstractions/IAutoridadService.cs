using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IAutoridadService
    {
        Task<IList<AutoridadDto>> findAll();
    }
}
