using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IConstruccionRepository : IRepositoryCrud<Construccion, int>
    {
        Task<bool> EliminarAsync(int id);
        Task<List<Construccion>> ListarPorIdFichaAsync(int idFicha);
        Task<List<Construccion>> BuscarPorIdLoteCartografiaAsync(string idLoteCarto);
    }
}
