using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IControlFichaService
    {
        Task<List<ControlFichaDto>> ControlFichasPorIdFicha(int idFicha);
        Task<bool> GuardarControlFichaAsync(List<ControlFichaDto> controlesFichas, bool esDirivarCC = false);
        Task<ControlFichaDto> ObtenerPorIdAsync(int idControlFicha);
        Task<bool> FichaControlConfirmAsync(int idFicha);
        Task<List<ControlFichaDto>> ListadoPorIdFichaAsync(int idFicha);
        Task<List<ControlFichaDto>> ListadoPorIdUnidadCatastralAsync(int idUnidadCatastral);
        Task<bool> GuardarDerivarControlFichaAsync(int idFicha);
        Task<List<ControlFichaDto>> ListadoFichasAsociadasPorIdFichaAsync(int idFicha);
    }
}
