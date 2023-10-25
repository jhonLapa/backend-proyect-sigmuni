using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IValorUnitarioService
    {
        Task<ValorUnitarioDto> CrearOActualizarAsync(ValorUnitarioDto peticion);
        Task<ResponsePagination<ValorUnitarioDto>> SelectPaginatedSearch(RequestPagination<ValorUnitarioDto> dto);
        Task<ValorUnitarioDto> ObtenerAsync(int idValUnitario);
        Task<ValorUnitarioDto?> Disable(int id);
    }
}
