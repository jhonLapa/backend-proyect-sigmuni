using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IDeclaranteService
    {
        Task<Declarante?> GuardarDeclaranteAsync(DeclarantePersonaDto peticion);
        Task<bool> EliminarAsync(int id);
    }
}
