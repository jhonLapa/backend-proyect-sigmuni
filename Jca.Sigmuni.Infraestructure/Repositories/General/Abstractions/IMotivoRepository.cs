using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IMotivoRepository
    {
        Task<IList<Motivo>> FindAll();

    }
}
