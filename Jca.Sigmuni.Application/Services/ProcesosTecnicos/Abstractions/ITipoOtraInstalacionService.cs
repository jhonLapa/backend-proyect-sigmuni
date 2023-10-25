using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoOtraInstalacionService
    {
        Task<IList<TipoOtraInstalacionDto>> FindAll();
    }
}
