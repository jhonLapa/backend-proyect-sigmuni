using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class LitiganteService : ILitiganteService
    {
        private readonly IMapper _mapper;
        private readonly ILitiganteRepository _litiganteRepository;
        private readonly IDependienteRepository _dependienteRepository;

        public LitiganteService(IMapper mapper,
                                ILitiganteRepository litiganteRepository,
                                IDependienteRepository dependienteRepository)
        {
            _mapper = mapper;
            _litiganteRepository = litiganteRepository;
            _dependienteRepository = dependienteRepository;
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _litiganteRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                var conyugeLitigante = await _dependienteRepository.ListarPorIdLitiganteAsync(item.IdLitigante);
                foreach (var item1 in conyugeLitigante)
                {
                    await _dependienteRepository.EliminarAsync(item1.Id);
                }
                response = await _litiganteRepository.EliminarAsync(item.IdLitigante);
            }

            return response;
        }

        public async Task<Litigante> GuardarPersonaLitiganteAsync(PersonaLitiganteDto peticion)
        {
            var litigante = new Litigante
            {
                CodigoContribuyente = peticion.CodigoContribuyenteSat,
                IdFicha = peticion.IdFicha,
                IdPersona = peticion.IdPersona
            };

            return await GuardarLitiganteAsync(litigante);
        }

        public async Task<Litigante> GuardarJuridicoaLitiganteAsync(PersonaLitiganteJuridicoDto peticion)
        {
            var litigante = new Litigante
            {
                CodigoContribuyente = peticion.CodigoContribuyenteSat,
                IdFicha = peticion.IdFicha,
                IdPersona = peticion.IdPersona
            };

            return await GuardarLitiganteAsync(litigante);
        }

        private async Task<Litigante> GuardarLitiganteAsync(Litigante litigante)
        {
            return await _litiganteRepository.Create(litigante);
        }
    }
}
