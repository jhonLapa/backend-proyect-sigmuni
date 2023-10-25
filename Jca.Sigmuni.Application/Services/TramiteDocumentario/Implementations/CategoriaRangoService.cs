using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class CategoriaRangoService : ICategoriaRangoService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRangoRepository _categoriaRangoRepository;
        private readonly IProcedimientoRepository _procedimientoRepositorio;
        private readonly IProcedimientoRequisitoRepository _procedimientoRequisitoRepositorio;


        public CategoriaRangoService(IMapper mapper, IProcedimientoRequisitoRepository procedimientoRequisitoRepositorio, ICategoriaRangoRepository categoriaRangoRepository, IProcedimientoRepository procedimientoRepositorio)
        {
            _mapper = mapper;
            _procedimientoRequisitoRepositorio = procedimientoRequisitoRepositorio;
            _categoriaRangoRepository = categoriaRangoRepository;
            _procedimientoRepositorio = procedimientoRepositorio;
        }
        //Task<RespuestaSimpleDto<string>>> CrearOActualizar(CategoriaRangoConsultaDto peticion)
        public async Task<CategoriaRangoDto> CrearOActualizar(CategoriaRangoConsultarDto peticion)
        {
 
            var procedimiento = await _procedimientoRepositorio.Find(peticion.Asunto.Id);
            if (procedimiento == null)
            {
             throw new Exception("procedimiento no está registrado en nuestro sistema");


            };

      

                procedimiento.PlazoReconsIcl = peticion.PlazoReconsideracionR;
                procedimiento.PlazoApelIcl = peticion.PlazoApelacionR;
                procedimiento.PlazoReconsAdministrativo = peticion.PlazoReconsideracionP;
                procedimiento.PlazoApelAdministrativo = peticion.PlazoApelacionP;
                await _procedimientoRepositorio.Edit(peticion.Asunto.Id, procedimiento);



                #region Registro de CategoriaRango
                foreach (var item in peticion.MontoTramite)
                {
                    int idEntidadProcedimiento = procedimiento.Id;
                    //int? idCategoria = item.IdCategoria;
                    //int? idRango = item.IdRango;

                    int? idCategoria = item.Categoria != null ? item.Categoria?.IdCategoria : null;
                    int? idRango = item.Rango != null ? item.Rango?.IdRango : null;

                    int id = item.Id;



                    var entidadCategoriaRango = await _categoriaRangoRepository.Find(id);

                    if (entidadCategoriaRango == null)
                    {
                        entidadCategoriaRango = new CategoriaRango();
                    }

                    entidadCategoriaRango.PorcentajeUit = item.PorcentajeUit;
                    entidadCategoriaRango.Importe = item.Importe;
                    entidadCategoriaRango.Anio = peticion.Anio;
                    entidadCategoriaRango.IdCategoria = idCategoria;
                    entidadCategoriaRango.IdRango = idRango;
                    entidadCategoriaRango.IdProcedimiento = idEntidadProcedimiento;
                    entidadCategoriaRango.PlazoResolver = item.PlazoResolver;

                    if (entidadCategoriaRango.Id == 0)
                    {
                        await _categoriaRangoRepository.Create(entidadCategoriaRango);


                    }
                    else
                    {
                        entidadCategoriaRango.Estado = item.Estado;
                        await _categoriaRangoRepository.Edit(id, entidadCategoriaRango);

                    }


                }

                #endregion

                #region Registro de Requisitos
                foreach (var item in peticion.ArrayRequisitos)
                {
                    var idRequisito = item.Id;

                    if (idRequisito != 0)
                    {
                        var idEntidadProcedimiento = procedimiento.Id;
                        var entidadRequisito = await _procedimientoRequisitoRepositorio.BuscarProcedimientoRequisitoPorIdProcedimientoIdRequisitoAsync(idEntidadProcedimiento, idRequisito);

                        if (entidadRequisito == null)
                        {
                            entidadRequisito = new ProcedimientoRequisito();
                        }

                        entidadRequisito.IdRequisito = idRequisito;
                        entidadRequisito.IdProcedimiento = idEntidadProcedimiento;

                        if (entidadRequisito.Id == 0)
                        {
                            await  _procedimientoRequisitoRepositorio.Create(entidadRequisito);
                        }
                        else
                        {
                            entidadRequisito.Estado = item.Estado;
                            await _procedimientoRequisitoRepositorio.Edit(entidadRequisito.Id, entidadRequisito);
                        }
                    }

                }
            #endregion

            var dto = new CategoriaRangoDto()
            {

                IdProcedimiento = procedimiento.Id,
                Anio = peticion.Anio


            };


            return _mapper.Map<CategoriaRangoDto>(dto);



            //return prueba;
        }

        public async Task<CategoriaRangoConsultarDto> ObtenerRangoyCategoria(int id, int anio)
        {
            var entidad = await _categoriaRangoRepository.ObtenerCategoriaRangoxProcedimiento(id, anio);
            int tipo = 0;

            if (entidad == null)
            {
                throw new Exception("procedimiento no está registrado en nuestro sistema");
             

            };



            foreach (var item in entidad)
            {
                if (item.Rango != null && item.Categoria != null) tipo = 1;
                else if (item.Rango == null && item.Categoria == null) tipo = 2;
                else if (item.Rango == null && item.Categoria != null) tipo = 3;
            }


            // var procedimiento = await _procedimientoRepositorio.BuscarPorIdYNoBorradoAsync(id);
            var requisitos = await _procedimientoRequisitoRepositorio.ListarxProcedimientoAsync(id);

            var listaRequisito = new List<RequisitoDto>();
            var listaProcedimientoRequisito = new List<ProcedimientoRequisitoDto>();




            if (requisitos != null)
            {

                foreach (var item in requisitos)
                {
                    listaProcedimientoRequisito.Add(_mapper.Map<ProcedimientoRequisitoDto>(item));
                    if (item.Requisito != null)
                    {
                        listaRequisito.Add(_mapper.Map<RequisitoDto>(item.Requisito));
                    }
                }
            }



            var dto = new CategoriaRangoConsultarDto()
            {
                MontoTramite = _mapper.Map<List<CategoriaRangoDto>>(entidad),
                Asunto = _mapper.Map<ProcedimientoDto>(entidad.FirstOrDefault().Procedimiento),
                ArrayRequisitos = listaRequisito,
                ArrayProcedimientoRequisitos = listaProcedimientoRequisito,
                Anio = (int)entidad.FirstOrDefault().Anio,
                Tipo = tipo,
                tipoTramite = _mapper.Map<TipoTramiteDto?>(entidad.FirstOrDefault().Procedimiento.TipoTramite),
                //arrayPlano = _mapper.Map<List<CategoriaRangoDto>>(entidad),
                PlazoReconsideracionR = (entidad.FirstOrDefault().Procedimiento.PlazoReconsIcl),
                PlazoApelacionR = (entidad.FirstOrDefault().Procedimiento.PlazoApelIcl),
                PlazoReconsideracionP = (entidad.FirstOrDefault().Procedimiento.PlazoApelIcl),
                PlazoApelacionP = (entidad.FirstOrDefault().Procedimiento.PlazoApelAdministrativo),





                //procedimiento.PlazoApelIcl = peticion.PlazoApelacionR,
                //procedimiento.PlazoReconsAdministrativo = peticion.PlazoReconsideracionP,
                //procedimiento.PlazoApelAdministrativo = peticion.PlazoApelacionP,

            };
          
            
            return _mapper.Map<CategoriaRangoConsultarDto>(dto);

        }

        public async Task<IList<CategoriaRangoDto>> FindAll()
        {
            var response = await _categoriaRangoRepository.FindAll();

            return _mapper.Map<IList<CategoriaRangoDto>>(response);
        }

        public async Task<CategoriaRangoDto?> Disable(int id)
        {
            var response = await _categoriaRangoRepository.Disable(id);

            return _mapper.Map<CategoriaRangoDto>(response);
        }


        public async Task<ResponsePagination<CategoriaRangoDto>> PaginatedSearch(RequestPagination<CategoriaRangoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<CategoriaRango>>(dto);

            var response = await _categoriaRangoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<CategoriaRangoDto>>(response);
        }

     

    }
}
