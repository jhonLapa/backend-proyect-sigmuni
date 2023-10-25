using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredioCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.VerificadorCatastrales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class VerificadorCatastralService : IVerificadorCatastralService
    {
        private readonly IMapper _mapper;
        private readonly IVerificadorCatastralRepository _verificadorCatastralRepository;

        public VerificadorCatastralService(IMapper mapper,
                                                IVerificadorCatastralRepository verificadorCatastralRepository)
        {
            _mapper = mapper;
            _verificadorCatastralRepository = verificadorCatastralRepository;
        }

        public async Task<VerificadorCatastral?> CrearOActualizarAsync(VerificadorCatastralDto peticion)
        {
            if (peticion.IdPersona == 0 || peticion.IdPersona == null) throw new Exception("Debe ingresar idPersona");

            var verificadorCatastral = await _verificadorCatastralRepository.Find(peticion.Id ?? 0);

            if (verificadorCatastral == null)
            {
                verificadorCatastral = new VerificadorCatastral();
            }

            verificadorCatastral.IdPersona = peticion.IdPersona;
            verificadorCatastral.IdCondicionPer = peticion.IdCondicionPer != 0 ? peticion.IdCondicionPer : null;
            verificadorCatastral.IdFicha = peticion.IdFicha;
            verificadorCatastral.NumeroRegistro = peticion.NumeroRegistro;
            verificadorCatastral.TieneFirma = peticion.TieneFirma;
            verificadorCatastral.Fecha = peticion.Fecha;

            if (verificadorCatastral.Id == 0)
            {
                return await _verificadorCatastralRepository.Create(verificadorCatastral);
            }
            else
            {
                return await _verificadorCatastralRepository.Edit(verificadorCatastral.Id, verificadorCatastral);
            }
        }
    }
}
