using Jca.Sigmuni.Application.Dtos.CompendioNormas.ClasificacionNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IClasificacionNormaService
    {
        Task<IList<ClasificacionNormaDto>> findAll();
    }
}
