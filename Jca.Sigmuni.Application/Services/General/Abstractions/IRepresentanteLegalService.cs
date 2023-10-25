using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.Perfiles;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IRepresentanteLegalService : IServiceCrud<RepresentanteLegalDto, RepresentanteLegalFormDto, int>, IServicePaginated<RepresentanteLegalDto>
    {
    }
}
