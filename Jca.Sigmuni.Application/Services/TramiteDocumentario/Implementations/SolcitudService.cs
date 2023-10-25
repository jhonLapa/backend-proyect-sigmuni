using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario.Enums;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class SolcitudService : ISolicitudService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISolicitudRepository _solicitudRepository;
        private readonly IPersonaRepository _personaReposotory;
        private readonly IActividadService _actividadService;
        private readonly IMedioRegistroRepository _medioRegistroRepository;

        public SolcitudService(ApplicationDbContext context, IMapper mapper, ISolicitudRepository solicitudRepository, IPersonaRepository personaReposotory, IActividadService actividadService, IMedioRegistroRepository medioRegistroRepository)
        {
            _context = context;
            _mapper = mapper;
            _solicitudRepository = solicitudRepository;
            _personaReposotory = personaReposotory;
            _actividadService = actividadService;
            _medioRegistroRepository = medioRegistroRepository;
        }

        public async Task<SolicitudDto> CrearSolicitudPresencialAsunc(SolicitudFormDto dto)
        {

            var solicitudNew = new Solicitud();

            if (dto.Procedimiento != null)
            {
                solicitudNew.IdProcedimiento = dto.Procedimiento.Id;
            }
            else
            {
                solicitudNew.IdProcedimiento = null;
            }

            //var existeNumeroSolicitud = await _solicitudRepository.BuscarPorNumeroSolicitudAsync(dto.NumeroSolicitud, DateTime.Now.Year);
            //valizadcion  existeNumeroSolicitud
            if (dto.Id == 0) {
                solicitudNew.Id = dto.Id;
            }
            solicitudNew.NumeroSolicitud = dto.NumeroSolicitud;
            if (dto.NumeroExpediente == "")
            {
                solicitudNew.NumeroExpediente = dto.NumeroSolicitud;
            }
            else
            {

                solicitudNew.NumeroExpediente = dto.NumeroExpediente;
            }
            
            solicitudNew.Inspeccion = 1;

            var MedioReg = await _medioRegistroRepository.FindByDescripcion("Externo");

                solicitudNew.IdMedioRegistro = MedioReg.Id;

            if (dto.Procedimiento != null)
            {
                solicitudNew.IdTipoTramite = dto.Procedimiento.TipoTramite.IdTipoTramite;
            }
            
            solicitudNew.IdArea = dto.IdArea;
            solicitudNew.IdTipoDocumentoSimple = dto.IdTipoDocumentoSimple;
            solicitudNew.NombreDocumento = !string.IsNullOrEmpty(dto.NombreDocumento) ? dto.NombreDocumento : null;
            solicitudNew.IdUsuarioAccion = dto.IdUsuarioAccion;
            //solicitudNew.Ip = dto.Ip;
            solicitudNew.AnioSolicitud = dto.AnioSolicitud;
            solicitudNew.AsuntoDocSimple = dto.AsuntoDocSimple;

            solicitudNew.IdSolicitante = dto.IdSolicitante; ;
            solicitudNew.IdRepresentanteLegal = dto.IdRepresentanteLegal;

            if (dto.Id == 0)
            {
                _context.Solicitudes.Add(solicitudNew);
                
            }
            else
            {
                solicitudNew.Id = dto.Id;
                _context.Solicitudes.Update(solicitudNew);
               
            }
            await _context.SaveChangesAsync();


            if (!string.IsNullOrWhiteSpace(dto.CartaPoderRepresentate))
            {
                var representate = await _personaReposotory.Find(solicitudNew.IdRepresentanteLegal ?? 0);
                if (representate != null)
                {
                    representate.CartaPoder = dto.CartaPoderRepresentate;
                    _personaReposotory.Edit(representate.Id, representate);
                    await _context.SaveChangesAsync();
                }
            }

            if (dto.SolicitudRequisito != null)
            {
                byte[] archivo = null;
                var base64 = "";
                int idDoc = 0;

                for (var i = 0; i < dto.SolicitudRequisito.Count(); i++)
                {
                    var doc = new Documento();
                    var solReq = new SolicitudRequisito();
                    if (dto.SolicitudRequisito[i].DocumentoB64!=null)
                    {
                        doc.Nombre = dto.SolicitudRequisito[i].DocumentoB64.Nombre;
                        doc.Descripcion = dto.SolicitudRequisito[i].DocumentoB64.Descripcion;
                        doc.MineType = dto.SolicitudRequisito[i].DocumentoB64.MineType;
                        doc.NombreOriginal = dto.SolicitudRequisito[i].DocumentoB64.NombreOriginal;
                        if (dto.SolicitudRequisito[i].DocumentoB64.Contenido != "")
                        {
                            base64 = (dto.SolicitudRequisito[i].DocumentoB64).Contenido.Replace("data:application/pdf;base64,", "");
                            archivo = Convert.FromBase64String(base64);
                        }
                        doc.Contenido = archivo;
                        _context.Documentos.Add(doc);
                        await _context.SaveChangesAsync();
                    }


                    idDoc = doc.IdDocumento;
                    if (idDoc > 0)
                    {
                        solReq.IdDocumento = idDoc;
                    }
                    
                    solReq.IdSolicitud = solicitudNew.Id;
                    if (dto.SolicitudRequisito[i].IdProcedimientoRequisito != null)
                    {
                        var idProcedimientoReq = dto.SolicitudRequisito[i].IdProcedimientoRequisito;
                        solReq.IdProcedimientoRequisito = idProcedimientoReq;
                    }
                    solReq.Folios = dto.SolicitudRequisito[i].Folios;
                    solReq.Flag = "1";
                    solReq.IdUsuario = dto.IdUsuarioAccion;
                    _context.SolicitudRequisitos.Add(solReq);
                    await _context.SaveChangesAsync();
                }

            }


            if (dto.SolicitudCuc != null)
            {
                foreach (var item in dto.SolicitudCuc)
                {
                    var solicitudCuc = new SolicitudCuc();
                    {
                        solicitudCuc.IdSolicitud = solicitudNew.Id;
                        solicitudCuc.IdUnidadCatastral = item.IdUnidadCatastral;
                        solicitudCuc.DireccionReferencial = item.DireccionReferencial;
                        solicitudCuc.Estado = true;
                        solicitudCuc.FechaRegistro = DateTime.UtcNow;
                        solicitudCuc.Numero = item.Numero;
                        solicitudCuc.Fojas = item.Fojas;
                        solicitudCuc.Asiento = item.Asiento;
                        solicitudCuc.CodigoDistrito = item.CodigoDistrito;
                        solicitudCuc.NombreHu = item.NombreHu;
                        solicitudCuc.AreaTerreno= item.AreaTerreno;
                        solicitudCuc.Mz = item.Mz;
                        solicitudCuc.LoteDireccion = item.LoteDireccion;
                        solicitudCuc.NombreVia = item.NombreVia;
                        solicitudCuc.Nro = item.Nro;
                        solicitudCuc.Estado = true;
                        solicitudCuc.Interior = item.Interior;
                        solicitudCuc.AnioUnidadCatastral = item.AnioUnidadCatastral;
                    };
                    if (item.TipoPartidaRegistral != null)
                    {
                        solicitudCuc.IdTipoPartidaRegistral = item.TipoPartidaRegistral.IdTipoPartidaRegistral;

                    };
                    _context.SolicitudCucs.Add(solicitudCuc);
                    await _context.SaveChangesAsync();

                }
            }

            //var operacionTieneInspeccion = await _actividadService.VerificarSiRequiereInspeccionSolicitudAsync(solicitudNew.IdProcedimiento ?? 0);
            //if (operacionTieneInspeccion == true)
            //{
            //    if (dto.Inspeccion != null)
            //    {
            //        dto.Inspecciones.Solicitud = new SolicitudDto()
            //        {
            //            Id = solicitudNew.Inspeccion,
            //        };
            //    }
            //    dto.Inspecciones.TipoInspeccion = (int)TiposInspeccion.Inspeccion;
            //    //Servicio inspeccion a consulta
            //}

            if (dto.Pago != null)
            { 
                var pago = new Pago();
                pago.NumeroRecibo=dto.Pago.NumeroRecibo;
                pago.Fecha= dto.Pago.Fecha;
                pago.Importe= dto.Pago.Importe;
                if(dto.Pago.MedioPago!= null)
                {
                    pago.IdMedioPago = dto.Pago.MedioPago.Id;
                }
                if(dto.Pago.Moneda != null)
                {
                    pago.IdMoneda=dto.Pago.Moneda.Id;
                }
               
                pago.IdSolicitud = solicitudNew.Id;
                if (dto.Pago.Id == 0)
                {
                    _context.Pagos.Add(pago);
                }
                else
                {
                    _context.Pagos.Update(pago);
                }
                
                await _context.SaveChangesAsync();
            }
            var response = _mapper.Map<Solicitud>(solicitudNew);
            return _mapper.Map<SolicitudDto>(response);

        }

        public Task<SolicitudDto> Create(SolicitudFormDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudDto?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudDto?> Edit(int id, SolicitudFormDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<SolicitudDto?> Find(int id)
        {
            
            var response = await _context.Solicitudes.FindAsync(id);
            // var response = await _solicitudRepository.Find(id);
            await _context.Solicitudes.Entry(response).Reference(e => e.Procedimiento).Query()
                .Include(x=>x.Actividad).ThenInclude(x=>x.AccionGenerar)
                .Include(x => x.Actividad).ThenInclude(x => x.Area)
                .Include(x => x.Actividad).ThenInclude(x => x.TipoActividad)
                .Include(x => x.Actividad).ThenInclude(x => x.Resultado)
                .Include(x => x.Actividad).ThenInclude(x => x.ResultadoII)
                .LoadAsync();
            await _context.Solicitudes.Entry(response).Reference(e => e.Solicitante).Query()
                .Include(x=>x.InfoContacto)
                .Include(x => x.DocumentoIdentidad)
                .Include(x => x.TipoPersona)
                .Include(x => x.Domicilio).ThenInclude(y=>y.TipoVia)
                .Include(x => x.Domicilio).ThenInclude(y => y.Ubigeo)
                .Include(x => x.Domicilio).ThenInclude(y => y.Via)
                .Include(x => x.Domicilio).ThenInclude(y => y.Edificacion).ThenInclude(x=>x.TipoAgrupacion)
                .Include(x => x.Domicilio).ThenInclude(y => y.HabilitacionUrbana)
                .LoadAsync();
            await _context.Solicitudes.Entry(response).Reference(e => e.RepresentanteLegal).Query()
                .Include(x=>x.InfoContacto)
                .Include(x => x.DocumentoIdentidad)
                .Include(x => x.TipoPersona)
                .Include(x => x.Domicilio).ThenInclude(y => y.TipoVia)
                .Include(x => x.Domicilio).ThenInclude(y => y.Ubigeo)
                .Include(x => x.Domicilio).ThenInclude(y => y.Via)
                .Include(x => x.Domicilio).ThenInclude(y => y.Edificacion).ThenInclude(x=>x.TipoAgrupacion)
                .Include(x => x.Domicilio).ThenInclude(y => y.HabilitacionUrbana)
                .LoadAsync();
            await _context.Solicitudes.Entry(response).Collection(e => e.SolicitudRequisitos).Query()
                .Include(x=>x.Documento)
                .Include(x => x.ProcedimientoRequisito).ThenInclude(x=>x.Requisito)
                .LoadAsync();
            await _context.Solicitudes.Entry(response).Reference(e => e.Procedimiento).Query().Include(e => e.TipoTramite).LoadAsync();
            await _context.Solicitudes.Entry(response).Reference(e => e.TipoTramite).Query().LoadAsync();
            await _context.Solicitudes.Entry(response).Reference(e => e.TipoDocumentoSimple).Query().LoadAsync();
            await _context.Solicitudes.Entry(response).Collection(e => e.SolicitudCuc).Query()
                .Include(e => e.TipoPartidaRegistral)
                .Include(e => e.UnidadCatastral).ThenInclude(x=>x.TblCodigo)
                .LoadAsync();
            await _context.Solicitudes.Entry(response).Collection(e => e.Pagos).Query()
                .Include(x => x.Moneda)
                .Include(x => x.MedioPago)
                .LoadAsync();
            await _context.Solicitudes.Entry(response).Reference(e => e.Area).LoadAsync();
            return _mapper.Map<SolicitudDto>(response);
        }

        public async Task<IList<SolicitudDto>> FindAll()
        {
            var response = await _solicitudRepository.FindAll();
            return _mapper.Map<IList<SolicitudDto>>(response);
        }
        public async Task<IList<SolicitudDto>> FindAllInfoDocumento()
        {
            IList<Solicitud> response = new List<Solicitud>();

            var response2 = await _solicitudRepository.FindAll();
            for (int i = 0; i < response2.Count; i++)
            {
                if (response2[i].InfDocumento.Count != 0)
                {
                    response.Add(response2[i]);
                }
            }
            return _mapper.Map<IList<SolicitudDto>>(response);
        }

        public async Task<SolicitudDto> ObtenerPorNumeroSolicitud(string numeroSolicitud)
        {
            var entidad = await _solicitudRepository.ObtenerPorNumeroSolicitud(numeroSolicitud);
            return _mapper.Map<SolicitudDto>(entidad);
        }


        public async Task<List<SolicitudDto>> ObtenerPorAnioSolicitud(int anio)
        {
            var SolicitudRequisito = await _solicitudRepository.ObtenerPorAnioSolicitud(anio);
            var dto = _mapper.Map<List<SolicitudDto>>(SolicitudRequisito);
        


            //var respuesta = dto.(x => x.numero = coun++);

            return new List<SolicitudDto>(dto);
        }

        public async Task<SolicitudDto> ObtenerTramiteSolicitudPorIdAsyn(int idSolicitud)
        {
            var entidad =await _solicitudRepository.Find(idSolicitud);
            if (entidad == null)
            { 
                //validacion
            }

            await _context.Solicitudes.Entry(entidad).Reference(e=>e.Procedimiento).LoadAsync();
            await _context.Solicitudes.Entry(entidad).Reference(e => e.Solicitante).LoadAsync();
            await _context.Solicitudes.Entry(entidad).Reference(e => e.Procedimiento).Query().Include(e=>e.TipoTramite).LoadAsync();
            await _context.Solicitudes.Entry(entidad).Reference(e => e.TipoTramite).Query().LoadAsync();
            await _context.Solicitudes.Entry(entidad).Reference(e => e.TipoDocumentoSimple).Query().LoadAsync();
            await _context.Solicitudes.Entry(entidad).Collection(e => e.SolicitudCuc).Query().Include(e=>e.TipoPartidaRegistral).LoadAsync();
            await _context.Solicitudes.Entry(entidad).Reference(e => e.Area).LoadAsync();

            
            return _mapper.Map<SolicitudDto>(entidad);

        }

        public async  Task<SolicitudDto> ObtenerUltimoSolicitud()
        {
            var response = await _solicitudRepository.ObtenerUltimoSolicitud();
            return _mapper.Map<SolicitudDto>(response);
        }

        public async Task<ResponsePagination<SolicitudBusquedaDto>> PaginacionSolicitud(RequestPagination<SolicitudBusquedaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<SolicitudBusqueda>>(dto);
            var response = await _solicitudRepository.PaginatedSearhSolicitud(entity);
            return _mapper.Map<ResponsePagination<SolicitudBusquedaDto>>(response);
        }

        public async Task<ResponsePagination<SolicitudDto>> PaginatedSearch(RequestPagination<SolicitudDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Solicitud>>(dto);
            var response =await _solicitudRepository.PaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<SolicitudDto>>(response);
        }
    }

}
