﻿using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions
{
    public interface IInfDocumentoRepository : IRepositoryCrud<InfDocumento, int>, IRepositoryPaginated<InfDocumento>
    {
        Task<InfDocumento> ObtenerUltimoNumeroInf();
        Task<InfDocumento?> BuscarXsolicitud(int id);
    }
}