using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionBienComunes;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class RecapitulacionBienComunService : IRecapitulacionBienComunService
    {
        private readonly IMapper _mapper;
        private readonly IRecapitulacionBienComunRepository _recapitulacionBienComunRepository;

        public RecapitulacionBienComunService(IMapper mapper,
                                              IRecapitulacionBienComunRepository recapitulacionBienComunRepository)
        {
            _mapper = mapper;
            _recapitulacionBienComunRepository = recapitulacionBienComunRepository;
        }

        public async Task<RecapitulacionBienComun> CrearAsync(RecapitulacionBienComunDto peticion)
        {
            var recapitulacionBienComun = new RecapitulacionBienComun
            {
                Numero = peticion.Numero,
                Edificacion = peticion.Edificacion,
                Entrada = peticion.Entrada,
                Piso = peticion.Piso,
                Unidad = peticion.Unidad,
                Porcentaje = peticion.Porcentaje,
                Atc = peticion.Atc,
                Acc = peticion.Acc,
                Aoic = peticion.Aoic,
                IdFicha = peticion.IdFicha,
                LegalConstruccion = peticion.LegalConstruccion,
                FisicoTerreno = peticion.FisicoTerreno,
                LegalTerreno = peticion.LegalTerreno
            };

            return await _recapitulacionBienComunRepository.Create(recapitulacionBienComun);
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _recapitulacionBienComunRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _recapitulacionBienComunRepository.EliminarAsync(item.Id);
            }

            return response;
        }
    }
}
