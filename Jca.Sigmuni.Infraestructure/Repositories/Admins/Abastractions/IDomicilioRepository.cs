using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions
{
    public interface IDomicilioRepository : IRepositoryCrud<Domicilio, int>, IRepositoryPaginated<Domicilio>
    {
        Task<Domicilio?> BusquedaSimplePorIdPersonaAsync(int idPersona);
        Task<Domicilio> BuscarPorIdAsync(int id);
    }
}
