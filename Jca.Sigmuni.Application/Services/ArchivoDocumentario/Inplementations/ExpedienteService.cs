using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeDocumentos;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly IMapper _mapper;
        private readonly IExpedienteRepository _expedienteRepository;

        public ExpedienteService(IMapper mapper, IExpedienteRepository expedienteRepository)
        {
            _mapper = mapper;
            _expedienteRepository = expedienteRepository;
        }
        public async Task<ExpedienteDto> Create(ExpedienteFormDto dto)
        {
            var entity = _mapper.Map<Expediente>(dto);
            var response = await _expedienteRepository.Create(entity);

            return _mapper.Map<ExpedienteDto>(response);
        }

        public async Task<ExpedienteDto?> Disable(int id)
        {
            var response = await _expedienteRepository.Disable(id);
            return _mapper.Map<ExpedienteDto>(response);
        }

        public async Task<ExpedienteDto?> Edit(int id, ExpedienteFormDto dto)
        {
            var entity = _mapper.Map<Expediente>(dto);
            var response = await _expedienteRepository.Edit(id, entity);

            return _mapper.Map<ExpedienteDto>(response);
        }

        public async Task<ExpedienteDto?> Find(int id)
        {
            var response = await _expedienteRepository.Find(id);

            return _mapper.Map<ExpedienteDto>(response);
        }

        public async Task<IList<ExpedienteDto>> FindAll()
        {
            var response = await _expedienteRepository.FindAll();
            return _mapper.Map<IList<ExpedienteDto>>(response);
        }

        public async Task<ResponsePagination<ExpedienteDto>> PaginatedSearch(RequestPagination<ExpedienteDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Expediente>>(dto);
            var response = await _expedienteRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<ExpedienteDto>>(response);
        }
        public async Task<ExpedienteDto> FindxInfo(int id)
        {
            var response = await _expedienteRepository.FindxInforme(id);


            if (response == null)
            {
                throw new Exception(" no está registrado.");
                return _mapper.Map<ExpedienteDto>(response);

            }

            var temporal = 0;

            return _mapper.Map<ExpedienteDto>(response);
        }
    }
}
