using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IExoneracionTitularService
    {
        Task<ExoneracionTitularDto> CrearExoneracion(ExoneracionTitularDto entity, int idPersona);
    }
}
