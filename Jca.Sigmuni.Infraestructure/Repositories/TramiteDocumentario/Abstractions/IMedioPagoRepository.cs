﻿using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IMedioPagoRepository
    {
        Task<IList<MedioPago>> FindAll();

    }
}
