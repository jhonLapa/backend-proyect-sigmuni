using Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITipoExoneracionService
    {
        Task<IList<TipoExoneracionDto>> findAll();
    }
}
