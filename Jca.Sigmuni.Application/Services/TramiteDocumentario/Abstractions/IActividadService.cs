using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IActividadService :IServiceCrud<ActividadDto,ActividadFormDto,int>,IServicePaginated<ActividadDto>
    {
        Task<List<ActividadDto>> Createmultiple(List<ActividadDto> dto, int idProcedimiento);
        Task<bool> VerificarSiRequiereInspeccionSolicitudAsync(int IdProcedimiento);
    }
}
