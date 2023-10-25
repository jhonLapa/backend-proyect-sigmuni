using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IUbicacionPredioService
    {
        Task<UbicacionPredio?> CrearOActualizarAsync(UbicacionPredioDto peticion);
    }
}
