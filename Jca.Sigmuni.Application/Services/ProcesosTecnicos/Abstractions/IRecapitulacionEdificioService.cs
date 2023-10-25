using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionEdificios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IRecapitulacionEdificioService
    {
        Task<RecapitulacionEdificio> CrearAsync(RecapitulacionEdificioDto peticion);
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
    }
}
