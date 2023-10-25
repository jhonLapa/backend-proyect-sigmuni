using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;
        private readonly ApplicationDbContext _context;
        private readonly IDocumentoService _documentoService;
        public ProductoService(ApplicationDbContext context,  IMapper mapper, IProductoRepository ProductoRepository,
              IDocumentoService documentoService
            )
        {
            _mapper = mapper;
            _productoRepository = ProductoRepository;
            _context = context;
            _documentoService = documentoService;

        }


        public async Task<ProductoDto> ObtenerPorNumSolicitud(string numSolicitud)
        {
            var entidad = await _productoRepository.ObtenerSolicitudPorNumSolicitud(numSolicitud);
            if (entidad == null)
            {
                throw new Exception("Producto no existe");

                //return new OperacionDto<CertificadoCatastralDto>(CodigosOperacionDto.NoExiste, "Certificado no existe");
                return _mapper.Map<ProductoDto>(entidad);


            }
            return _mapper.Map<ProductoDto>(entidad);
        }
        public async Task<ProductoDto> ObtenerAsync(int idProducto)
        {
            var entidad = await _productoRepository.BuscarPorIdAsync(idProducto);

            string jsonCestificadoRespuesta = null;

            if (entidad == null)
            {
                throw new Exception("Producto no existe");

                //return new OperacionDto<CertificadoCatastralDto>(CodigosOperacionDto.NoExiste, "Certificado no existe");
                return _mapper.Map<ProductoDto>(entidad);


            }

            if (entidad.JsonProducto != null)
            {
                jsonCestificadoRespuesta = entidad.JsonProducto;
            }

           
            var dto = _mapper.Map<ProductoDto>(entidad);
            dto.JsonProducto = jsonCestificadoRespuesta;

            return _mapper.Map<ProductoDto>(dto);

        }

        public async Task<ProductoDto> BuscarMaxRegistroCorrelativoAsyn(int flag)
        {
            var solicitud = await _productoRepository.BuscarMaxNumeroCorrelativoAsyn(flag);
            return _mapper.Map<ProductoDto>(solicitud);
        }

        public async Task<ProductoDto?> EstadoGeneradoProducto(int id)
        {
            var response = await _productoRepository.EstadoGeneradoProducto(id);

            return _mapper.Map<ProductoDto>(response);
        }

        public async Task<ProductoRespuestaDto> CrearAsync(ProductoDto peticion)
        {

            var entidad = await _productoRepository.BuscarPorIdAsync(peticion.Id);

            if (entidad == null)
            {
                entidad = new Producto();
            }

            var maxCertificado = await _productoRepository.BuscarMaxCertificadoAsync(peticion.Flag);
            var date = DateTime.UtcNow;

            var numCorrelativo = "";

            if (maxCertificado != null)
            {
                if (!string.IsNullOrEmpty(maxCertificado.NumCorrelativo) && maxCertificado.FechaRegistro.Year == date.Year)
                {
                    numCorrelativo = (int.Parse(maxCertificado.NumCorrelativo.Substring(0, 4)) + 1).ToString("D4");
                }
            }
            else
            {
                numCorrelativo = "0001";
            }

            entidad.NumCorrelativo = numCorrelativo + '-' + date.Year.ToString();

            // FLAG POR TIPO DE CERTIFICADO CATASTRAL
            //1 = Certificado de Parámetros Urbanísticos y Edificatorios
            //2 = Certificado de Zonificación y Vías
            //3 = Certificado de Jurisdicción
            //4 = Certificado de Nomenclatura
            //5 = Certificado de Numeración
            //6 = Asignacion de numeración
            //7 = Certificado de Antecedentes de Nomenclatura y Numeración
            //8 = Visación de planos para fines de rectificación de área y linderos
            //9 = Plano Catastral
            //10 = Plano Informativo de Colindancias 
            //11 = Plano general de Lima Metropolitana
            //12 = Plano de ubicación a nivel de lote
            //13 = Plano temático
            //14 = Hoja Informativa Catastral Urbana
            //15 = Constancia de verificación catastral
            //16 = Consolidación de información por predio
            //17 = Certificado Catastral



            entidad.FechaEmision = DateTime.UtcNow;
            entidad.FechaCaducidad = date.AddMonths(3);
            entidad.Flag = peticion.Flag;
            entidad.IdSolicitud = peticion.IdSolicitud;
            entidad.JsonProducto = peticion.JsonProducto;
            entidad.NumInforme = peticion.NumInforme;
            entidad.NumPlanoZonificacion = peticion.NumPlanoZonificacion;
            entidad.NumPlanoVia = peticion.NumPlanoVia;

            if (entidad.Id == 0)
            {
                var validarCertificado = await _productoRepository.BuscarPorNumeroCorrelativoAsync(entidad.NumCorrelativo, peticion.Flag);
                var validarSolcitud = await _productoRepository.BuscarSolicitudRegistradaAsync(peticion.IdSolicitud);

                if (validarCertificado != null)
                {
                    throw new Exception("El Número de Certificado ya existe");

                    return _mapper.Map<ProductoRespuestaDto>(validarCertificado);

                }
                else
                {
                    if (validarSolcitud != null)
                    {
                        var idCertificadoEncontrado = validarSolcitud.Id;
                        var dataCertificado = await _productoRepository.BuscarPorIdAsync(idCertificadoEncontrado);

                        return _mapper.Map<ProductoRespuestaDto>(dataCertificado);
                    }
                    else
                    {
                        entidad.Id = peticion.Id;
                        //await _productoRepository.Edit(peticion.Id ,entidad);
                        await _productoRepository.Create(entidad);
                    }
                }
            }
            //await _productoRepository.Edit(peticion.Id, entidad);
            //await _productoRepository.Create(entidad); 
            //await _context.SaveChangesAsync();

            var idCertificadoRegistrado = entidad.Id;
            var data = await _productoRepository.BuscarPorIdAsync(idCertificadoRegistrado);

            return  _mapper.Map<ProductoRespuestaDto>(data);

        }





        public async Task<bool> AdjuntarDocumentoProducto(ProductoDocumento peticion)
        {


            var Correcto = true;




            if (peticion.Documento != null)
            {
                var responseDocumento = await _documentoService.Create(peticion.Documento);
                peticion.IdDocumento = responseDocumento.IdDocumentoB64;
            }



            var entidad = await _productoRepository.BuscarPorIdAsync(peticion.Id);

            if (entidad == null)
            {
                throw new Exception("Producto no existe");

                //return new OperacionDto<CertificadoCatastralDto>(CodigosOperacionDto.NoExiste, "Certificado no existe");
                return Correcto;
            }

            //flag tipo_documento
            //1 = dentro_informe
            //2 = fuera_informe

            entidad.IdDocumento = peticion.IdDocumento;


      
            await _productoRepository.Edit(peticion.Id, entidad);
        



            return Correcto;
        }

        public async Task<bool> eliminarDocumentoProducto(ProductoDto peticion)
        {

            var Correcto = true;


            var entidad = await _productoRepository.BuscarPorIdAsync(peticion.Id);


            if (entidad == null)
            {
                throw new Exception("Producto no existe");

                //return new OperacionDto<CertificadoCatastralDto>(CodigosOperacionDto.NoExiste, "Certificado no existe");
                return Correcto;


            }

            //flag tipo_documento
            //1 = dentro_informe
            //2 = fuera_informe

            entidad.IdDocumento = null;



            await _productoRepository.Edit(peticion.Id, entidad);




            return Correcto;
        }


        public async Task<ResponsePagination<ProductoPaginadoDto>> PaginatedSearch(RequestPagination<ProductoPaginadoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Producto>>(dto);
            var response = await _productoRepository.PaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<ProductoPaginadoDto>>(response);
        }

        public async Task<ResponsePagination<ProductoInformeBusquedaDto>> PaginacionProducto(RequestPagination<ProductoInformeBusquedaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<ProductoInformeBusqueda>>(dto);
            var response = await _productoRepository.PaginatedSearhProducto(entity);
            return _mapper.Map<ResponsePagination<ProductoInformeBusquedaDto>>(response);
        }

    }
}
