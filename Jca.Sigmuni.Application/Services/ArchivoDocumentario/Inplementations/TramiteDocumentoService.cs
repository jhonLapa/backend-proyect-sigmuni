using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class TramiteDocumentoService : ITramiteDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly ITramiteDocumentoRepository _tramiteDocumentoRepository;

        public TramiteDocumentoService(IMapper mapper, ITramiteDocumentoRepository tramiteDocumentoRepository)
        {
            _mapper = mapper;
            _tramiteDocumentoRepository = tramiteDocumentoRepository;
        }

        public async Task<TramiteDocumentoDto> CrearOActualizarActualizadoAsync(List<TramiteDocumentoPFormDto> peticion)
        {
            var id = 0;
            //var response = await _tramiteDocumentoRepository.Find(id);
            TramiteDocumento response = new TramiteDocumento();

            for (int i = 0; i < peticion.Count; i++) 
            {
                var find = await _tramiteDocumentoRepository.Find(peticion[i].Id);
                if (find != null)
                {
                    response = find;
                }
                else
                {
                    TramiteDocumento objeto = new TramiteDocumento();
                    objeto.Id = id;
                    objeto.Numero = peticion[i].Numero;
                    objeto.Anio = peticion[i].Anio;
                    objeto.FechaPrestamo = peticion[i].FechaPrestamo;
                    objeto.FechaDevolucion = peticion[i].FechaDevolucion;
                    objeto.IdInfDocumento = peticion[i].IdInfDocumento;
                    objeto.IdUsuario = peticion[i].IdUsuario;
                    objeto.IdSolicitante = peticion[i].IdSolicitante;
                    objeto.FlagDevuelto = peticion[i].FlagDevuelto;
                    objeto.FoliosPrestados = peticion[i].FoliosPrestados;
                    objeto.FoliosDevueltos = peticion[i].FoliosDevueltos;
                    objeto.DocumentoSolicita = peticion[i].DocumentoSolicita;
                    objeto.DocumentoRetorna = peticion[i].DocumentoRetorna;
                    objeto.IdTipoPrestamo = peticion[i].IdTipoPrestamo;
                    objeto.FlagPrestamo = peticion[i].FlagPrestamo;
                    objeto.FlagCopiaDigital = peticion[i].FlagCopiaDigital;
                    objeto.FlagConsulta = peticion[i].FlagConsulta;

                    response = await _tramiteDocumentoRepository.Create(objeto);
                }
            }

            return _mapper.Map<TramiteDocumentoDto>(response);

        }

        public async Task<TramiteDocumentoDto> Create(TramiteDocumentoFormDto dto)
        {
            var entity = _mapper.Map<TramiteDocumento>(dto);
            var response = await _tramiteDocumentoRepository.Create(entity);

            return _mapper.Map<TramiteDocumentoDto>(response);
        }

        public async Task<TramiteDocumentoDto?> Disable(int id)
        {
            var response = await _tramiteDocumentoRepository.Disable(id);
            return _mapper.Map<TramiteDocumentoDto>(response);
        }

        public async Task<TramiteDocumentoDto?> Edit(int id, TramiteDocumentoFormDto dto)
        {
            var entity = _mapper.Map<TramiteDocumento>(dto);
            var response = await _tramiteDocumentoRepository.Edit(id, entity);

            return _mapper.Map<TramiteDocumentoDto>(response);
        }

        public async Task<TramiteDocumentoDto?> Find(int id)
        {
            var response = await _tramiteDocumentoRepository.Find(id);

            return _mapper.Map<TramiteDocumentoDto>(response);
        }

        public async Task<IList<TramiteDocumentoDto>> FindAll()
        {
            var response = await _tramiteDocumentoRepository.FindAll();
            return _mapper.Map<IList<TramiteDocumentoDto>>(response);
        }

        public async Task<TramiteDocumentoObtenerDto> ObtenerPorIdAsync(int id)
        {
            TramiteDocumentoObtenerDto dtoEnvio = new TramiteDocumentoObtenerDto();
            var entidad = await _tramiteDocumentoRepository.Find(id);
            IList<TramiteDocumento> entidadCompleta = new List<TramiteDocumento>();
            if(entidad != null)
            {
                entidadCompleta = await _tramiteDocumentoRepository.FindXNumeroAnio(entidad.Numero, entidad.Anio);
            }
            var dto = _mapper.Map<TramiteDocumentoDto>(entidad);
            List<TramiteDocumentoDto> ListTramite = new List<TramiteDocumentoDto>();
            for (int i = 0; i < entidadCompleta.Count; i++)
            {
                TramiteDocumentoDto tramite = new TramiteDocumentoDto();

                tramite.Id = entidadCompleta[i].Id;
                tramite.Numero = entidadCompleta[i].Numero;
                tramite.Anio = entidadCompleta[i].Anio;
                tramite.FechaPrestamo = entidadCompleta[i].FechaPrestamo;
                tramite.FechaDevolucion = entidadCompleta[i].FechaDevolucion;
                tramite.IdInfDocumento = entidadCompleta[i].IdInfDocumento;
                tramite.IdUsuario = dto.IdUsuario;
                tramite.IdSolicitante = dto.IdSolicitante;
                tramite.FlagDevuelto = entidadCompleta[i].FlagDevuelto;
                tramite.FoliosPrestados = entidadCompleta[i].FoliosPrestados;
                tramite.FoliosDevueltos = entidadCompleta[i].FoliosDevueltos;
                tramite.DocumentoSolicita = entidadCompleta[i].DocumentoSolicita;
                tramite.DocumentoRetorna = entidadCompleta[i].DocumentoRetorna;
                tramite.IdTipoPrestamo = dto.IdTipoPrestamo;
                tramite.FechaRegistro = entidadCompleta[i].FechaRegistro;
                tramite.Estado = entidadCompleta[i].Estado;
                tramite.EstadoNombre = entidadCompleta[i].EstadoNombre;
                tramite.FlagPrestamo = dto.FlagPrestamo;
                tramite.FlagCopiaDigital = dto.FlagCopiaDigital;
                tramite.FlagConsulta = dto.FlagConsulta;
                tramite.InfDocumento = _mapper.Map<InfDocumentoDto>(entidadCompleta[i].InfDocumento);
                tramite.TipoPrestamo = dto.TipoPrestamo;
                tramite.persona = dto.persona;

                ListTramite.Add(tramite);

            }
            dtoEnvio.TramiteDocumentos = ListTramite;
            return _mapper.Map<TramiteDocumentoObtenerDto>(dtoEnvio);
        }

        public async Task<ResponsePagination<TramiteDocumentoDto>> PaginatedSearch(RequestPagination<TramiteDocumentoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<TramiteDocumento>>(dto);
            var response = await _tramiteDocumentoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<TramiteDocumentoDto>>(response);
        }

        public async Task<TramiteDocumentoDto> ObtenerUltimoNumeroTramiteDo()
        {
            var response = await _tramiteDocumentoRepository.ObtenerUltimoNumeroTramiteDo();
            return _mapper.Map<TramiteDocumentoDto>(response);
        }


    }
}
