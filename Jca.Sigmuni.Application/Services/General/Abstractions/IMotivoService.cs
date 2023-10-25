using Jca.Sigmuni.Application.Dtos.General.Motivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IMotivoService
    {
        Task<IList<MotivoDto>> FindAll();

    }
}
