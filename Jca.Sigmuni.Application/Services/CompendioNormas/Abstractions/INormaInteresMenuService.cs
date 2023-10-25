using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.CompendioNormas.Abstractions
{
    public interface INormaInteresMenuService : IServiceCrud<NormaInteresMenuDto, NormaInteresMenuFormDto, int>, IServicePaginated<NormaInteresMenuDto>
    {
        Task<List<NormaInteresMenuDto>> BuscarPorIdNormaInteres(int idNormaInteresMenu);
    }
}
