using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ISolicitudRequisitoRepository:IRepositoryCrud<SolicitudRequisito,int>,IRepositoryPaginated<SolicitudRequisito>
    {
        Task<SolicitudRequisito?> EliminarDocumentoSolicitudRequisito(int idSolicitudRequisito);
    }
}
