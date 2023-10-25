using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaDocumentos;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IFichaDocumentoService
    {
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
        Task<FichaDocumento> CrearAsync(FichaDocumentoDto peticion);
    }
}
