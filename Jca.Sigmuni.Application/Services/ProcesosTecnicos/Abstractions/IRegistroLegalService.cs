using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IRegistroLegalService
    {
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
        Task<RegistroLegal> CrearAsync(RegistroLegalDto peticion);
    }
}
