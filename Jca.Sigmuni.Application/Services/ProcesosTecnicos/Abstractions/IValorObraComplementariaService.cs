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
    public interface IValorObraComplementariaService
    {
        Task<ValorObraComplementariaDto> CrearOActualizarAsync(ValorObraComplementariaDto peticion);
        Task<ResponsePagination<ValorObraComplementariaDto>> PaginatedSearch(RequestPagination<ValorObraComplementariaDto> dto);
        Task<ValorObraComplementariaDto> ObtenerAsync(int idValorObraComplementariaDto);
        Task<List<ValorObraComplementariaDto>> CrearMasivoAsync(List<ValorObraComplementariaMasivoDto> lista);
        Task<ValorObraComplementariaDto?> Disable(int id);
    }
}
