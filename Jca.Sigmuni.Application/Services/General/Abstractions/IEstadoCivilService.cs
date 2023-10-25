using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IEstadoCivilService : IServiceCrud<EstadoCivilDto, EstadoCivilFormDto, int>, IServicePaginated<EstadoCivilDto>
    {
    }
}
