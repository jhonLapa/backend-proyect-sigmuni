using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface IInfDocumentoSPService : IServiceCrud<InfDocumentoSPDto, InfDocumentoSPFormDto, int>, IServicePaginated<InfDocumentoSPDto>
    {
        Task<InfDocumentoSPDto?> ListarDetalleAsync(string numExpendiente, string anioExpediente);
    }
}
