using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IInformeTecnicoRepository : IRepositoryCrud<InformeTecnico, int>, IRepositoryPaginated<InformeTecnico>
    {
        Task<InformeTecnico> BuscarSolicitudRegistradaAsync(int idSolicitud, int idTipoInforme);
        Task<InformeTecnico> BuscarMaxNumeroCorrelativoAsyn();
        Task<InformeTecnico> BuscarPorNumeroCorrelativoAsync(string numCorrelativo, int idTipoInforme);
        Task<InformeTecnico> BuscarPorIdAsync(int id);
        Task<InformeTecnico> BuscarInformePorIdSolicitud(int idSolicitud);
        Task<InformeTecnico?> EstadoGeneradoInforme(int id);

    }
}
