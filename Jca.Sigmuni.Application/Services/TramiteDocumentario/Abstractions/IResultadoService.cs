using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IResultadoService
    {
        Task<IList<ResultadoDto>> FindAll();

    }
}
