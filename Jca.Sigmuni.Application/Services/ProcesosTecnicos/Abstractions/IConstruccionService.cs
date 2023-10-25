using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IConstruccionService
    {
        Task<Construccion> CrearAsync(ConstruccionDto peticion);
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
        Task<long> CalcularValorizacionAsync(Ficha fichaIndividual);
    }
}
