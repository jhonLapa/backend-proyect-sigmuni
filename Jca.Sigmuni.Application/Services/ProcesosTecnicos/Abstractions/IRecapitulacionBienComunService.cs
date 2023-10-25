using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionBienComunes;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IRecapitulacionBienComunService
    {
        Task<RecapitulacionBienComun> CrearAsync(RecapitulacionBienComunDto peticion);
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
    }
}
