using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IActividadRepository : IRepositoryCrud<Actividad,int>,IRepositoryPaginated<Actividad>
    {
        Task<Actividad> BuscarActividadPorIdProcedimientoAsync(int idProcedimiento, int idActividad);
        Task<List<Actividad>> BuscarPorIdAccionGenerarAsync(int idAccionGenerar);
        Task<List<Actividad>> BuscarPorIdTipoActividadAsync(int idTipoActividad);
        Task<List<Actividad>> CrearActualizarActividadesMultipleAsync(List<Actividad> actividads,int idProcedimiento);
        Task<List<Actividad>> ListarPorIdYCodigoTipoActividadAsync(int idProcedimiento,string codigo);

    }
}
