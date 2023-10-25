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
    public interface IUsuarioRepository : IRepositoryCrud<Usuario, int>, IRepositoryPaginated<Usuario>
    {
        Task<Usuario?> LoginAsync(string nombreUsuario, string clave);
    }
}
