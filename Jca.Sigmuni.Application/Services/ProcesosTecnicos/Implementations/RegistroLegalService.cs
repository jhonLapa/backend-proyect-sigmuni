using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
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
    public class RegistroLegalService : IRegistroLegalService
    {
        private readonly IMapper _mapper;
        private readonly IRegistroLegalRepository _registroLegalRepository;

        public RegistroLegalService(IMapper mapper,
                                    IRegistroLegalRepository registroLegalRepository)
        {
            _mapper = mapper;
            _registroLegalRepository = registroLegalRepository;
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _registroLegalRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _registroLegalRepository.EliminarAsync(item.IdRegistroLegal);
            }

            return response;
        }

        public async Task<RegistroLegal> CrearAsync(RegistroLegalDto peticion)
        {
            var idTipoDocNotarial = new int?();

            if (peticion.TipoDocNotarial != null)
            {
                idTipoDocNotarial = peticion.TipoDocNotarial.IdTipoDocNotarial != 0 ? peticion.TipoDocNotarial.IdTipoDocNotarial : new int?();
            }

            var registroLegal = new RegistroLegal
            {
                Notaria = peticion.Notaria,
                Kardex = peticion.Kardex,
                FechaEscritura = peticion.FechaEscritura,
                IdFicha = peticion.IdFicha,
                IdTipoDocNotarial = 1
            };

            return await _registroLegalRepository.Create(registroLegal);
        }
    }
}
