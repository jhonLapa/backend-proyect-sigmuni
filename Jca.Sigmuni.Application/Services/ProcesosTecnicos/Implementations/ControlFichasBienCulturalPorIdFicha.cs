using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public partial class ControlFichaService
    {
        private async Task<List<ControlFichaDto>> ControlFichasBienCulturalPorIdFicha(int idDinamicaFicha, int idEstaticaFicha)
        {


            List<ControlFichaDto> controlFichas = new List<ControlFichaDto>();

            const string NombreFicha = "Cultural";
            string NombreTab = "";
            var responseDinamica = await _fichaService.FindFichaBienCulturalByIdAsync(idDinamicaFicha);
            if (responseDinamica == null) throw new Exception("No se encontro la ficha bien cuntural dinamica");
            var dinamica = responseDinamica;
           
            var responseEstatica = await _fichaService.FindFichaBienCulturalByIdAsync(idEstaticaFicha);
            if (responseEstatica == null) throw new Exception("No se encontro la ficha bien cultural estatica");
            var estatico = responseEstatica;
           

            #region "Monumento Arqueológico Prehispánicos"


            var monumentoPreispanicoEstatico = estatico.MonumentoPrehispanico;
            var monumentoPreispanicoDinamico = dinamica.MonumentoPrehispanico;

            var registrosPredioMonumentoPreEstatico = estatico.RegistroPrediosMonumentoPre;
            var registrosPredioMonumentoPreDinanimica = dinamica.RegistroPrediosMonumentoPre;

            var normasLegalMonumentoPreEstatico = estatico.NormaInteresMonPreinspanico;
            var normasLegalMonumentoPreDinamico = estatico.NormaInteresMonPreinspanico;

            var countRegistroPredioMonumentoPreEstatico = registrosPredioMonumentoPreEstatico?.Count ?? 0;
            var countRegistroPredioMonumentoPreDinamico = registrosPredioMonumentoPreDinanimica?.Count ?? 0;

            //var countNormasLegalMonumentoPreEstatico = normasLegalMonumentoPreEstatico?.Count ?? 0;
            //var countNormasLegalMonumentoPreDinamico = normasLegalMonumentoPreDinamico?.Count ?? 0;

            NombreTab = "Monumento Arqueológico Prehispánicos";

            #region "Descripcion del bien cultural"
            if (monumentoPreispanicoEstatico?.CategoriaInmueble?.IdCategoriaInmueble != monumentoPreispanicoDinamico?.CategoriaInmueble?.IdCategoriaInmueble)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CATEGORÍA DEL INMUEBLE",
                    ValorAnterior = monumentoPreispanicoEstatico?.CategoriaInmueble?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.CategoriaInmueble?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (monumentoPreispanicoEstatico?.Nombre?.Trim()?.ToUpper() != monumentoPreispanicoDinamico?.Nombre?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE DEL MONUMENTO",
                    ValorAnterior = monumentoPreispanicoEstatico?.Nombre ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (monumentoPreispanicoEstatico?.Codigo?.Trim()?.ToUpper() != monumentoPreispanicoDinamico?.Codigo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = " CÓDIGO DEL MONUMENTO",
                    ValorAnterior = monumentoPreispanicoEstatico?.Codigo ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.Codigo ?? "",
                    EsConforme = false,
                });
            }
         
            if (monumentoPreispanicoEstatico?.UnidadMedida?.IdUnidadMedida != monumentoPreispanicoDinamico?.UnidadMedida?.IdUnidadMedida)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA (UNIDAD DE MEDIDA)",
                    ValorAnterior = monumentoPreispanicoEstatico?.UnidadMedida?.Abreviatura ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.UnidadMedida?.Abreviatura ?? "",
                    EsConforme = false,
                });
            }
           
            if (monumentoPreispanicoEstatico?.Area != monumentoPreispanicoDinamico?.Area)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA",
                    ValorAnterior = monumentoPreispanicoEstatico?.Area.ToString() ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.Area.ToString() ?? "",
                    EsConforme = false,
                });
            }
            
            if (monumentoPreispanicoEstatico?.Perimetro != monumentoPreispanicoDinamico?.Perimetro)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PERÍMETRO (ML)",
                    ValorAnterior = monumentoPreispanicoEstatico?.Perimetro.ToString() ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.Perimetro.ToString() ?? "",
                    EsConforme = false,
                });
            }
           
            if (monumentoPreispanicoEstatico?.FiliacionCronologica?.IdFiliacionCronologica != monumentoPreispanicoDinamico?.FiliacionCronologica?.IdFiliacionCronologica)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    EsConforme = false,
                });
            }

            #endregion

            #region "Condicion fisicas del documento arqueologico"

            if (monumentoPreispanicoEstatico?.PresenciaArquitectura?.Trim()?.ToUpper() != monumentoPreispanicoDinamico?.PresenciaArquitectura?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PRESENCIA DE ARQUITECTURA",
                    ValorAnterior = monumentoPreispanicoEstatico?.PresenciaArquitectura ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.PresenciaArquitectura ?? "",
                    EsConforme = false,
                });
            }
            if (monumentoPreispanicoEstatico?.TipoArquitectura?.IdTipoArquitecturas != monumentoPreispanicoDinamico?.TipoArquitectura?.IdTipoArquitecturas)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DE ARQUITECTURA",
                    ValorAnterior = monumentoPreispanicoEstatico?.TipoArquitectura?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.TipoArquitectura?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (monumentoPreispanicoEstatico?.TipoMaterial?.IdTipoMaterial != monumentoPreispanicoDinamico?.TipoMaterial?.IdTipoMaterial)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DE MATERIAL CONSTRUCTIVO",
                    ValorAnterior = monumentoPreispanicoEstatico?.TipoMaterial?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.TipoMaterial?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Estado conservacion"

            if (monumentoPreispanicoEstatico?.AfectacionNatural?.IdAfectacionNatural != monumentoPreispanicoDinamico?.AfectacionNatural?.IdAfectacionNatural)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "AFECTACIONES NATURALES",
                    ValorAnterior = monumentoPreispanicoEstatico?.AfectacionNatural?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.AfectacionNatural?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (monumentoPreispanicoEstatico?.AfectacionAntropica?.IdAfectacionAntropica != monumentoPreispanicoDinamico?.AfectacionAntropica?.IdAfectacionAntropica)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "AFECTACIONES ANTROPICAS:",
                    ValorAnterior = monumentoPreispanicoEstatico?.AfectacionAntropica?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.AfectacionAntropica?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (monumentoPreispanicoEstatico?.IntervencionConservacion?.IdIntervencionConservacion != monumentoPreispanicoDinamico?.IntervencionConservacion?.IdIntervencionConservacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "INTERVENCIONES EN CONSERVACIÓN:",
                    ValorAnterior = monumentoPreispanicoEstatico?.IntervencionConservacion?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.IntervencionConservacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Inscripcion del predio catrastal en el registro de predios"
            if(registrosPredioMonumentoPreEstatico?.Count>0 && registrosPredioMonumentoPreEstatico != null) { 

            for (int i = 0; i < countRegistroPredioMonumentoPreEstatico; i++)
            {
                var registroPredioMonumentoPreEstatico = registrosPredioMonumentoPreEstatico[i];
                SunarpDto registroPredioMonumentoPreDinaminca = null;

                if (i < countRegistroPredioMonumentoPreDinamico && registrosPredioMonumentoPreDinanimica?.Count > 0 && registrosPredioMonumentoPreDinanimica != null) { 
                        registroPredioMonumentoPreDinaminca = registrosPredioMonumentoPreDinanimica[i];
                    }
                if (registroPredioMonumentoPreEstatico?.TipoPartidaRegistral?.IdTipoPartidaRegistral != registroPredioMonumentoPreDinaminca?.TipoPartidaRegistral?.IdTipoPartidaRegistral)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha?.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO DE PART. REG [{i + 1}]",
                        ValorAnterior = registroPredioMonumentoPreEstatico?.TipoPartidaRegistral?.Descripcion ?? "",
                        ValorActual = registroPredioMonumentoPreDinaminca?.TipoPartidaRegistral?.Descripcion ?? "",
                        EsConforme = false,
                    });
                }

                if (registroPredioMonumentoPreEstatico?.NumeroPartida?.Trim()?.ToUpper() != registroPredioMonumentoPreDinaminca?.NumeroPartida?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha?.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NÚMERO [{i + 1}]",
                        ValorAnterior = registroPredioMonumentoPreEstatico?.NumeroPartida ?? "",
                        ValorActual = registroPredioMonumentoPreDinaminca?.NumeroPartida ?? "",
                        EsConforme = false,
                    });
                }

                if (registroPredioMonumentoPreEstatico?.Fojas?.Trim()?.ToUpper() != registroPredioMonumentoPreDinaminca?.Fojas?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha?.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FOJAS [{i + 1}]",
                        ValorAnterior = registroPredioMonumentoPreEstatico?.Fojas ?? "",
                        ValorActual = registroPredioMonumentoPreDinaminca?.Fojas ?? "",
                        EsConforme = false,
                    });
                }
                if (registroPredioMonumentoPreEstatico?.AsientoFabrica?.Trim()?.ToUpper() != registroPredioMonumentoPreDinaminca?.Fojas?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha?.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ASIENTO [{i + 1}]",
                        ValorAnterior = registroPredioMonumentoPreEstatico?.AsientoFabrica ?? "",
                        ValorActual = registroPredioMonumentoPreDinaminca?.AsientoFabrica ?? "",
                        EsConforme = false,
                    });
                }

                if (registroPredioMonumentoPreEstatico?.FechaInscripcion != registroPredioMonumentoPreDinaminca?.FechaInscripcion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha?.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA DE INSCRIPCIÓN [{i + 1}]",
                        ValorAnterior = registroPredioMonumentoPreEstatico?.FechaInscripcion?.ToShortDateString() ?? "",
                        ValorActual = registroPredioMonumentoPreDinaminca?.FechaInscripcion?.ToShortDateString() ?? "",
                        EsConforme = false,
                    });
                }

                if (registroPredioMonumentoPreEstatico?.TipoTituloInscrito?.IdTipoTituloInscrito != registroPredioMonumentoPreDinaminca?.TipoTituloInscrito?.IdTipoTituloInscrito)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha?.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO DE TÍTULO INSCRITO [{i + 1}]",
                        ValorAnterior = registroPredioMonumentoPreEstatico?.TipoTituloInscrito?.Descripcion ?? "",
                        ValorActual = registroPredioMonumentoPreDinaminca?.TipoTituloInscrito?.Descripcion ?? "",
                        EsConforme = false,
                    });
                }

            }
            }
            #endregion

            #region "Norma Legal"
            //for (int i = 0; i < countNormasLegalMonumentoPreEstatico; i++)
            //{
            //    var normaLegalMonumentalPreEstatico = normasLegalMonumentoPreEstatico[i];
            //    NormaIntMonPrehiDto normaLegalMonumentalPreDinamica = null;

            //    if (i < countNormasLegalMonumentoPreDinamico) normaLegalMonumentalPreDinamica = normasLegalMonumentoPreDinamico[i];

            //    if (normaLegalMonumentalPreEstatico?.NormaInteres?.NormaDiaDetalle?.Nombre?.Trim()?.ToUpper() != normaLegalMonumentalPreDinamica?.NormaInteres?.NormaDiaDetalle?.Nombre?.Trim().ToUpper())
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"NORMA [{i + 1}]",
            //            ValorAnterior = normaLegalMonumentalPreEstatico?.NormaInteres?.NormaDiaDetalle?.Nombre ?? "",
            //            ValorActual = normaLegalMonumentalPreDinamica?.NormaInteres?.NormaDiaDetalle?.Nombre ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonumentalPreEstatico?.NormaInteres?.NormaDiaDetalle?.Sumilla?.Trim()?.ToUpper() != normaLegalMonumentalPreDinamica?.NormaInteres?.NormaDiaDetalle?.Nombre?.Trim().ToUpper())
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"RESUMEN [{i + 1}]",
            //            ValorAnterior = normaLegalMonumentalPreEstatico?.NormaInteres?.NormaDiaDetalle?.Sumilla ?? "",
            //            ValorActual = normaLegalMonumentalPreDinamica?.NormaInteres?.NormaDiaDetalle?.Sumilla ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonumentalPreEstatico?.NormaInteres?.Naturaleza?.Id != normaLegalMonumentalPreDinamica?.NormaInteres?.Naturaleza?.Id)
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"NATURALEZA [{i + 1}]",
            //            ValorAnterior = normaLegalMonumentalPreEstatico?.NormaInteres?.Naturaleza?.Descripcion ?? "",
            //            ValorActual = normaLegalMonumentalPreDinamica?.NormaInteres?.Naturaleza?.Descripcion ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonumentalPreEstatico?.NormaInteres?.IdClasificacion != normaLegalMonumentalPreDinamica?.NormaInteres?.IdClasificacion)
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"CLASIFICACIÓN [{i + 1}]",
            //            ValorAnterior = normaLegalMonumentalPreEstatico?.NormaInteres?.Clasificacion?.Descripcion ?? "",
            //            ValorActual = normaLegalMonumentalPreDinamica?.NormaInteres?.Clasificacion?.Descripcion ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonumentalPreEstatico?.NormaInteres?.NormaDiaDetalle?.FechaPublicacionCadena != normaLegalMonumentalPreDinamica?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena)
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"F. PUBLICACIÓN [{i + 1}]",
            //            ValorAnterior = normaLegalMonumentalPreEstatico?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena ?? "",
            //            ValorActual = normaLegalMonumentalPreDinamica?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena ?? "",
            //            EsConforme = false,
            //        });
            //    }

            //}

            #endregion


            #region "Observaciones"
            if (monumentoPreispanicoEstatico?.Observacion?.IdObservacion != monumentoPreispanicoDinamico?.Observacion?.IdObservacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DE OBSERVACIÓN",
                    ValorAnterior = monumentoPreispanicoEstatico?.Observacion?.Descripcion ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.Observacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (monumentoPreispanicoEstatico?.ObservacionOtros?.Trim()?.ToUpper() != monumentoPreispanicoDinamico?.ObservacionOtros?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "OBSERVACION OTROS",
                    ValorAnterior = monumentoPreispanicoEstatico?.ObservacionOtros ?? "",
                    ValorActual = monumentoPreispanicoDinamico?.ObservacionOtros ?? "",
                    EsConforme = false,
                });
            }
            #endregion



            #endregion

            #region "Monumento Historico Colonial / Republicano"

            NombreTab = "Monumento Historico Colonial / Republicano";
            var infoBasicaEstatica = estatico.InfoMonumentoColonial;
            var inforBasicaDinamica = dinamica.InfoMonumentoColonial;

            var personaEstatica = estatico.Titular;
            var personaDinanmica = dinamica.Titular;
            var declaranteEstatica = estatico.DeclaranteInfo;
            var declaranteDinanmica = dinamica.DeclaranteInfo;

            var normasLegalMonColonialEstatico = estatico.NormaInteresMonColonial;
            var normasLegalMonColonialDinamico = estatico.NormaInteresMonColonial;
            //var countNormasLegalMonColonialEstatico = normasLegalMonColonialEstatico?.Count ?? 0;
            //var countNormasLegalMonColonialDinamico = normasLegalMonColonialDinamico?.Count ?? 0;


            #region "INFORMACIÓN BASICA"
            if (infoBasicaEstatica?.PatrimonioCultural?.Trim()?.ToUpper() != inforBasicaDinamica?.PatrimonioCultural?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                     IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "INMUEBLE DECLARADO PATRIMONIO CULTURAL DE LA NACIÓN",
                    ValorAnterior = infoBasicaEstatica?.PatrimonioCultural ?? "",
                    ValorActual = inforBasicaDinamica?.PatrimonioCultural ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.Denominacion?.Trim()?.ToUpper() != inforBasicaDinamica?.Denominacion?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                     IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE O DENOMINACIÓN",
                    ValorAnterior = infoBasicaEstatica?.Denominacion ?? "",
                    ValorActual = inforBasicaDinamica?.Denominacion ?? "",
                    EsConforme = false,
                });
            }
            if (personaEstatica?.TipoPersona?.Id != personaDinanmica?.TipoPersona?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO TITULAR",
                    ValorAnterior = personaEstatica?.TipoPersona?.Descripcion ?? "",
                    ValorActual = personaDinanmica?.TipoPersona?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            #endregion

            #region "Identificacion del titular"

            // if (personaEstatica?.EstadoCivil?.Id != personaDinanmica?.EstadoCivil?.Id)
            // {
            //     controlFichas.Add(new ControlFichaDto()
            //     {
            //         IdFicha = dinamica.Ficha?.IdFicha,
            //         IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //         NombreFicha = NombreFicha,
            //         NombreTab = NombreTab,
            //         NombreCampo = "ESTADO CIVIL",
            //         ValorAnterior = personaEstatica?.EstadoCivil?.Descripcion ?? "",
            //         ValorActual = personaDinanmica?.EstadoCivil?.Descripcion ?? "",
            //         EsConforme = false,
            //     });
            // }
            // if (personaEstatica?.DocumentoIdentidad?.Id != personaDinanmica?.DocumentoIdentidad?.Id)
            // {
            //     controlFichas.Add(new ControlFichaDto()
            //     {
            //         IdFicha = dinamica.Ficha?.IdFicha,
            //         IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //         NombreFicha = NombreFicha,
            //         NombreTab = NombreTab,
            //         NombreCampo = "TIPO DOC. IDENT",
            //         ValorAnterior = personaEstatica?.DocumentoIdentidad?.Descripcion ?? "",
            //         ValorActual = personaDinanmica?.DocumentoIdentidad?.Descripcion ?? "",
            //         EsConforme = false,
            //     });
            // }
            // if (personaEstatica?.Contacto?.Correo?.Trim()?.ToUpper() != personaDinanmica?.Contacto?.Correo?.Trim()?.ToUpper())
            // {
            //     controlFichas.Add(new ControlFichaDto()
            //     {
            //         IdFicha = dinamica.Ficha?.IdFicha,
            //         IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //         NombreFicha = NombreFicha,
            //         NombreTab = NombreTab,
            //         NombreCampo = "CORREO ELECTRÓNICO",
            //         ValorAnterior = personaEstatica?.Contacto?.Correo ?? "",
            //         ValorActual = personaDinanmica?.Contacto?.Correo ?? "",
            //         EsConforme = false,
            //     });
            // }
            // if (personaEstatica?.Contacto?.Telefono?.Trim()?.ToUpper() != personaDinanmica?.Contacto?.Telefono?.Trim()?.ToUpper())
            // {
            //     controlFichas.Add(new ControlFichaDto()
            //     {
            //         IdFicha = dinamica.Ficha?.IdFicha,
            //         IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //         NombreFicha = NombreFicha,
            //         NombreTab = NombreTab,
            //         NombreCampo = "TELÉF.",
            //         ValorAnterior = personaEstatica?.Contacto?.Telefono ?? "",
            //         ValorActual = personaDinanmica?.Contacto?.Telefono ?? "",
            //         EsConforme = false,
            //     });
            // }
            // if (personaEstatica?.Contacto?.Anexo?.Trim()?.ToUpper() != personaDinanmica?.Contacto?.Telefono?.Trim()?.ToUpper())
            // {
            //     controlFichas.Add(new ControlFichaDto()
            //     {
            //         IdFicha = dinamica.Ficha?.IdFicha,
            //         IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //         NombreFicha = NombreFicha,
            //         NombreTab = NombreTab,
            //         NombreCampo = "ANEXO",
            //         ValorAnterior = personaEstatica?.Contacto?.Anexo ?? "",
            //         ValorActual = personaDinanmica?.Contacto?.Anexo ?? "",
            //         EsConforme = false,
            //     });
            // }

            #endregion

            #region "DESCRIPCIÓN DEL MONUMENTO INTEGRANTE DEL PATROMINIO CULTURAL DE LA NACIÓN"


            if (infoBasicaEstatica?.TipoArquitectura?.IdTipoArquitecturas != inforBasicaDinamica?.TipoArquitectura?.IdTipoArquitecturas)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DE ARQUITECTURA",
                    ValorAnterior = infoBasicaEstatica?.TipoArquitectura?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.TipoArquitectura?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.UsoOrginalPredio?.IdUsoPredio != inforBasicaDinamica?.UsoOrginalPredio?.IdUsoPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CÓDIGO DE USO ORIGINAL",
                    ValorAnterior = infoBasicaEstatica?.UsoPredio?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.UsoPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.UsoPredio?.IdUsoPredio != inforBasicaDinamica?.UsoPredio?.IdUsoPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "USO ORIGINAL(DESCRIPCIÓN)",
                    ValorAnterior = infoBasicaEstatica?.UsoPredio?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.UsoPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.NumeroPisoCifra?.Trim()?.ToUpper() != inforBasicaDinamica?.NumeroPisoCifra?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NUMEROS DE PISOS(CIFRAS)",
                    ValorAnterior = infoBasicaEstatica?.NumeroPisoCifra ?? "",
                    ValorActual = inforBasicaDinamica?.NumeroPisoCifra ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.NumeroPisoLiteral?.Trim()?.ToUpper() != inforBasicaDinamica?.NumeroPisoLiteral?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = " N° DE PISOS(LITERAL)",
                    ValorAnterior = infoBasicaEstatica?.NumeroPisoLiteral ?? "",
                    ValorActual = inforBasicaDinamica?.NumeroPisoLiteral ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.TiempoConstruccion?.IdTiempoConstruccion != inforBasicaDinamica?.TiempoConstruccion?.IdTiempoConstruccion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIEMPO DE CONSTRUCCIÓN",
                    ValorAnterior = infoBasicaEstatica?.TiempoConstruccion?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.TiempoConstruccion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.FechaConstruccion != inforBasicaDinamica?.FechaConstruccion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA DE CONSTRUCCIÓN",
                    ValorAnterior = infoBasicaEstatica?.FechaConstruccion ?? "",
                    ValorActual = inforBasicaDinamica?.FechaConstruccion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.AreaLibre != inforBasicaDinamica?.AreaLibre)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA LIBRE(M2)",
                    ValorAnterior = infoBasicaEstatica?.AreaLibre.ToString() ?? "",
                    ValorActual = inforBasicaDinamica?.AreaLibre.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.ElementoArquitectonico?.IdElementoArquitectonico != inforBasicaDinamica?.ElementoArquitectonico?.IdElementoArquitectonico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "IDENTIFICACIÓN DE ELEMENTOS ARQUITECTONICOS",
                    ValorAnterior = infoBasicaEstatica?.ElementoArquitectonico?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.ElementoArquitectonico?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.DescripcionFachada?.Trim()?.ToUpper() != inforBasicaDinamica?.DescripcionFachada?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "DESCRIPCIÓN DE LA FACHADA",
                    ValorAnterior = infoBasicaEstatica?.DescripcionFachada ?? "",
                    ValorActual = inforBasicaDinamica?.DescripcionFachada ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.DescripcionInterior?.Trim()?.ToUpper() != inforBasicaDinamica?.DescripcionInterior?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "DESCRIPCIÓN DEL INTERIOR",
                    ValorAnterior = infoBasicaEstatica?.DescripcionInterior ?? "",
                    ValorActual = inforBasicaDinamica?.DescripcionInterior ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.FiliacionEstilistica?.IdFiliacionEstilistica != inforBasicaDinamica?.ElementoArquitectonico?.IdElementoArquitectonico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FILIACIÓN ESTILISTICA",
                    ValorAnterior = infoBasicaEstatica?.FiliacionEstilistica?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.FiliacionEstilistica?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Estado de elementos estructurales y acabados"


            if (infoBasicaEstatica?.EstadoCimiento?.IdEstadoAcabado != inforBasicaDinamica?.EstadoCimiento?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CIMIENTOS",
                    ValorAnterior = infoBasicaEstatica?.EstadoCimiento?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoCimiento?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoMuro?.IdEstadoAcabado != inforBasicaDinamica?.EstadoMuro?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MUROS",
                    ValorAnterior = infoBasicaEstatica?.EstadoMuro?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoMuro?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoPiso?.IdEstadoAcabado != inforBasicaDinamica?.EstadoPiso?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PISOS",
                    ValorAnterior = infoBasicaEstatica?.EstadoPiso?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoPiso?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoTecho?.IdEstadoAcabado != inforBasicaDinamica?.EstadoTecho?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TECHOS",
                    ValorAnterior = infoBasicaEstatica?.EstadoTecho?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoTecho?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoPilastra?.IdEstadoAcabado != inforBasicaDinamica?.EstadoPilastra?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PILASTRAS",
                    ValorAnterior = infoBasicaEstatica?.EstadoPilastra?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoPilastra?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoRevestimiento?.IdEstadoAcabado != inforBasicaDinamica?.EstadoRevestimiento?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "REVESTIMIENTOS",
                    ValorAnterior = infoBasicaEstatica?.EstadoRevestimiento?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoRevestimiento?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoBalcon?.IdEstadoAcabado != inforBasicaDinamica?.EstadoBalcon?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "BALCONES",
                    ValorAnterior = infoBasicaEstatica?.EstadoBalcon?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoBalcon?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoPuerta?.IdEstadoAcabado != inforBasicaDinamica?.EstadoPuerta?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PUERTAS",
                    ValorAnterior = infoBasicaEstatica?.EstadoPuerta?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoPuerta?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoVentana?.IdEstadoAcabado != inforBasicaDinamica?.EstadoVentana?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "VENTANAS",
                    ValorAnterior = infoBasicaEstatica?.EstadoVentana?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoVentana?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoReja?.IdEstadoAcabado != inforBasicaDinamica?.EstadoReja?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "REJAS",
                    ValorAnterior = infoBasicaEstatica?.EstadoReja?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoReja?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.EstadoOtro?.IdEstadoAcabado != inforBasicaDinamica?.EstadoOtro?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "OTROS",
                    ValorAnterior = infoBasicaEstatica?.EstadoOtro?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoOtro?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.IntervencionInmueble?.IdIntervencionInmueble != inforBasicaDinamica?.IntervencionInmueble?.IdIntervencionInmueble)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "INTERVENCIONES EN EL INMUEBLE",
                    ValorAnterior = infoBasicaEstatica?.IntervencionInmueble?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.IntervencionInmueble?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.ReseniaHistorica?.Trim()?.ToUpper() != inforBasicaDinamica?.ReseniaHistorica?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "RESEÑA HISTÓRICA",
                    ValorAnterior = infoBasicaEstatica?.ReseniaHistorica ?? "",
                    ValorActual = inforBasicaDinamica?.ReseniaHistorica ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Condicion Declarante"
            if (declaranteEstatica?.CondicionPer?.IdCondicionPer != declaranteDinanmica?.CondicionPer?.IdCondicionPer)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CONDICIÓN DE DECLARANTE",
                    ValorAnterior = declaranteEstatica?.CondicionPer?.Nombre ?? "",
                    ValorActual = declaranteDinanmica?.CondicionPer?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Norma"          
            //for (int i = 0; i < countNormasLegalMonColonialEstatico; i++)
            //{
            //    var normaLegalMonColonialEstatico = normasLegalMonColonialEstatico[i];
            //    NormaIntMonPreinsDto normaLegalMonColonialDinamico = null;

            //    if (i < countNormasLegalMonColonialDinamico) normaLegalMonColonialDinamico = normasLegalMonumentoPreDinamico[i];

            //    if (normaLegalMonColonialEstatico?.NormaInteres?.NormaDiaDetalle?.Nombre?.Trim()?.ToUpper() != normaLegalMonColonialDinamico?.NormaInteres?.NormaDiaDetalle?.Nombre?.Trim().ToUpper())
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"NORMA [{i + 1}]",
            //            ValorAnterior = normaLegalMonColonialEstatico?.NormaInteres?.NormaDiaDetalle?.Nombre ?? "",
            //            ValorActual = normaLegalMonColonialDinamico?.NormaInteres?.NormaDiaDetalle?.Nombre ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonColonialEstatico?.NormaInteres?.NormaDiaDetalle?.Sumilla?.Trim()?.ToUpper() != normaLegalMonColonialDinamico?.NormaInteres?.NormaDiaDetalle?.Nombre?.Trim().ToUpper())
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"RESUMEN [{i + 1}]",
            //            ValorAnterior = normaLegalMonColonialEstatico?.NormaInteres?.NormaDiaDetalle?.Sumilla ?? "",
            //            ValorActual = normaLegalMonColonialDinamico?.NormaInteres?.NormaDiaDetalle?.Sumilla ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonColonialEstatico?.NormaInteres?.Naturaleza?.Id != normaLegalMonColonialDinamico?.NormaInteres?.Naturaleza?.Id)
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"NATURALEZA [{i + 1}]",
            //            ValorAnterior = normaLegalMonColonialEstatico?.NormaInteres?.Naturaleza?.Descripcion ?? "",
            //            ValorActual = normaLegalMonColonialDinamico?.NormaInteres?.Naturaleza?.Descripcion ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonColonialEstatico?.NormaInteres?.Clasificacion?.Id != normaLegalMonColonialDinamico?.NormaInteres?.Clasificacion?.Id)
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"CLASIFICACIÓN [{i + 1}]",
            //            ValorAnterior = normaLegalMonColonialEstatico?.NormaInteres?.Clasificacion?.Descripcion ?? "",
            //            ValorActual = normaLegalMonColonialDinamico?.NormaInteres?.Clasificacion?.Descripcion ?? "",
            //            EsConforme = false,
            //        });
            //    }
            //    if (normaLegalMonColonialEstatico?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena != normaLegalMonColonialDinamico?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena)
            //    {
            //        controlFichas.Add(new ControlFichaDto()
            //        {
            //            IdFicha = dinamica.Ficha?.IdFicha,
            //            IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
            //            NombreFicha = NombreFicha,
            //            NombreTab = NombreTab,
            //            NombreCampo = $"F. PUBLICACIÓN [{i + 1}]",
            //            ValorAnterior = normaLegalMonColonialEstatico?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena ?? "",
            //            ValorActual = normaLegalMonColonialDinamico?.NormaInteres?.NormaDiaDetalle?.NormaDia?.FechaPublicacionCadena ?? "",
            //            EsConforme = false,
            //        });
            //    }

            //}

            #endregion

            #region "Estado de llenado de la ficha"


            if (infoBasicaEstatica?.EstadoLlenado?.IdEstadoAcabado != inforBasicaDinamica?.EstadoLlenado?.IdEstadoAcabado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ESTADO DE LLENADO DE LA FICHA",
                    ValorAnterior = infoBasicaEstatica?.EstadoLlenado?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.EstadoLlenado?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Observaciones"

            if (infoBasicaEstatica?.Observacion?.IdObservacion != inforBasicaDinamica?.Observacion?.IdObservacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DE OBSERVACIÓN",
                    ValorAnterior = infoBasicaEstatica?.Observacion?.Descripcion ?? "",
                    ValorActual = inforBasicaDinamica?.Observacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (infoBasicaEstatica?.ObservacionOtros?.Trim()?.ToUpper() != inforBasicaDinamica?.ObservacionOtros?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha?.IdFicha,
                    IdUnidadCatastral =  dinamica.Ficha?.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "OBSERVACIÓN",
                    ValorAnterior = infoBasicaEstatica?.ObservacionOtros ?? "",
                    ValorActual = inforBasicaDinamica?.ObservacionOtros ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #endregion


            return controlFichas;
        }
    }
}
