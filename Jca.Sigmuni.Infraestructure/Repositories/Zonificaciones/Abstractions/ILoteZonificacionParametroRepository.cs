using Jca.Sigmuni.Domain.Zonificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions
{
    public interface ILoteZonificacionParametroRepository
    {

        Task<LoteZonificacionParametro?> BuscarClaseYATNPorIdCartograficoLoteAsync(string idCartograficoLote);
        Task<LoteZonificacionParametro> BuscarPorIdLoteCartografiaAsync(string IdLoteCartografia);

 

    }
}
