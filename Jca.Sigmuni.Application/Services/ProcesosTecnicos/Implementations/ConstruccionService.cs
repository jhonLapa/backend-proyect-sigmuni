using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
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
    public class ConstruccionService : IConstruccionService
    {
        private readonly IMapper _mapper;
        private readonly IConstruccionRepository _construccionRepository;
        private readonly IDescripcionPredioRepository _descripcionPredioRepository;
        private readonly IAntiguedadRepository _antiguedadRepository;
        private readonly ICategoriaConstruccionRepository _categoriaConstruccionRepository;
        private readonly IDepreciacionRepository _depreciacionRepository;
        private readonly IFichaRepository _fichaRepository;
        private readonly IFichaIndividualRepository _fichaIndividualRepository;
        private readonly IUnidadCatastralRepository _unidadCatastralRepository;
        private readonly IValorUnitarioRepository _valorUnitarioRepository;

        public ConstruccionService(IMapper mapper,
                                   IConstruccionRepository construccionRepository,
                                   IDescripcionPredioRepository descripcionPredioRepository,
                                   IAntiguedadRepository antiguedadRepository,
                                   ICategoriaConstruccionRepository categoriaConstruccionRepository,
                                   IDepreciacionRepository depreciacionRepository,
                                   IFichaRepository fichaRepository,
                                   IFichaIndividualRepository fichaIndividualRepository,
                                   IUnidadCatastralRepository unidadCatastralRepository,
                                   IValorUnitarioRepository valorUnitarioRepository)
        {
            _mapper = mapper;
            _construccionRepository = construccionRepository;
            _descripcionPredioRepository = descripcionPredioRepository;
            _antiguedadRepository = antiguedadRepository;
            _categoriaConstruccionRepository = categoriaConstruccionRepository;
            _depreciacionRepository = depreciacionRepository;
            _fichaRepository = fichaRepository;
            _fichaIndividualRepository = fichaIndividualRepository;
            _unidadCatastralRepository = unidadCatastralRepository;
            _valorUnitarioRepository = valorUnitarioRepository;
        }

        public async Task<long> CalcularValorizacionAsync(Ficha fichaIndividual)
        {
            var idFicha = fichaIndividual.IdFicha;
            var lista = await _construccionRepository.ListarPorIdFichaAsync(idFicha);
            var descripcionPredio = await _descripcionPredioRepository.BuscarPorIdFichaAsync(idFicha);

            for (int i = 0; i < lista.Count; i++)
            {
                var construccion = lista[i];
                var antiguedad = DateTime.UtcNow.Year - construccion.MesAnio.Value.Year;
                var entidadAntiguedad = await _antiguedadRepository.BuscarPorLimitesAsync(antiguedad);
                var idAntiguedad = entidadAntiguedad != null ? entidadAntiguedad.IdAntiguedad : 0;

                decimal muroValor = 0;
                var murosYColumnasCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.EstructuraMuroColumna);
                if (murosYColumnasCategoria != null)
                {
                    var muro = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(1, murosYColumnasCategoria.IdCategoriaConstruccion, 2022);
                    if (muro != null)
                        muroValor = muro.Valor ?? 0;
                }

                decimal techoValor = 0;
                var techoCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.EstructuraTecho);
                if (techoCategoria != null)
                {
                    var techo = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(2, techoCategoria.IdCategoriaConstruccion, 2022);
                    if (techo != null)
                        techoValor = techo.Valor ?? 0;
                }

                decimal pisoValor = 0;
                var pisoCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoPiso);
                if (pisoCategoria != null)
                {
                    var piso = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(3, pisoCategoria.IdCategoriaConstruccion, 2022);
                    if (piso != null)
                        pisoValor = piso.Valor ?? 0;
                }

                decimal puertasYVentanasValor = 0;
                var puertasYVentanasCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoPuertaVentana);
                if (puertasYVentanasCategoria != null)
                {
                    var puertasYVentanas = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(4, puertasYVentanasCategoria.IdCategoriaConstruccion, 2022);
                    if (puertasYVentanas != null)
                        puertasYVentanasValor = puertasYVentanas.Valor ?? 0;
                }

                decimal revestimientoValor = 0;
                var revestimientoCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoRevestimiento);
                if (revestimientoCategoria != null)
                {
                    var revestimiento = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(5, revestimientoCategoria.IdCategoriaConstruccion, 2022);
                    if (revestimiento != null)
                        revestimientoValor = revestimiento.Valor ?? 0;
                }

                decimal banioValor = 0;
                var banioCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoBanio);
                if (banioCategoria != null)
                {
                    var banio = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(6, banioCategoria.IdCategoriaConstruccion, 2022);
                    if (banio != null)
                        banioValor = banio.Valor ?? 0;
                }

                decimal instalacionElectricaValor = 0;
                var instalacionElectricaCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.InstalacionElectricaSanitaria);
                if (instalacionElectricaCategoria != null)
                {
                    var instalacionElectrica = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(7, instalacionElectricaCategoria.IdCategoriaConstruccion, 2022);
                    if (instalacionElectrica != null)
                        instalacionElectricaValor = instalacionElectrica.Valor ?? 0;
                }

                var valorUnitario = muroValor + techoValor + pisoValor + puertasYVentanasValor + revestimientoValor + banioValor + instalacionElectricaValor;

                var mep = construccion.Mep;
                var ecs = construccion.Ecs;

                var depreciacion = await _depreciacionRepository.BuscarPorClasificacionEstadoAntiguedad((int)descripcionPredio.ClasificacionPredio.IdClasificacionPredio, idAntiguedad, mep.IdMep, ecs.IdEcs);
                var porcentajeDepreciacion = depreciacion != null ? depreciacion.Porcentaje : 0;
                var valorDepreciado = valorUnitario - (valorUnitario * (porcentajeDepreciacion / 100));

                var valorConstruccion = valorDepreciado * construccion.AreaVerificada;

                construccion.ValorUnitario = valorUnitario;
                construccion.ValorDepreciado = valorDepreciado;
                construccion.ValorConstruccion = valorConstruccion;
                construccion.PorcentajeValorDepreciado = porcentajeDepreciacion;

                await _construccionRepository.Edit(construccion.IdConstruccion, construccion);
            }

            // ficha bien comun
            if (fichaIndividual.IdFichaPadre != null)
            {
                var listaConstrucionBC = await _construccionRepository.ListarPorIdFichaAsync((int)fichaIndividual.IdFichaPadre);

                for (int i = 0; i < listaConstrucionBC.Count; i++)
                {
                    var construccion = listaConstrucionBC[i];

                    var antiguedad = DateTime.UtcNow.Year - construccion.MesAnio.Value.Year;
                    var entidadAntiguedad = await _antiguedadRepository.BuscarPorLimitesAsync(antiguedad);
                    var idAntiguedad = entidadAntiguedad != null ? entidadAntiguedad.IdAntiguedad : 0;

                    decimal muroValor = 0;
                    var murosYColumnasCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.EstructuraMuroColumna);
                    if (murosYColumnasCategoria != null)
                    {
                        var muro = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(1, murosYColumnasCategoria.IdCategoriaConstruccion, 2022);
                        if (muro != null)
                            muroValor = muro.Valor ?? 0;
                    }

                    decimal techoValor = 0;
                    var techoCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.EstructuraTecho);
                    if (techoCategoria != null)
                    {
                        var techo = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(2, techoCategoria.IdCategoriaConstruccion, 2022);
                        if (techo != null)
                            techoValor = techo.Valor ?? 0;
                    }

                    decimal pisoValor = 0;
                    var pisoCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoPiso);
                    if (pisoCategoria != null)
                    {
                        var piso = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(3, pisoCategoria.IdCategoriaConstruccion, 2022);
                        if (piso != null)
                            pisoValor = piso.Valor ?? 0;
                    }

                    decimal puertasYVentanasValor = 0;
                    var puertasYVentanasCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoPuertaVentana);
                    if (puertasYVentanasCategoria != null)
                    {
                        var puertasYVentanas = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(4, puertasYVentanasCategoria.IdCategoriaConstruccion, 2022);
                        if (puertasYVentanas != null)
                            puertasYVentanasValor = puertasYVentanas.Valor ?? 0;
                    }

                    decimal revestimientoValor = 0;
                    var revestimientoCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoRevestimiento);
                    if (revestimientoCategoria != null)
                    {
                        var revestimiento = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(5, revestimientoCategoria.IdCategoriaConstruccion, 2022);
                        if (revestimiento != null)
                            revestimientoValor = revestimiento.Valor ?? 0;
                    }

                    decimal banioValor = 0;
                    var banioCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.AcabadoBanio);
                    if (banioCategoria != null)
                    {
                        var banio = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(6, banioCategoria.IdCategoriaConstruccion, 2022);
                        if (banio != null)
                            banioValor = banio.Valor ?? 0;
                    }

                    decimal instalacionElectricaValor = 0;
                    var instalacionElectricaCategoria = await _categoriaConstruccionRepository.ObtenerPorCodigoAsync(construccion.InstalacionElectricaSanitaria);
                    if (instalacionElectricaCategoria != null)
                    {
                        var instalacionElectrica = await _valorUnitarioRepository.BuscarPorClasificacionCategoria(7, instalacionElectricaCategoria.IdCategoriaConstruccion, 2022);
                        if (instalacionElectrica != null)
                            instalacionElectricaValor = instalacionElectrica.Valor ?? 0;
                    }

                    var valorUnitario = muroValor + techoValor + pisoValor + puertasYVentanasValor + revestimientoValor + banioValor + instalacionElectricaValor;

                    var mep = construccion.Mep;
                    var ecs = construccion.Ecs;

                    var depreciacion = await _depreciacionRepository.BuscarPorClasificacionEstadoAntiguedad((int)descripcionPredio.ClasificacionPredio.IdClasificacionPredio, idAntiguedad, mep.IdMep, ecs.IdEcs);
                    var porcentajeDepreciacion = depreciacion != null ? depreciacion.Porcentaje : 0;
                    var valorDepreciado = valorUnitario - (valorUnitario * (porcentajeDepreciacion / 100));

                    var idFichaBienComun = fichaIndividual.IdFichaPadre;
                    var recapitulacionBienComuns = await FichaBienComunIdRecapitulacionBienesComunesAsync((int)idFichaBienComun);
                    var porcentajeAreaComun = recapitulacionBienComuns.Count > 0 ? recapitulacionBienComuns[i].BcFisicoTerreno ?? 1 : 0; ////

                    var valorConstruccion = valorDepreciado * construccion.AreaVerificada * (porcentajeAreaComun / 100);

                    if (valorConstruccion != 0)
                    {
                        construccion.ValorUnitario = valorUnitario;
                        construccion.ValorDepreciado = valorDepreciado;
                        construccion.ValorConstruccion = valorConstruccion;
                        construccion.ValorAreaComun = valorConstruccion;
                        construccion.PorcentajeValorDepreciado = porcentajeDepreciacion;
                        construccion.PorcentajeAreaComun = porcentajeAreaComun;

                        await _construccionRepository.Edit(construccion.IdConstruccion, construccion);
                    }

                }
            }

            return 1;
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
                            prorrateoPisoX.BcGeneralLlegalPiso = (fichaindividualUnidad?.PorcBcGenLegal ?? 0) / itemConstruccion.AreaVerificada;
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

        public async Task<Construccion> CrearAsync(ConstruccionDto peticion)
        {
            var idMep = new int?();
            if (peticion.Mep != null)
            {
                idMep = peticion.Mep.IdMep != null ? peticion.Mep.IdMep : new int?();
            }

            var idEcs = new int?();
            if (peticion.Ecs != null)
            {
                idEcs = peticion.Ecs.IdEcs != null ? peticion.Ecs.IdEcs : new int?();
            }

            var idEcc = new int?();
            if (peticion.Ecc != null)
            {
                idEcc = peticion.Ecc.IdEcc != null ? peticion.Ecc.IdEcc : new int?();
            }

            var idUca = new int?();
            if (peticion.Uca != null)
            {
                idUca = peticion.Uca.IdUca != null ? peticion.Uca.IdUca : new int?();
            }

            var idEdificacionIndustrial = new int?();

            if (peticion.EdificacionIndustrial != null)
            {
                idEdificacionIndustrial = peticion.EdificacionIndustrial.IdEdificacionIndustrial != null ? peticion.EdificacionIndustrial.IdEdificacionIndustrial : new int?();
            }

            var construccion = new Construccion
            {
                NumeroPiso = peticion.NumeroPiso,
                EstructuraMuroColumna = peticion.EstructuraMuroColumna,
                EstructuraTecho = peticion.EstructuraTecho,
                AcabadoPiso = peticion.AcabadoPiso,
                AcabadoPuertaVentana = peticion.AcabadoPuertaVentana,
                AcabadoRevestimiento = peticion.AcabadoRevestimiento,
                AcabadoBanio = peticion.AcabadoBanio,
                InstalacionElectricaSanitaria = peticion.InstalacionElectricaSanitaria,
                AreaVerificada = peticion.AreaVerificada,
                AreaTechadaDeclarada = peticion.AreaTechadaDeclarada,
                IdMep = idMep,
                IdEcs = idEcs,
                IdEcc = idEcc,
                IdUca = idUca,
                IdEd = peticion.IdEd,
                IdEdificacionIndustrial = idEdificacionIndustrial,
                IdFicha = peticion.IdFicha,
                MesAnio = peticion.MesAnio
            };

            return await _construccionRepository.Create(construccion);
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _construccionRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _construccionRepository.EliminarAsync(item.IdConstruccion);
            }

            return response;
        }
    }
}
