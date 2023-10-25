using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class InfoComplementarioService : IInfoComplementarioService
    {
        private readonly IMapper _mapper;
        private readonly IInfoComplementarioRepository _infoComplementarioRepository;

        public InfoComplementarioService(IMapper mapper, IInfoComplementarioRepository infoComplementarioRepository)
        {
            _mapper = mapper;
            _infoComplementarioRepository = infoComplementarioRepository;
        }

        public async Task<InfoComplementarioDto> Create(InfoComplementario dto)
        {

            var entity = _mapper.Map<InfoComplementario>(dto);
            var response = await _infoComplementarioRepository.Create(entity);

            return _mapper.Map<InfoComplementarioDto>(response);

        }


       

        public async Task<InfoComplementarioDto?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InfoComplementarioDto?> Edit(int id, InfoComplementario dto)
        {
            throw new NotImplementedException();
        }

        public async Task<InfoComplementarioDto?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<InfoComplementarioDto>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePagination<InfoComplementarioDto>> PaginatedSearch(RequestPagination<InfoComplementarioDto> dto)
        {
            throw new NotImplementedException();
        }

        public async Task<InfoComplementario?> CrearOActualizarAsync(InfoComplementarioDto peticion)
        {
            var id = peticion.IdInfoComplementario;

            var informacionComplementaria = await _infoComplementarioRepository.Find(id);

            if (informacionComplementaria == null)
            {
                informacionComplementaria = new InfoComplementario();
            }

            var idObservacion = new int?();
            var idTipoMantenimiento = new int?();
            var idEstadoLLenado = new int?();
            var idTipoInspeccion = new int?();
            var idMotivo = new int?();
            var idDocumentoPresentado = new int?();

            if (peticion.Observacion != null)
            {
                idObservacion = peticion.Observacion.IdObservacion != 0 ? peticion.Observacion.IdObservacion : new int?();
            }

            if (peticion.TipoMantenimiento != null)
            {
                idTipoMantenimiento = peticion.TipoMantenimiento.IdTipoMantenimiento != 0 ? peticion.TipoMantenimiento.IdTipoMantenimiento : new int?();
            }

            if (peticion.EstadoLLenado != null)
            {
                idEstadoLLenado = peticion.EstadoLLenado.IdEstadoLlenado != 0 ? peticion.EstadoLLenado.IdEstadoLlenado : new int?();
            }

            if (peticion.TipoInspeccion != null)
            {
                idTipoInspeccion = peticion.TipoInspeccion.IdTipoInspeccion != 0 ? peticion.TipoInspeccion.IdTipoInspeccion : new int?();
            }

            //if (peticion.Motivo != null)
            //{
            //    idMotivo = peticion.Motivo.Id ? peticion.Motivo.Id) : new int?();
            //}

            if (peticion.TipoDocPresentado != null)
            {
                idDocumentoPresentado = peticion.TipoDocPresentado.IdTipoDocumentoFicha != 0 ? peticion.TipoDocPresentado.IdTipoDocumentoFicha : new int?();
            }

            informacionComplementaria.NumHabitantes = peticion.NumHabitantes;
            informacionComplementaria.NumFamilias = peticion.NumFamilias;
            informacionComplementaria.IdObservacion = idObservacion;
            informacionComplementaria.Observaciones = peticion.Observaciones;
            //informacionComplementaria.ObservacionOtros = peticion.ObservacionOtros;
            informacionComplementaria.IdTipoMantenimiento = idTipoMantenimiento;
            informacionComplementaria.IdEstadoLlenado = idEstadoLLenado;
            informacionComplementaria.IdFicha = peticion.IdFicha;
            informacionComplementaria.NumComunicacion = peticion.NumComunicacion;
            informacionComplementaria.IdTipoInspeccion = idTipoInspeccion;
            informacionComplementaria.IdMotivo = idMotivo;
            informacionComplementaria.IdTipoDocumento = idDocumentoPresentado;

            if (informacionComplementaria.IdInfoComplementario == 0)
            {
                return await _infoComplementarioRepository.Create(informacionComplementaria);
            }
            else
            {
                return await _infoComplementarioRepository.Edit(informacionComplementaria.IdInfoComplementario, informacionComplementaria);
            }
        }
    }
}
