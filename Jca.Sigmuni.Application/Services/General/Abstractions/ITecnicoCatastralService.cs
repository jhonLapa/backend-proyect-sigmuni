using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITecnicoCatastralService
    {
        Task<TecnicoCatastral?> GuardarPersonaTecnicoCatastralAsync(TecnicoCatastralPersonaDto peticion);
        Task<bool> EliminarAsync(int id);
    }
}
