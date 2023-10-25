using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.PadronNumeraciones.Numeraciones.Abstractions
{
    public interface INumeracionRepository
    {
        Task<Numeracion?> ObtenerPorIdTblCodigoYTipoPuerta(int id, int idTipoPuerta);
    }
}
