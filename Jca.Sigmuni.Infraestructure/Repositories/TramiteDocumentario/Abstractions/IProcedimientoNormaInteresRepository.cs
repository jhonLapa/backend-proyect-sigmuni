using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IProcedimientoNormaInteresRepository :IRepositoryCrud<ProcedimientoNormaInteres,int>,IRepositoryPaginated<ProcedimientoNormaInteres>
    {
        Task<ProcedimientoNormaInteres> BuscarProcedimientoNormaInterePorIdAsync(int idProcedimiento,int norma);
    }
}
