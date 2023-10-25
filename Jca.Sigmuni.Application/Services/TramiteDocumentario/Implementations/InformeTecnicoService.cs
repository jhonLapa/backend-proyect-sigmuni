using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;
using Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class InformeTecnicoService : IInformeTecnicoService
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudRepository _solicitudRepository;
        private readonly IInformeTecnicoRepository _informeTecnicoRepository;
        private readonly ApplicationDbContext _context;
        private readonly ILoteZonificacionParametroRepository _loteZonificacionParametroRepository;
        private readonly IDocumentoService _documentoService;
        private readonly IAdjuntoInformeRepository _adjuntoInformeRepository;

        public InformeTecnicoService(ApplicationDbContext context, IMapper mapper, 
            ISolicitudRepository solicitudRepository, IInformeTecnicoRepository informeTecnicoRepository,
            ILoteZonificacionParametroRepository loteZonificacionParametroRepository,
               IDocumentoService documentoService,
                  IAdjuntoInformeRepository adjuntoInformeRepository
            )
        {
            _context = context;
            _mapper = mapper;
            _solicitudRepository = solicitudRepository;
            _informeTecnicoRepository = informeTecnicoRepository;
            _loteZonificacionParametroRepository = loteZonificacionParametroRepository;
            _documentoService = documentoService;
            _adjuntoInformeRepository = adjuntoInformeRepository;

        }

        public async Task<InformeTecnicoRespuestaDto> CrearAsync(InformeTecnicoDto peticion)
        {




            //if (peticion.DocumentoImagenes != null)
            //{

         
            //var responseDocumento = await _documentoService.Create(peticion.DocumentoImagenes);
            // peticion.IdDocumento = responseDocumento.IdDocumento;



            //}

    

            var idTipoInforme = peticion.IdTipoInforme;
            var idSolicitud = peticion.IdSolicitud;
            var entidad = await _informeTecnicoRepository.BuscarSolicitudRegistradaAsync(idSolicitud, idTipoInforme);

        
            if (entidad == null)
            {
                entidad = new InformeTecnico();
            }

            var maxInforme = await _informeTecnicoRepository.BuscarMaxNumeroCorrelativoAsyn();
            var date = DateTime.UtcNow;

            var numCorrelativo = "";

            if (maxInforme != null)
            {
                if (!string.IsNullOrEmpty(maxInforme.NumCorrelativo) && maxInforme.FechaRegistro.Year == date.Year)
                {
                    numCorrelativo = (int.Parse(maxInforme.NumCorrelativo.Substring(0, 4)) + 1).ToString("D4");
                }
            }
            else
            {
                numCorrelativo = "0001";
            }


            // FLAG POR TIPO DE CERTIFICADO CATASTRAL
            //1 = Certificado de Parámetros Urbanísticos y Edificatorios
            //2 = Certificado de Zonificación y Vías
            //3 = Certificado de Jurisdicción
            //4 = Certificado de Nomenclatura
            //5 = Certificado de Numeración
            //6 = Asignacion de numeración
            //7 = Certificado de Antecedentes de Nomenclatura y Numeración
            //8 = Visación de planos para fines de rectificación de área y linderos
            //15 = Constancia de verificación catastral
            //16 = Consolidación de información por predio


            var idEspecialista = peticion.IdEspecialista;
         


            entidad.FechaInforme = DateTime.UtcNow;
            entidad.Flag = peticion.Flag;
            entidad.IdSolicitud = idSolicitud;
            entidad.IdEspecialista = idEspecialista;
            entidad.JsonDatosSolicitud = peticion.JsonDatosSolicitud;
            entidad.JsonNumeracion = peticion.JsonNumeracion;
            entidad.JsonZonificacion = peticion.JsonZonificacion;
            entidad.IdTipoInforme = idTipoInforme;



            if (entidad.Id == 0)
            {
                var validarCertificado = await _informeTecnicoRepository.BuscarPorNumeroCorrelativoAsync(entidad.NumCorrelativo, idTipoInforme);

                if (validarCertificado != null)
                {
                    //return new OperacionDto<InformeTecnicoRespuestaDto>(CodigosOperacionDto.Invalido, "El Número de informe ya existe");

                    throw new Exception("El Número de informe ya existe");

                    return _mapper.Map<InformeTecnicoRespuestaDto>(validarCertificado);

                }
                else
                {
                    entidad.NumCorrelativo = numCorrelativo + '-' + date.Year.ToString();
                    //_context.InformeTecnicos.Add(entidad);
                    await _informeTecnicoRepository.Create(entidad);
                }
            }
            else
            {
                //_context.InformeTecnicos.Update(entidad);
                //await _context.SaveChangesAsync();
                await _informeTecnicoRepository.Edit(entidad.Id, entidad);

            
            }

           

            //if (peticion.DocumentoImagenes != null)
            //{

            //    var entidads = await _adjuntoInformeRepository.BuscarInformeDocumento(entidad.Id, 1);


            //    if (entidads == null)
            //    {
            //        entidads = new AdjuntoInforme();
            //    }

            //    //flag tipo_documento
            //    //1 = dentro_informe
            //    //2 = fuera_informe


            //    entidads.IdDocumento = peticion.IdDocumento;
            //    entidads.IdInformeTecnico = entidad.Id;
            //    entidads.Flag = 1;

            //    if (entidads.Id == 0)
            //    {
            //        await _adjuntoInformeRepository.Create(entidads);
            //    }
            //    else
            //    {
            //        await _adjuntoInformeRepository.Edit(entidads.Id, entidads);
            //    }


            //}


            var idCertificadoRegistrado = entidad.Id;
            var data = await _informeTecnicoRepository.BuscarPorIdAsync(idCertificadoRegistrado);

            //var dto = _mapper.Map<InformeTecnicoRespuestaDto>(data);
            //return new OperacionDto<InformeTecnicoRespuestaDto>(dto);
            return _mapper.Map<InformeTecnicoRespuestaDto>(data);

        }
        public async Task<InformeTecnicoDto> ObtenerinformeId(int idInforme)
        {
            var entidad = await _informeTecnicoRepository.Find(idInforme);

            if (entidad == null)
            {
                throw new Exception("Certificado no existe.");
                return _mapper.Map<InformeTecnicoDto>(entidad);
            }

         
            var dto = _mapper.Map<InformeTecnicoDto>(entidad);
            dto.EsInforme = entidad.EsInforme;

            dto.JsonDatosSolicitud = entidad.JsonDatosSolicitud; 
            dto.JsonNumeracion = entidad.JsonNumeracion; 
            dto.JsonZonificacion = entidad.JsonZonificacion;


            return _mapper.Map<InformeTecnicoDto>(dto);
        }
        public async Task<InformeTecnicoDto> ObtenerInformePorIdSolicitud(int idSolicitud)
        {
            var entidad = await _informeTecnicoRepository.BuscarInformePorIdSolicitud(idSolicitud);

            if (entidad == null)
            {
                throw new Exception("Certificado no existe.");
                return _mapper.Map<InformeTecnicoDto>(entidad);
            }



            return _mapper.Map<InformeTecnicoDto>(entidad);
        }
        public async Task<DatosSolicitudDto> ObtenerSolicitudAsync(string numSolicitud)
        {


            var solicitud = await _solicitudRepository.BuscarxNumeroSolicitudCucAsync(numSolicitud);

            if (solicitud == null)
            {
                throw new Exception("Número de solicitud no válido");
            }

            await _context.Entry(solicitud).Reference(e => e.Procedimiento).Query().LoadAsync();
            await _context.Entry(solicitud).Reference(e => e.Solicitante).Query().Include(e => e.Domicilio).LoadAsync();
            await _context.Entry(solicitud).Reference(e => e.RepresentanteLegal).Query().Include(e => e.Domicilio).LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.Pagos).Query()
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.InformeTecnico).Query()
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.TblCodigo)
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Fichas)
                                                                        .ThenInclude(e => e.UbicacionPredios)
                                                                        .ThenInclude(e => e.Puertas)
                                                                        .ThenInclude(e => e.Via)
                                                                        .ThenInclude(e => e.TipoVia)
                                                                         .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Fichas)
                                                                        .ThenInclude(e => e.UbicacionPredios).ThenInclude(e => e.Edificacion)
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Fichas)
                                                                        .ThenInclude(e => e.Sunarps)
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.TblCodigo)
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Lote).ThenInclude(e => e.Manzana).ThenInclude(e => e.Sector).ThenInclude(e => e.Ubigeo)
                                                                        .LoadAsync();
            //var dto = _mapper.Map<DatosSolicitudDto>(solicitud);
            //return new OperacionDto<DatosSolicitudDto>(dto);

            return _mapper.Map<DatosSolicitudDto>(solicitud);
        }




        public async Task<DatosSolicitudDto> ObtenerAsyncSolicitudxAnioxNumero(string numSolicitud, int anio)
        {


            var solicitud = await _solicitudRepository.BuscarPorNumeroSolicitudAsync(numSolicitud , anio);

            if (solicitud == null)
            {
                throw new Exception("Número de solicitud no válido");
            }

            await _context.Entry(solicitud).Reference(e => e.Procedimiento).Query().LoadAsync();
            await _context.Entry(solicitud).Reference(e => e.Solicitante).Query().Include(e => e.Domicilio).LoadAsync();
            await _context.Entry(solicitud).Reference(e => e.RepresentanteLegal).Query().Include(e => e.Domicilio).LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.Pagos).Query()
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.InformeTecnico).Query()
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.TblCodigo)
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Fichas)
                                                                        .ThenInclude(e => e.UbicacionPredios)
                                                                        .ThenInclude(e => e.Puertas)
                                                                        .ThenInclude(e => e.Via)
                                                                        .ThenInclude(e => e.TipoVia)
                                                                         .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Fichas)
                                                                        .ThenInclude(e => e.UbicacionPredios).ThenInclude(e => e.Edificacion)
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Fichas)
                                                                        .ThenInclude(e => e.Sunarps)
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.TblCodigo)
                                                                        .LoadAsync();

            await _context.Entry(solicitud).Collection(e => e.SolicitudCuc).Query()
                                                                        .Include(e => e.UnidadCatastral)
                                                                        .ThenInclude(e => e.Lote).ThenInclude(e => e.Manzana).ThenInclude(e => e.Sector).ThenInclude(e => e.Ubigeo)
                                                                        .LoadAsync();
            //var dto = _mapper.Map<DatosSolicitudDto>(solicitud);
            //return new OperacionDto<DatosSolicitudDto>(dto);

            return _mapper.Map<DatosSolicitudDto>(solicitud);
        }






        
        public async Task<string> BuscarMaxRegistroCorrelativoAsyn()
        {
            var maxInforme = await _informeTecnicoRepository.BuscarMaxNumeroCorrelativoAsyn();
            var numCorrelativo = "";
            var numeroCorrelativo = " ";
            var date = DateTime.UtcNow; 

            if (maxInforme != null)
            {
                if (!string.IsNullOrEmpty(maxInforme.NumCorrelativo) && maxInforme.FechaRegistro.Year == date.Year)
                {
                    numCorrelativo = (int.Parse(maxInforme.NumCorrelativo.Substring(0, 4)) + 1).ToString("D4");
                }
            }
            else
            {
                numCorrelativo = "0001";
            }

            numeroCorrelativo = numCorrelativo + '-' + date.Year.ToString();

            return numeroCorrelativo;
        }
        public async Task<List<SolicitudRequisitoDto>> ListarxSolicitudAsync(int idSolicitud)
        {
            var SolicitudRequisito = await _solicitudRepository.ListarxSolicitudAsync(idSolicitud);
            var dto = _mapper.Map<List<SolicitudRequisitoDto>>(SolicitudRequisito);
            var coun = 1;
             foreach(var iten in dto)
            {
                iten.numero =  coun++;
            } 
          

            //var respuesta = dto.(x => x.numero = coun++);

            return new List<SolicitudRequisitoDto>(dto);
        }
        public async Task<LoteZonificacionParametroDto> ObtenerPorIdLoteCartografiaAsync(string IdLoteCartografia)
        {
            var entidad = await _loteZonificacionParametroRepository.BuscarPorIdLoteCartografiaAsync(IdLoteCartografia);

            if (entidad == null)
            {
                throw new Exception("Los Parámetros urbanísticos de la zonificación no está registrado.");
                return _mapper.Map<LoteZonificacionParametroDto>(entidad);

            }

            return _mapper.Map<LoteZonificacionParametroDto>(entidad);

        }
        public async Task<InformeTecnicoDto?> EstadoGeneradoInforme(int id)
        {
            var response = await _informeTecnicoRepository.EstadoGeneradoInforme(id);

            return _mapper.Map<InformeTecnicoDto>(response);
        }
        public async Task<ResponsePagination<InformeTecnicoPaginadoDto>> PaginatedSearch(RequestPagination<InformeTecnicoPaginadoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<InformeTecnico>>(dto);
            var response = await _informeTecnicoRepository.PaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<InformeTecnicoPaginadoDto>>(response);
        }
    }

}
