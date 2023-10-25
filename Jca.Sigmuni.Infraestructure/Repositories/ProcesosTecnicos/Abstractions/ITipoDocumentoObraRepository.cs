﻿using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoDocumentoObraRepository
    {
        Task<IList<TipoDocumentoObra>> FindAll();
    }
}
