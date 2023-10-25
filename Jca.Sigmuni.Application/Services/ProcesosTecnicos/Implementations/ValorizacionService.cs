using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Util.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ValorizacionService : IValorizacionService
    {
        private readonly IMapper _mapper;
        private readonly IFichaRepository _fichaRepository;
        private readonly IArancelRepository _arancelRepository;
        private readonly IValorObraComplementariaRepository _valorObraComplementariaRepository;
        private readonly IFichaIndividualRepository _fichaIndividualRepository;
        private readonly IUnidadCatastralRepository _unidadCatastralRepository;

        public ValorizacionService(
                                IMapper mapper,
                                IFichaRepository fichaRepository,
                                IArancelRepository arancelRepository,
                                IValorObraComplementariaRepository valorObraComplementariaRepository,
                                IFichaIndividualRepository fichaIndividualRepository,
                                IUnidadCatastralRepository unidadCatastralRepository
                                )
        {
            _mapper = mapper;
            _fichaRepository = fichaRepository;
            _arancelRepository = arancelRepository;
            _valorObraComplementariaRepository = valorObraComplementariaRepository;
            _fichaIndividualRepository = fichaIndividualRepository;
            _unidadCatastralRepository = unidadCatastralRepository;
        }

        public async Task<ResponsePagination<ValorizacionBusquedaDto>> PaginatedSearch(RequestPagination<ValorizacionBusquedaDto> request)
        {
            var entityRequest = _mapper.Map<RequestPagination<ValorizacionBusqueda>>(request);
            var response = await _fichaRepository.PaginatedSearchValorizacion(entityRequest);
            var result = _mapper.Map<ResponsePagination<ValorizacionBusquedaDto>>(response);

            return result;
        }

        public async Task<List<ValorizacionBusquedaDto>> ListarPorFiltro(ValorizacionBusquedaDto request)
        {
            var entityRequest = _mapper.Map<ValorizacionBusqueda>(request);
            var response = await _fichaRepository.SearchValorizacion(entityRequest);
            var result = _mapper.Map<List<ValorizacionBusquedaDto>>(response);

            for (int i = 0; i < result.Count; i++)
            {
                var dto = result[i];

                var fichaIndividual = await _fichaRepository.Find(dto.IdFicha ?? 0);

                List<Construccion> listaConstrucciones = new List<Construccion>();
                List<OtraInstalacionDto> listaOtrasInstalaciones = new List<OtraInstalacionDto>();

                // ficha individual
                if (fichaIndividual.DescripcionPredios.Count > 0)
                {
                    decimal? area = fichaIndividual.DescripcionPredios.FirstOrDefault().AreaVerificada;
                    if (fichaIndividual.UbicacionPredios.Count > 0)
                    {
                        if (fichaIndividual.UbicacionPredios.FirstOrDefault().Puertas.Count > 0)
                        {
                            if (fichaIndividual.UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via != null)
                            {
                                var arancel = await _arancelRepository.BuscarPorIdViaAsync(fichaIndividual.UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via.IdVia);
                                decimal? valoArancel = arancel != null ? arancel.Valor : null;
                                dto.ValorTerreno = (area ?? 0) * (valoArancel ?? 0);
                            }
                        }
                    }
                }

                if (fichaIndividual.OtraInstalaciones.Count > 0)
                {
                    var otrasInstalacionesFIndividual = _mapper.Map<List<OtraInstalacionDto>>(fichaIndividual.OtraInstalaciones);

                    if (otrasInstalacionesFIndividual.Count > 0 && otrasInstalacionesFIndividual != null)
                    {
                        foreach (var otraInstalacion in otrasInstalacionesFIndividual)
                        {
                            var idTipo = otraInstalacion.TipoOtraInstalacion != null ? otraInstalacion.TipoOtraInstalacion.IdTipoOtraInstalacion : 0;
                            var valorTipoObraComplementaria = await _valorObraComplementariaRepository.BuscarPorIdTipoAsync(idTipo);
                            if (valorTipoObraComplementaria != null)
                            {
                                var valor = otraInstalacion.ProductoTotal * valorTipoObraComplementaria.Valor;
                                otraInstalacion.UnidadMedida = _mapper.Map<UnidadMedidaDto>(valorTipoObraComplementaria.TipoOtraInstalacion.UnidadMedida);
                                otraInstalacion.Valor = valor;
                            }

                            listaOtrasInstalaciones.Add(otraInstalacion);
                        }
                    }
                }

                // Cálculo de ValorTotalObrasComplementarias
                decimal? valorObras = 0;
                foreach (var item in listaOtrasInstalaciones)
                {
                    var valor = item.Valor != null ? item.Valor : 0;
                    valorObras += valor;
                }
                dto.ValorTotalObrasComplementarias = (decimal)valorObras;

                // Cálculo ValorizacionTotal
                dto.ValorizacionTotal = (dto.ValorTerreno ?? 0) + (dto.ValorTotalConstruccion ?? 0) + (dto.ValorTotalObrasComplementarias ?? 0);



                // ficha bien comun
                var fichaBienComun = await _fichaRepository.FindBienComunByIdAsync(dto.IdFichaPadre ?? 0);

                if (fichaBienComun != null)
                {
                    if (fichaBienComun.Construcciones.Count > 0)
                    {
                        foreach (var item in fichaBienComun.Construcciones)
                        {
                            listaConstrucciones.Add(item);
                        }
                    }

                    if (fichaBienComun.OtraInstalaciones.Count > 0)
                    {
                        var otrasInstalacionesFBienComun = _mapper.Map<List<OtraInstalacionDto>>(fichaBienComun.OtraInstalaciones);

                        if (otrasInstalacionesFBienComun.Count > 0 && otrasInstalacionesFBienComun != null)
                        {
                            decimal sumaAreasOtrasIntalaciones = 0;
                            foreach (var otraInstalacion in otrasInstalacionesFBienComun)
                            {
                                sumaAreasOtrasIntalaciones += (decimal)otraInstalacion.ProductoTotal;
                            }
                            for (int j = 0; j < otrasInstalacionesFBienComun.Count; j++)
                            {
                                var otraInstalacion = otrasInstalacionesFBienComun[j];
                                var idTipo = otraInstalacion.TipoOtraInstalacion != null ? otraInstalacion.TipoOtraInstalacion.IdTipoOtraInstalacion : 0;
                                var tipoObraComplementaria = await _valorObraComplementariaRepository.BuscarPorIdTipoAsync(idTipo);
                                var valorTipoObraComplementaria = tipoObraComplementaria != null ? tipoObraComplementaria.Valor : 0;
                                var recapitulacionBienComuns = await FichaBienComunIdRecapitulacionBienesComunesAsync(fichaIndividual.IdFichaPadre ?? 0);
                                var porcentajeAreaComun = recapitulacionBienComuns.Count > 0 ? recapitulacionBienComuns[j].BcFisicoTerreno : 0;
                                var area = sumaAreasOtrasIntalaciones * (porcentajeAreaComun / 100);
                                var valor = area * valorTipoObraComplementaria;

                                otraInstalacion.Valor = valor;
                                if (tipoObraComplementaria != null)
                                    otraInstalacion.UnidadMedida = _mapper.Map<UnidadMedidaDto>(tipoObraComplementaria.TipoOtraInstalacion.UnidadMedida);
                                listaOtrasInstalaciones.Add(otraInstalacion);
                            }
                        }
                    }
                }

                // Cálculo de ValorTotalConstruccion
                decimal? valorConstrucciones = 0;
                foreach (var item in listaConstrucciones)
                {
                    var valor = item.ValorConstruccion != null ? item.ValorConstruccion : 0;
                    valorConstrucciones += valor;
                }
                dto.ValorTotalConstruccion += (decimal)valorConstrucciones;

                // Cálculo de ValorTotalObrasComplementarias
                decimal? valorObrasBC = 0;
                foreach (var item in listaOtrasInstalaciones)
                {
                    var valor = item.Valor != null ? item.Valor : 0;
                    valorObrasBC += valor;
                }
                dto.ValorTotalObrasComplementarias += (decimal)valorObrasBC;

                // Cálculo ValorizacionTotal
                dto.ValorizacionTotal = (dto.ValorTerreno ?? 0) + (dto.ValorTotalConstruccion ?? 0) + (dto.ValorTotalObrasComplementarias ?? 0);
            }

            return result;
        }

        private async Task<List<RecapitulacionDeBienesComunesDto>> FichaBienComunIdRecapitulacionBienesComunesAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindBienComunByIdAsync(idFicha);

            if (ficha == null) throw new Exception("No se encontro la ficha bien comun");

            var dto = _mapper.Map<BienComunDto>(ficha);
            long idFichaIndividual = 0;
            decimal? sumaAreasComunes = 0;
            decimal? sumaAreasOtrasInstalaciones = 0;
            if (dto.Construcciones != null)
            {
                dto.Construcciones.ForEach(contruc =>
                {
                    if (contruc.Uca.Codigo == "99")
                    {
                        sumaAreasComunes = sumaAreasComunes + contruc.AreaVerificada;

                    }

                });
            };
            if (dto.OtraInstalaciones != null)
            {
                dto.OtraInstalaciones.ForEach(otrasIns =>
                {
                    if (otrasIns.Uca.Codigo == "99")
                    {
                        sumaAreasOtrasInstalaciones = sumaAreasOtrasInstalaciones + otrasIns.ProductoTotal;

                    }

                });
            };


            List<RecapitulacionDeBienesComunesDto> recapitulacionList = new List<RecapitulacionDeBienesComunesDto>();
            decimal? sumaAreas = 0;


            var fichasAsociadas = await _fichaRepository.BuscarPorIdFichaPadreYEstadoFichaAsync(ficha.IdFicha, (int)EstadoFicha.Estatico); // el estado es estatico porque ahora ficha individual cambió de estado por control de calidad

            if (fichasAsociadas != null)
            {
                dto.CantidadUnidadesAsociadas = fichasAsociadas.Count();
                for (int i = 0; i < fichasAsociadas.Count(); i++)
                {
                    //Reporte prorrateo
                    decimal? sumaAreaTerrenoVerificada = 0;
                    decimal? sumaAreaTechadaVerificada = 0;
                    decimal? sumaObrasComplementarias = 0;

                    if (fichasAsociadas[i].IdTipoFicha == (int)TipoFichaEnum.Individual)
                    {
                        RecapitulacionDeBienesComunesDto recap = new RecapitulacionDeBienesComunesDto();
                        //recapitulacion 
                        var fichaindividualUnidad = await _fichaIndividualRepository.Find(fichasAsociadas[i].IdFicha);
                        var unidadCatrastal = await _unidadCatastralRepository.Find(fichasAsociadas[i].IdUnidadCatastral);
                        var dtoUnidadCatrastal = _mapper.Map<UnidadCatastralDto>(unidadCatrastal);
                        if (fichaindividualUnidad != null && fichaindividualUnidad.PredioCatastralAn != null)
                        {
                            if (fichaindividualUnidad.PredioCatastralAn.Codigo == "99")
                            {
                                recap.BcGeneralLlegal = fichaindividualUnidad.PorcBcGenLegal;
                                recap.BcLlegalTerreno = fichaindividualUnidad.PorcBcLegalTerr;
                                recap.BcLlegalConstruccion = fichaindividualUnidad.PorcBcLegalConst;
                                sumaAreas = sumaAreas + fichaindividualUnidad.AreaOcupadaVerif;
                                recap.AreaTerrenoOcupadaVerificada = fichaindividualUnidad.AreaOcupadaVerif;
                                recap.CodPCA = fichaindividualUnidad.PredioCatastralAn.Codigo;

                            }

                        }

                        //Calculo Areas propias / construcciones y obras complementarias

                        foreach (var itemConstruccion in fichasAsociadas[i].Construcciones)
                        {
                            if (itemConstruccion.Uca.Codigo == "99")
                            {
                                if (itemConstruccion.AreaVerificada != null)
                                {
                                    sumaAreaTerrenoVerificada += itemConstruccion.AreaVerificada;
                                }

                                if (itemConstruccion.AreaTechadaDeclarada != null)
                                {
                                    sumaAreaTechadaVerificada += itemConstruccion.AreaTechadaDeclarada;
                                }
                            }

                        }

                        foreach (var itemOtraInsta in fichasAsociadas[i].OtraInstalaciones)
                        {
                            if (itemOtraInsta.Uca.Codigo == "99")
                            {
                                if (itemOtraInsta.ProductoTotal != null)
                                {
                                    sumaObrasComplementarias += itemOtraInsta.ProductoTotal;
                                }
                            }

                        }
                        recap.idFichaIndividual = fichasAsociadas[i].IdFicha;
                        recap.UnidadCatastral = dtoUnidadCatrastal;
                        List<ProrrateoPisoDto> prorrateoPiso = new List<ProrrateoPisoDto>();
                        foreach (var itemConstruccion in fichasAsociadas[i].Construcciones)
                        {
                            ProrrateoPisoDto prorrateoPisoX = new ProrrateoPisoDto();
                            prorrateoPisoX.Piso = itemConstruccion.NumeroPiso;

                            prorrateoPisoX.AreaTechadaVerificadaPiso = itemConstruccion.AreaVerificada;
                            prorrateoPisoX.BcGeneralLlegalPiso = fichaindividualUnidad.PorcBcGenLegal / itemConstruccion.AreaVerificada;
                            prorrateoPiso.Add(prorrateoPisoX);
                        }

                        //Reporte prorrateo
                        recap.AreaTerrenoVerificada = sumaAreaTerrenoVerificada;
                        recap.AreaTechadaVerificada = sumaAreaTechadaVerificada;
                        recap.ObrasComplementarias = sumaObrasComplementarias;
                        recap.Ambito = dtoUnidadCatrastal.Ambito;
                        recap.pisoProrrateo = prorrateoPiso;


                        recapitulacionList.Add(recap);
                        // end
                        idFichaIndividual = fichasAsociadas[0].IdFicha;
                        dto.idFichaIndividual = fichasAsociadas[i].IdFicha;



                    }

                }

            }

            if (recapitulacionList.Count > 0)
            {
                recapitulacionList.ForEach(recaplist =>
                {
                    recaplist.BcFisicoTerreno = (recaplist.AreaTerrenoOcupadaVerificada * 100) / sumaAreas;
                    recaplist.BcFisicoContruccion = (recaplist.AreaTerrenoOcupadaVerificada * 100) / sumaAreas;
                    if (dto.DescripcionPredio != null && dto.DescripcionPredio.AreaVerificada != null && recaplist.BcFisicoTerreno != null)
                    {
                        recaplist.ATC = (recaplist.BcFisicoTerreno * dto.DescripcionPredio.AreaVerificada) / 100;
                    }
                    else
                    {
                        recaplist.ATC = 0;
                    }
                    recaplist.ACC = (recaplist.BcFisicoTerreno * sumaAreasComunes) / 100;
                    recaplist.AOIC = (recaplist.BcFisicoTerreno * sumaAreasOtrasInstalaciones) / 100;
                });

            }

            return new List<RecapitulacionDeBienesComunesDto>(recapitulacionList);
        }

        public async Task<ResponsePagination<AnioReporteDto>> ListarAniosValorizacionAsync(RequestPagination<AnioReporteDto> request)
        {
            var entityRequest = _mapper.Map<RequestPagination<AnioReporte>>(request);
            var listaAnios = await _fichaRepository.ListarAniosValorizacionAsync(entityRequest);
            var result = _mapper.Map<ResponsePagination<AnioReporteDto>>(listaAnios);

            return result;
        }

        public async Task<ValorizacionDetalleDto> ObtenerDetalleValorizacionPorIdFichaAsync(int idFicha)
        {
            List<ValorConstruccionDto> listaValorConstruccion = new List<ValorConstruccionDto>();
            var ficha = await _fichaRepository.FindByIdAsync(idFicha);

            var dto = _mapper.Map<ValorizacionDetalleDto>(ficha);


            // ficha individual
            List<OtraInstalacionDto> listaOtrasInstalaciones = new List<OtraInstalacionDto>();

            if (ficha.DescripcionPredios.Count > 0)
            {
                decimal? area = ficha.DescripcionPredios.FirstOrDefault().AreaVerificada;
                Arancel? arancel = null;
                if(dto.Via != null)
                {
                    arancel = await _arancelRepository.BuscarPorIdViaAsync(dto.Via.IdVia);

                }
                decimal? valoArancel = arancel != null ? arancel.Valor : null;
                dto.ValorTerreno = (area ?? 0) * (valoArancel ?? 0);
                dto.AreaTerreno = area;
                dto.ValorArancelario = valoArancel;
            }

            if (ficha.OtraInstalaciones.Count > 0)
            {
                var otrasInstalacionesFIndividual = _mapper.Map<List<OtraInstalacionDto>>(ficha.OtraInstalaciones);

                if (otrasInstalacionesFIndividual.Count > 0 && otrasInstalacionesFIndividual != null)
                {
                    foreach (var otraInstalacion in otrasInstalacionesFIndividual)
                    {
                        var idTipo = otraInstalacion.TipoOtraInstalacion != null ? otraInstalacion.TipoOtraInstalacion.IdTipoOtraInstalacion : 0;
                        var valorTipoObraComplementaria = await _valorObraComplementariaRepository.BuscarPorIdTipoAsync(idTipo);
                        if (valorTipoObraComplementaria != null)
                        {
                            var valor = otraInstalacion.ProductoTotal * valorTipoObraComplementaria.Valor;
                            otraInstalacion.UnidadMedida = _mapper.Map<UnidadMedidaDto>(valorTipoObraComplementaria.TipoOtraInstalacion.UnidadMedida);
                            otraInstalacion.Valor = valor;
                        }

                        listaOtrasInstalaciones.Add(otraInstalacion);
                    }
                }
            }


            if(dto.ValorConstruccion != null) listaValorConstruccion = dto.ValorConstruccion;

            // ficha bien comun
            if (ficha.IdFichaPadre != null)
            {
                var fichaBienComun = await _fichaRepository.FindBienComunByIdAsync((int)ficha.IdFichaPadre);

                if(fichaBienComun != null)
                {
                    if (fichaBienComun.Construcciones.Count > 0)
                    {
                        var construcionFBienComun = _mapper.Map<List<ValorConstruccionDto>>(fichaBienComun.Construcciones);

                        for (int i = 0; i < construcionFBienComun.Count; i++)
                        {
                            listaValorConstruccion.Add(construcionFBienComun[i]);
                        }
                    }

                    if (fichaBienComun.OtraInstalaciones.Count > 0)
                    {
                        var otrasInstalacionesFBienComun = _mapper.Map<List<OtraInstalacionDto>>(fichaBienComun.OtraInstalaciones);

                        if (otrasInstalacionesFBienComun.Count > 0 && otrasInstalacionesFBienComun != null)
                        {
                            decimal sumaAreasOtrasIntalaciones = 0;
                            foreach (var otraInstalacion in otrasInstalacionesFBienComun)
                            {
                                sumaAreasOtrasIntalaciones += (decimal)otraInstalacion.ProductoTotal;
                            }
                            for (int i = 0; i < otrasInstalacionesFBienComun.Count; i++)
                            {
                                var otraInstalacion = otrasInstalacionesFBienComun[i];
                                var idTipo = otraInstalacion.TipoOtraInstalacion != null ? otraInstalacion.TipoOtraInstalacion.IdTipoOtraInstalacion : 0;
                                var tipoObraComplementaria = await _valorObraComplementariaRepository.BuscarPorIdTipoAsync(idTipo);
                                var valorTipoObraComplementaria = tipoObraComplementaria != null ? tipoObraComplementaria.Valor : 0;
                                //var idCifrado = RijndaelUtilitario.EncryptRijndaelToUrl(idFichaBienComun);
                                var recapitulacionBienComuns = await FichaBienComunIdRecapitulacionBienesComunesAsync((int)ficha.IdFichaPadre);
                                var porcentajeAreaComun = recapitulacionBienComuns.Count > 0 ? recapitulacionBienComuns[i].BcFisicoTerreno : 0;
                                var area = sumaAreasOtrasIntalaciones * (porcentajeAreaComun / 100);
                                var valor = area * valorTipoObraComplementaria;

                                otraInstalacion.Valor = valor;
                                if (tipoObraComplementaria != null)
                                    otraInstalacion.UnidadMedida = _mapper.Map<UnidadMedidaDto>(tipoObraComplementaria.TipoOtraInstalacion.UnidadMedida);
                                listaOtrasInstalaciones.Add(otraInstalacion);
                            }
                        }
                    }
                }
            }

            dto.ValorConstruccion = listaValorConstruccion;
            dto.OtraInstalaciones = listaOtrasInstalaciones;

            decimal? valorConstrucciones = 0;
            foreach (var item in listaValorConstruccion)
            {
                var valor = item.ValorConstruccion != null ? item.ValorConstruccion : 0;
                valorConstrucciones += valor;
            }
            dto.ValorTotalConstruccion = valorConstrucciones;

            decimal? valorObras = 0;
            foreach (var item in listaOtrasInstalaciones)
            {
                var valor = item.Valor != null ? item.Valor : 0;
                valorObras += valor;
            }
            dto.ValorTotalObrasComplementarias = valorObras;

            return dto;
        }

        public async Task<List<ValorizacionBusquedaDto>> ListarUnidadesValorizacionReporteAniosAsync(List<AnioReporteDto> peticion)
        {
            List<ValorizacionBusquedaDto> response = new List<ValorizacionBusquedaDto>();
            foreach (var anio in peticion)
            {
                var entity = new ValorizacionBusqueda()
                {
                    Anio = anio.Anio.ToString()
                };
                var fichas = await _fichaRepository.SearchValorizacion(entity);
                //var dtoFichas = _mapper.Map<List<FichaBusquedaDto>>(fichas);
                var resultValorizacion = _mapper.Map<List<ValorizacionBusquedaDto>>(fichas);
                response.AddRange(resultValorizacion);
            }

            response = response.Where(e => e.ValorTotalConstruccion > 0 || e.ValorTotalObrasComplementarias > 0 || e.ValorTerreno > 0).ToList();

            return response;
        }
    }
}
