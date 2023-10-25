using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapBienComunComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionBienComunes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionEdificios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public partial class ControlFichaService
    {
        private async Task<List<ControlFichaDto>> ControlFichasBienComunPorIdFicha(int idDinamicaFicha, int idEstaticaFicha)
        {
            List<ControlFichaDto> controlFichas = new List<ControlFichaDto>();
            string NombreFicha = "Bien Comun";
            string NombreTab = "";

            var responseDimamica = await _fichaService.FichaBienComunPorIdAsync(idDinamicaFicha);
            if (responseDimamica == null) throw new Exception("No se encontro la ficha de bien comun dinamica");
            var dinamica = responseDimamica;

            var responseEstatica = await _fichaService.FichaBienComunPorIdAsync(idEstaticaFicha);
            if (responseEstatica == null) throw new Exception("No se encontro la ficha de bien comun estatica");
            var estatica = responseEstatica;

            #region "Ubicación del Bien Común"
            NombreTab = "Ubicación del Bien Común";
            var puertasEstatica = estatica.Puertas;
            var puertasDinamica = dinamica.Puertas;
            var edificacionEstatica = estatica.Edificacion;
            var edificacionDinamica = dinamica.Edificacion;
            var ubicacionEstatica = estatica.Ubicacion;
            var ubicacionDinamica = dinamica.Ubicacion;

            int countPuertasEstatica = puertasEstatica?.Count ?? 0;
            int countPuertasDinamica = puertasDinamica?.Count ?? 0;
            for (int i = 0; i < countPuertasEstatica; i++)
            {
                var puertaEstatica = puertasEstatica[i];
                PuertaDto puertaDinamica = null;

                if (i < countPuertasDinamica) puertaDinamica = puertasDinamica[i];

                if (puertaEstatica?.Via?.IdVia != puertaDinamica?.Via?.IdVia)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CÓDIGO DE VÍA [{i + 1}]",
                        ValorAnterior = puertaEstatica?.Via?.CodVia ?? "",
                        ValorActual = puertaDinamica?.Via?.CodVia ?? "",
                    });
                }

                if (puertaEstatica?.Via?.TipoVia?.Descripcion?.Trim().ToUpper() != puertaDinamica?.Via?.TipoVia?.Descripcion?.Trim().ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO VÍA [{i + 1}]",
                        ValorAnterior = puertaEstatica?.Via?.TipoVia?.Codigo ?? "",
                        ValorActual = puertaDinamica?.Via?.TipoVia?.Codigo ?? "",
                    });
                }

                if (puertaEstatica?.Via?.IdVia != puertaDinamica?.Via?.IdVia)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOMBRE DE VÍA [{i + 1}]",
                        ValorAnterior = puertaEstatica?.Via?.Nombre ?? "",
                        ValorActual = puertaDinamica?.Via?.Nombre ?? "",
                    });
                }

                if (puertaEstatica?.TipoPuerta?.IdTipoPuerta != puertaDinamica?.TipoPuerta?.IdTipoPuerta)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO PUERTA [{i + 1}]",
                        ValorAnterior = puertaEstatica?.TipoPuerta?.Descripcion ?? "",
                        ValorActual = puertaDinamica?.TipoPuerta?.Descripcion ?? "",
                    });
                }

                if (puertaEstatica?.NumeracionMunicipal != puertaDinamica.NumeracionMunicipal)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"N° MUNICIPAL [{i + 1}]",
                        ValorAnterior = puertaEstatica?.NumeracionMunicipal ?? "",
                        ValorActual = puertaDinamica?.NumeracionMunicipal ?? "",
                    });
                }

                //if (puertaEstatica?.LtPrincipal != puertaDinamica?.LtPrincipal)
                //{
                //    controlFichas.Add(new ControlFichaDto()
                //    {
                //        IdFicha = dinamica.Ficha.IdFicha,
                //        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                //        NombreFicha = NombreFicha,
                //        NombreTab = NombreTab,
                //        NombreCampo = $"LT - MUNICIAPL [{i + 1}]",
                //        ValorAnterior = puertaEstatica?.LtPrincipal ?? "",
                //        ValorActual = puertaDinamica?.LtPrincipal ?? "",
                //    });
                //}
                //if (puertaEstatica?.UbicacionNumeracion?.Id != puertaDinamica?.UbicacionNumeracion?.Id)
                //{
                //    controlFichas.Add(new ControlFichaDto()
                //    {
                //        IdFicha = dinamica.Ficha.IdFicha,
                //        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                //        NombreFicha = NombreFicha,
                //        NombreTab = NombreTab,
                //        NombreCampo = $"UB [{i + 1}]",
                //        ValorAnterior = puertaEstatica?.UbicacionNumeracion?.Descripcion ?? "",
                //        ValorActual = puertaDinamica?.UbicacionNumeracion?.Descripcion ?? "",
                //    });
                //}
                if (puertaEstatica?.CondicionNumeracion?.IdCondicionNumeracion != puertaDinamica?.CondicionNumeracion?.IdCondicionNumeracion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"COND NUM EXTERIOR [{i + 1}]",
                        ValorAnterior = puertaEstatica?.CondicionNumeracion?.Descripcion ?? "",
                        ValorActual = puertaDinamica?.CondicionNumeracion?.Descripcion ?? "",
                    });
                }
                if (puertaEstatica?.NumCertifPrincipal != puertaDinamica?.NumCertifPrincipal)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Nº CERTIF. EXTERIOR [{i + 1}]",
                        ValorAnterior = puertaEstatica?.NumCertifPrincipal ?? "",
                        ValorActual = puertaDinamica?.NumCertifPrincipal ?? "",
                    });
                }
            }

            if (edificacionEstatica?.TipoEdificacion?.IdTipoEdificacion != edificacionDinamica?.TipoEdificacion?.IdTipoEdificacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DE EDIF",
                    ValorAnterior = edificacionEstatica?.TipoEdificacion?.Descripcion ?? "",
                    ValorActual = edificacionDinamica?.TipoEdificacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (edificacionEstatica?.Nombre?.Trim()?.ToUpper() != edificacionDinamica?.Nombre?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE DE EDIF",
                    ValorAnterior = edificacionEstatica?.Nombre ?? "",
                    ValorActual = edificacionDinamica?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            
            if (ubicacionEstatica?.HabilitacionUrbana?.IdHabilitacionUrbana != ubicacionDinamica?.HabilitacionUrbana?.IdHabilitacionUrbana)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CÓDIGO HU",
                    ValorAnterior = ubicacionEstatica?.HabilitacionUrbana?.CodigoHabilitacioUrbana ?? "",
                    ValorActual = ubicacionDinamica?.HabilitacionUrbana?.CodigoHabilitacioUrbana ?? "",
                    EsConforme = false,
                });
            }
            if (ubicacionEstatica?.HabilitacionUrbana?.TipoHabilitacionUrbana?.Descripcion?.Trim().ToUpper() != ubicacionDinamica?.HabilitacionUrbana?.TipoHabilitacionUrbana?.Descripcion?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO HABILITACIÓN URBANA",
                    ValorAnterior = ubicacionEstatica?.HabilitacionUrbana?.TipoHabilitacionUrbana?.Descripcion ?? "",
                    ValorActual = ubicacionDinamica?.HabilitacionUrbana?.TipoHabilitacionUrbana?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (ubicacionEstatica?.HabilitacionUrbana?.IdHabilitacionUrbana != ubicacionDinamica?.HabilitacionUrbana?.IdHabilitacionUrbana)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE HU",
                    ValorAnterior = ubicacionEstatica?.HabilitacionUrbana?.Nombre ?? "",
                    ValorActual = ubicacionDinamica?.HabilitacionUrbana?.Nombre ?? "",
                    EsConforme = false,
                });
            }

            if (edificacionEstatica?.TipoAgrupacion?.IdTipoAgrupacion != edificacionDinamica?.TipoAgrupacion?.IdTipoAgrupacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ZONA/SECTOR/ETAPA",
                    ValorAnterior = edificacionEstatica?.TipoAgrupacion?.Descripcion ?? "",
                    ValorActual = edificacionDinamica?.TipoAgrupacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }


            if (edificacionEstatica?.Manzana?.Trim()?.ToUpper() != edificacionDinamica?.Manzana?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MANZANA",
                    ValorAnterior = edificacionEstatica?.Manzana ?? "",
                    ValorActual = edificacionDinamica?.Manzana ?? "",
                    EsConforme = false,
                });
            }
            if (edificacionEstatica?.LoteUrbano?.Trim()?.ToUpper() != edificacionDinamica?.LoteUrbano?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "LOTE",
                    ValorAnterior = edificacionEstatica?.LoteUrbano ?? "",
                    ValorActual = edificacionDinamica?.LoteUrbano ?? "",
                    EsConforme = false,
                });
            }
            if (edificacionEstatica?.SubLote?.Trim()?.ToUpper() != edificacionDinamica?.SubLote?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "SUB-LOTES",
                    ValorAnterior = edificacionEstatica?.SubLote ?? "",
                    ValorActual = edificacionDinamica?.SubLote ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Descripción Bien Común"
            NombreTab = "Descripción Bien Común";

            var descripcionBCEstatica = estatica.DescripcionPredio;
            var descripcionBCDinamica = dinamica.DescripcionPredio;

            if (descripcionBCEstatica?.ClasificacionPredio?.IdClasificacionPredio != descripcionBCDinamica?.ClasificacionPredio?.IdClasificacionPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CLASIFICACIÓN DEL PREDIO",
                    ValorAnterior = descripcionBCEstatica?.ClasificacionPredio?.Descripcion ?? "",
                    ValorActual = descripcionBCDinamica?.ClasificacionPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.PredioCatastralEn?.IdPredioCatastralEn != descripcionBCDinamica?.PredioCatastralEn?.IdPredioCatastralEn)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PREDIO CATASTRAL EN.",
                    ValorAnterior = descripcionBCEstatica?.PredioCatastralEn?.Descripcion ?? "",
                    ValorActual = descripcionBCDinamica?.PredioCatastralEn?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.UsoPredio?.IdUsoPredio != descripcionBCDinamica?.UsoPredio?.IdUsoPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CÓDIGO DE USO",
                    ValorAnterior = descripcionBCEstatica?.UsoPredio?.Codigo ?? "",
                    ValorActual = descripcionBCDinamica?.UsoPredio?.Codigo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.UsoPredio?.IdUsoPredio != descripcionBCDinamica?.UsoPredio?.IdUsoPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "USO DEL PREDIO CATASTRAL",
                    ValorAnterior = descripcionBCEstatica?.UsoPredio?.Descripcion ?? "",
                    ValorActual = descripcionBCDinamica?.UsoPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.Estructuracion != descripcionBCDinamica?.Estructuracion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "USO DEL PREDIO CATASTRAL",
                    ValorAnterior = descripcionBCEstatica?.UsoPredio?.Descripcion ?? "",
                    ValorActual = descripcionBCDinamica?.UsoPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.AreaTitulo != descripcionBCDinamica?.AreaTitulo)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA DE TERRENO SEGÚN TÍTULO (M2)",
                    ValorAnterior = descripcionBCEstatica?.AreaTitulo?.ToString() ?? "",
                    ValorActual = descripcionBCDinamica?.AreaTitulo?.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.AreaVerificada != descripcionBCDinamica?.AreaVerificada)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA DE TERRENO VERIFICADA (M2)",
                    ValorAnterior = descripcionBCEstatica?.AreaVerificada?.ToString() ?? "",
                    ValorActual = descripcionBCDinamica?.AreaVerificada?.ToString() ?? "",
                    EsConforme = false,
                });
            }

            if (descripcionBCEstatica?.LinderoPredio?.MedidaFrenteCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaFrenteCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-FRENTE",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaFrenteCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaFrenteCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaFrenteTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaFrenteTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-FRENTE",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaFrenteTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaFrenteTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaFrenteCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaFrenteCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-FRENTE",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaFrenteCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaFrenteCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaFrenteTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaFrenteTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-FRENTE",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaFrenteTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaFrenteTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaDerechaCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaDerechaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-DERECHA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaDerechaCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaDerechaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaDerechaTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaDerechaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-DERECHA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaDerechaTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaDerechaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaDerechaCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaDerechaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-DERECHA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaDerechaCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaDerechaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaDerechaTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaDerechaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-DERECHA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaDerechaTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaDerechaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaIzquierdaCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaIzquierdaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-IZQUIERDA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaIzquierdaCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaIzquierdaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaIzquierdaTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaIzquierdaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-IZQUIERDA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaIzquierdaTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaIzquierdaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaIzquierdaCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaIzquierdaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-IZQUIERDA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaIzquierdaCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaIzquierdaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaIzquierdaTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaIzquierdaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-IZQUIERDA",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaIzquierdaTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaIzquierdaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaFondoCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaFondoCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-FONDO",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaFondoCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaFondoCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.MedidaFondoTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.MedidaFondoTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-FONDO",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.MedidaFondoTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.MedidaFondoTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaFondoCampo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaFondoCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-FONDO",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaFondoCampo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaFondoCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripcionBCEstatica?.LinderoPredio?.ColindaFondoTitulo?.Trim()?.ToUpper() != descripcionBCDinamica?.LinderoPredio?.ColindaFondoTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-FONDO",
                    ValorAnterior = descripcionBCEstatica?.LinderoPredio?.ColindaFondoTitulo ?? "",
                    ValorActual = descripcionBCDinamica?.LinderoPredio?.ColindaFondoTitulo ?? "",
                    EsConforme = false,
                });
            }
            #endregion
            
            #region "Servicios Básicos Comunes"
            NombreTab = "Servicios Básicos Comunes";

            var serviciosBCEstatica = estatica.ServicioBasico;
            var serviciosBCDinamica = dinamica.ServicioBasico;

            if (serviciosBCEstatica?.Luz?.IdTipoServicioBasico != serviciosBCDinamica?.Luz?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "LUZ",
                    ValorAnterior = serviciosBCEstatica?.Luz?.Descripcion ?? "",
                    ValorActual = serviciosBCDinamica?.Luz?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (serviciosBCEstatica?.SuministroLuz != serviciosBCDinamica?.SuministroLuz)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° SUM LUZ",
                    ValorAnterior = serviciosBCEstatica?.SuministroLuz ?? "",
                    ValorActual = serviciosBCDinamica?.SuministroLuz ?? "",
                    EsConforme = false,
                });
            }
            if (serviciosBCEstatica?.Agua?.IdTipoServicioBasico != serviciosBCDinamica?.Agua?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "AGUA",
                    ValorAnterior = serviciosBCEstatica?.Agua?.Descripcion ?? "",
                    ValorActual = serviciosBCDinamica?.Agua?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (serviciosBCEstatica?.NumContratoAgua != serviciosBCDinamica?.NumContratoAgua)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° CONTRATO DE AGUA",
                    ValorAnterior = serviciosBCEstatica?.NumContratoAgua ?? "",
                    ValorActual = serviciosBCDinamica?.NumContratoAgua ?? "",
                    EsConforme = false,
                });
            }
            if (serviciosBCEstatica?.Desague?.IdTipoServicioBasico != serviciosBCDinamica?.Desague?.IdTipoServicioBasico  )
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "DESAGÜE",
                    ValorAnterior = serviciosBCEstatica?.Desague?.Descripcion ?? "",
                    ValorActual = serviciosBCDinamica?.Desague?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (serviciosBCEstatica?.Telefono?.IdTipoServicioBasico != serviciosBCDinamica?.Telefono?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TELÉFONO",
                    ValorAnterior = serviciosBCEstatica?.Telefono?.Descripcion ?? "",
                    ValorActual = serviciosBCDinamica?.Telefono?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (serviciosBCEstatica?.NumTelefono != serviciosBCDinamica?.NumTelefono)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° TELEFONO",
                    ValorAnterior = serviciosBCEstatica?.NumTelefono ?? "",
                    ValorActual = serviciosBCDinamica?.NumTelefono ?? "",
                    EsConforme = false,
                });
            }

            #endregion

            #region "Construcciones Comunes"
            NombreTab = "Construcciones Comunes";

            var construccionesBCEstatica = estatica.Construcciones;
            var construccionesBCDinamica = dinamica.Construcciones;

            int countConstruccionesEstatica = construccionesBCEstatica?.Count ?? 0;
            int countConstruccionesDinamica = construccionesBCDinamica?.Count ?? 0;
            for (int i = 0; i < countConstruccionesEstatica; i++)
            {
                var construccionEstatica = construccionesBCEstatica[i];
                ConstruccionDto construccionDinamica = null;

                if (i < countConstruccionesDinamica) construccionDinamica = construccionesBCDinamica[i];

                if (construccionEstatica?.NumeroPiso != construccionDinamica?.NumeroPiso)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"N. PISO SÓTANO MEZZ [{i + 1}]",
                        ValorAnterior = construccionEstatica?.NumeroPiso ?? "",
                        ValorActual = construccionDinamica?.NumeroPiso ?? "",
                    });
                }
                if (construccionEstatica?.MesAnio?.Month != construccionDinamica?.MesAnio?.Month)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MES [{i + 1}]",
                        ValorAnterior = construccionEstatica?.MesAnio?.Month.ToString() ?? "",
                        ValorActual = construccionDinamica?.MesAnio?.Month.ToString() ?? "",
                    });
                }
                if (construccionEstatica?.MesAnio?.Year != construccionDinamica?.MesAnio?.Year)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"AÑO [{i + 1}]",
                        ValorAnterior = construccionEstatica?.MesAnio?.Year.ToString() ?? "",
                        ValorActual = construccionDinamica?.MesAnio?.Year.ToString() ?? "",
                    });
                }
                if (construccionEstatica?.Mep?.IdMep != construccionDinamica?.Mep?.IdMep)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MEP [{i + 1}]",
                        ValorAnterior = construccionEstatica?.Mep?.Descripcion ?? "",
                        ValorActual = construccionDinamica?.Mep?.Descripcion ?? "",
                    });
                }
                if (construccionEstatica?.Ecs?.IdEcs != construccionDinamica?.Ecs?.IdEcs)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ECS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.Ecs?.Descripcion ?? "",
                        ValorActual = construccionDinamica?.Ecs?.Descripcion ?? "",
                    });
                }
                if (construccionEstatica?.Ecc?.IdEcc != construccionDinamica?.Ecc?.IdEcc)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ECC [{i + 1}]",
                        ValorAnterior = construccionEstatica?.Ecc?.Descripcion ?? "",
                        ValorActual = construccionDinamica?.Ecc?.Descripcion ?? "",
                    });
                }
                if (construccionEstatica?.EstructuraMuroColumna != construccionDinamica?.EstructuraMuroColumna)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MUROS Y COLUMNAS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.EstructuraMuroColumna ?? "",
                        ValorActual = construccionDinamica?.EstructuraMuroColumna ?? "",
                    });
                }
                if (construccionEstatica?.EstructuraTecho != construccionDinamica?.EstructuraTecho)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TECHOS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.EstructuraTecho ?? "",
                        ValorActual = construccionDinamica?.EstructuraTecho ?? "",
                    });
                }
                if (construccionEstatica?.AcabadoPiso != construccionDinamica?.AcabadoPiso)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"PISOS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.AcabadoPiso ?? "",
                        ValorActual = construccionDinamica?.AcabadoPiso ?? "",
                    });
                }
                if (construccionEstatica?.AcabadoPuertaVentana != construccionDinamica?.AcabadoPuertaVentana)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"PUERTAS Y VENTANAS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.AcabadoPuertaVentana ?? "",
                        ValorActual = construccionDinamica?.AcabadoPuertaVentana ?? "",
                    });
                }
                if (construccionEstatica?.AcabadoRevestimiento != construccionDinamica?.AcabadoRevestimiento)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"REVEST. [{i + 1}]",
                        ValorAnterior = construccionEstatica?.AcabadoRevestimiento ?? "",
                        ValorActual = construccionDinamica?.AcabadoRevestimiento ?? "",
                    });
                }
                if (construccionEstatica?.AcabadoBanio != construccionDinamica?.AcabadoBanio)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"BAÑOS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.AcabadoBanio ?? "",
                        ValorActual = construccionDinamica?.AcabadoBanio ?? "",
                    });
                }
                if (construccionEstatica?.InstalacionElectricaSanitaria != construccionDinamica?.InstalacionElectricaSanitaria)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"INST ELÉCTRICAS SANITARIAS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.InstalacionElectricaSanitaria ?? "",
                        ValorActual = construccionDinamica?.InstalacionElectricaSanitaria ?? "",
                    });
                }
                if (construccionEstatica?.AreaTechadaDeclarada != construccionDinamica?.AreaTechadaDeclarada)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"INST ELÉCTRICAS SANITARIAS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.AreaTechadaDeclarada.ToString() ?? "",
                        ValorActual = construccionDinamica?.AreaTechadaDeclarada.ToString() ?? "",
                    });
                }
                if (construccionEstatica?.AreaVerificada != construccionDinamica?.AreaVerificada)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"INST ELÉCTRICAS SANITARIAS [{i + 1}]",
                        ValorAnterior = construccionEstatica?.AreaVerificada.ToString() ?? "",
                        ValorActual = construccionDinamica?.AreaVerificada.ToString() ?? "",
                    });
                }
                if (construccionEstatica?.Uca?.IdUca != construccionDinamica?.Uca?.IdUca)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"U.C.A. [{i + 1}]",
                        ValorAnterior = construccionEstatica?.Uca?.Descripcion ?? "",
                        ValorActual = construccionDinamica?.Uca?.Descripcion ?? "",
                    });
                }
            }


            #endregion

            #region "Obra Complementaria e Instalaciones Fijas y Permanentes"
            NombreTab = "Obra Complementaria e Instalaciones Fijas y Permanentes";

            var oInstalacionesEstatica = estatica.OtraInstalaciones;
            var oInstalacionesDinamica = dinamica.OtraInstalaciones;

            int countInstalacionesEstatica = oInstalacionesEstatica?.Count ?? 0;
            int countInstalacionesDinamica = oInstalacionesDinamica?.Count ?? 0;
            for (int i = 0; i < countInstalacionesEstatica; i++)
            {
                var instalacionEstatica = oInstalacionesEstatica[i];
                OtraInstalacionDto instalacionDinamica = null;

                if (i < countInstalacionesDinamica) instalacionDinamica = oInstalacionesDinamica[i];

                if (instalacionEstatica?.TipoOtraInstalacion?.IdTipoOtraInstalacion != instalacionDinamica?.TipoOtraInstalacion?.IdTipoOtraInstalacion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"DESCRIPCION [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.TipoOtraInstalacion?.Nombre ?? "",
                        ValorActual = instalacionDinamica?.TipoOtraInstalacion?.Nombre ?? "",
                    });
                }
                if (instalacionEstatica?.MesAnio?.Month != instalacionDinamica?.MesAnio?.Month)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MES [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.MesAnio?.Month.ToString() ?? "",
                        ValorActual = instalacionDinamica?.MesAnio?.Month.ToString() ?? "",
                    });
                }
                if (instalacionEstatica?.MesAnio?.Year != instalacionDinamica?.MesAnio?.Year)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"AÑO [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.MesAnio?.Year.ToString() ?? "",
                        ValorActual = instalacionDinamica?.MesAnio?.Year.ToString() ?? "",
                    });
                }
                if (instalacionEstatica?.Mep?.IdMep != instalacionDinamica?.Mep?.IdMep)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MEP [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Mep?.Descripcion ?? "",
                        ValorActual = instalacionDinamica?.Mep?.Descripcion ?? "",
                    });
                }
                if (instalacionEstatica?.Ecs?.IdEcs != instalacionDinamica?.Ecs?.IdEcs)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ECS [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Ecs?.Descripcion ?? "",
                        ValorActual = instalacionDinamica?.Ecs?.Descripcion ?? "",
                    });
                }
                if (instalacionEstatica?.Ecc?.IdEcc != instalacionDinamica?.Ecc?.IdEcc)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ECC [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Ecc?.Descripcion ?? "",
                        ValorActual = instalacionDinamica?.Ecc?.Descripcion ?? "",
                    });
                }
                if (instalacionEstatica?.Largo != instalacionDinamica?.Largo)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CANT [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Largo?.ToString() ?? "",
                        ValorActual = instalacionDinamica?.Largo?.ToString() ?? "",
                    });
                }
                if (instalacionEstatica?.Ancho != instalacionDinamica?.Ancho)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CANT [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Ancho?.ToString() ?? "",
                        ValorActual = instalacionDinamica?.Ancho?.ToString() ?? "",
                    });
                }
                if (instalacionEstatica?.Alto != instalacionDinamica?.Alto)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CANT [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Alto?.ToString() ?? "",
                        ValorActual = instalacionDinamica?.Alto?.ToString() ?? "",
                    });
                }
                if (instalacionEstatica?.ProductoTotal != instalacionDinamica?.ProductoTotal)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"PRODUCTO TOTAL [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.ProductoTotal?.ToString() ?? "",
                        ValorActual = instalacionDinamica?.ProductoTotal?.ToString() ?? "",
                    });
                }
                if (instalacionEstatica?.Uca?.IdUca != instalacionDinamica?.Uca?.IdUca)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"U.C.A. [{i + 1}]",
                        ValorAnterior = instalacionEstatica?.Uca?.Descripcion ?? "",
                        ValorActual = instalacionDinamica?.Uca?.Descripcion ?? "",
                    });
                }
            }

            #endregion

            #region "Recapitulación de Edificios"
            NombreTab = "Recapitulación de Edificios";

            var recapEdificioEstatica = estatica.RecapEdificios;
            var recapEdificioDinamica = dinamica.RecapEdificios;
            //var recapEdificioEstatica = estatica.are;
            //var recapEdificioDinamica = dinamica.RecapEdificios;

            int countRecapEdificioEstatica = recapEdificioEstatica?.Count ?? 0;
            int countRecapEdificioDinamica = recapEdificioDinamica?.Count ?? 0;
            for (int i = 0; i < countRecapEdificioEstatica; i++)
            {
                var edificioEstatica = recapEdificioEstatica[i];
                RecapitulacionEdificioDto edificioDinamica = null;

                if (i < countRecapEdificioDinamica) edificioDinamica = recapEdificioDinamica[i];

                if (edificioEstatica?.Edificio?.Trim().ToUpper() != edificioDinamica?.Edificio?.Trim().ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"EDIFICIO [{i + 1}]",
                        ValorAnterior = edificioEstatica?.Edificio ?? "",
                        ValorActual = edificioDinamica?.Edificio ?? "",
                    });
                }
                if (edificioEstatica?.TotalPorcentaje?.ToString() != edificioDinamica?.TotalPorcentaje?.ToString())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"PORCENTAJE LEGAL(%) [{i + 1}]",
                        ValorAnterior = edificioEstatica?.TotalPorcentaje?.ToString() ?? "",
                        ValorActual = edificioDinamica?.TotalPorcentaje?.ToString() ?? "",
                    });
                }
                if (edificioEstatica?.TotalAcc != edificioDinamica?.TotalAcc)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ACC (M2) [{i + 1}]",
                        ValorAnterior = edificioEstatica?.TotalAcc.ToString() ?? "",
                        ValorActual = edificioDinamica?.TotalAcc.ToString() ?? "",
                    });
                }
                if (edificioEstatica?.TotalAtc != edificioDinamica?.TotalAtc)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ATC (M2) [{i + 1}]",
                        ValorAnterior = edificioEstatica?.TotalAtc?.ToString() ?? "",
                        ValorActual = edificioDinamica?.TotalAtc?.ToString() ?? "",
                    });
                }
                if (edificioEstatica?.TotalAoic != edificioDinamica?.TotalAoic)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"AOIC (M2) [{i + 1}]",
                        ValorAnterior = edificioEstatica?.TotalAoic?.ToString() ?? "",
                        ValorActual = edificioDinamica?.TotalAoic?.ToString() ?? "",
                    });
                }
            }

            var recapBCEstatica = estatica.RecapBienComunComplemetarios;
            var recapBCDinamica = dinamica.RecapBienComunComplemetarios;

            int countRecapEdificioBCEstatica = recapBCEstatica?.Count ?? 0;
            int countRecapEdificioBCDinamica = recapBCDinamica?.Count ?? 0;
            for (int i = 0; i < countRecapEdificioBCEstatica; i++)
            {
                var rBCEstatica = recapBCEstatica[i];
                RecapBienComunComplementarioDto rBCDinamica = null;

                if (i < countRecapEdificioBCDinamica) rBCDinamica = recapBCDinamica[i];

                if (rBCEstatica?.AnchoPasaje?.Trim().ToUpper() != rBCDinamica?.AnchoPasaje?.Trim().ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"EDIFICIO [{i + 1}]",
                        ValorAnterior = rBCEstatica?.AnchoPasaje ?? "",
                        ValorActual = rBCDinamica?.AnchoPasaje ?? "",
                    });
                }
                if (rBCEstatica?.Distancia?.Trim()?.ToUpper() != rBCDinamica?.Distancia?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"DISTANCIA [{i + 1}]",
                        ValorAnterior = rBCEstatica?.Distancia ?? "",
                        ValorActual = rBCDinamica?.Distancia ?? "",
                    });
                }
            }
            #endregion

            #region "Recapitulación de Bienes Comunes"
            NombreTab = "Recapitulación de Bienes Comunes";

            var recapBienesComunesEstatica = estatica.RecapBienComunes;
            var recapBienesComunesDinamica = dinamica.RecapBienComunes;

            int countRecapBienesComunesEstatica = recapBienesComunesEstatica?.Count ?? 0;
            int countRecapBienesComunesDinamica = recapBienesComunesDinamica?.Count ?? 0;


            for (int i = 0; i < countRecapBienesComunesEstatica; i++)
            {
                var recapBienComunEstatica = recapBienesComunesEstatica[i];
                RecapitulacionBienComunDto recapBienComunDinamica = null;

                if (i < countRecapBienesComunesDinamica) recapBienComunDinamica = recapBienesComunesDinamica[i];

                if (recapBienComunEstatica?.Numero?.Trim()?.ToUpper() != recapBienComunDinamica?.Numero?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"N° [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Numero?.Trim()?.ToUpper() ?? "",
                        ValorActual = recapBienComunDinamica?.Numero?.Trim()?.ToUpper() ?? "",
                    });
                }
                if (recapBienComunEstatica?.Edificacion?.Trim()?.ToUpper() != recapBienComunDinamica?.Edificacion?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ED [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Edificacion?.Trim()?.ToUpper() ?? "",
                        ValorActual = recapBienComunDinamica?.Edificacion?.Trim()?.ToUpper() ?? "",
                    });
                }
                if (recapBienComunEstatica?.Entrada?.Trim()?.ToUpper() != recapBienComunDinamica?.Entrada?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"EN [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Entrada?.Trim()?.ToUpper() ?? "",
                        ValorActual = recapBienComunDinamica?.Entrada?.Trim()?.ToUpper() ?? "",
                    });
                }
                if (recapBienComunEstatica?.Piso?.Trim()?.ToUpper() != recapBienComunDinamica?.Piso?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Piso [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Piso?.Trim()?.ToUpper() ?? "",
                        ValorActual = recapBienComunDinamica?.Piso?.Trim()?.ToUpper() ?? "",
                    });
                }
                if (recapBienComunEstatica?.Unidad?.Trim()?.ToUpper() != recapBienComunDinamica?.Unidad?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"UNIDAD [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Unidad?.Trim()?.ToUpper() ?? "",
                        ValorActual = recapBienComunDinamica?.Unidad?.Trim()?.ToUpper() ?? "",
                    });
                }

                if (recapBienComunEstatica?.Atc?.ToString()?.Trim() != recapBienComunDinamica?.Atc?.ToString()?.Trim())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ATC (M2) [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Atc?.ToString()?.Trim() ?? "",
                        ValorActual = recapBienComunDinamica?.Atc?.ToString()?.Trim() ?? "",
                    });
                }
                if (recapBienComunEstatica?.Acc?.ToString()?.Trim() != recapBienComunDinamica?.Acc?.ToString()?.Trim())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ACC (M2) [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Acc?.ToString()?.Trim() ?? "",
                        ValorActual = recapBienComunDinamica?.Acc?.ToString()?.Trim() ?? "",
                    });
                }
                if (recapBienComunEstatica?.Aoic?.ToString()?.Trim() != recapBienComunDinamica?.Aoic?.ToString()?.Trim())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"AOIC (M2) [{i + 1}]",
                        ValorAnterior = recapBienComunEstatica?.Aoic?.ToString()?.Trim() ?? "",
                        ValorActual = recapBienComunDinamica?.Aoic?.ToString()?.Trim() ?? "",
                    });
                }
            }

            #endregion

            #region "Documentos y datos registrales"
            NombreTab = "Documentos y datos registrales";

            var inscripcionesEstatica = estatica.Inscripciones;
            var inscripcionesDinamica = dinamica.Inscripciones;

            int countInscripcionesEstatica = inscripcionesEstatica?.Count ?? 0;
            int countInscripcionesDinamica = inscripcionesDinamica?.Count ?? 0;

            for (int i = 0; i < countInscripcionesEstatica; i++)
            {
                var inscripcionEstatica = inscripcionesEstatica[i];
                SunarpDto inscripcionDinamica = null;

                if (i < countInscripcionesDinamica) inscripcionDinamica = inscripcionesDinamica[i];

                if (inscripcionEstatica?.TipoPartidaRegistral?.IdTipoPartidaRegistral != inscripcionDinamica?.TipoPartidaRegistral?.IdTipoPartidaRegistral)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO DE PARTIDA REGISTRAL [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.TipoPartidaRegistral?.Descripcion ?? "",
                        ValorActual = inscripcionDinamica?.TipoPartidaRegistral?.Descripcion ?? "",
                    });
                }
                if (inscripcionEstatica?.NumeroPartida != inscripcionDinamica?.NumeroPartida)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NÚMERO [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.NumeroPartida ?? "",
                        ValorActual = inscripcionDinamica?.NumeroPartida ?? "",
                    });
                }
                if (inscripcionEstatica?.Fojas != inscripcionDinamica?.Fojas)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FOJAS [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.Fojas ?? "",
                        ValorActual = inscripcionDinamica?.Fojas ?? "",
                    });
                }
                if (inscripcionEstatica?.Asiento != inscripcionDinamica?.Asiento)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ASIENTO [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.Asiento ?? "",
                        ValorActual = inscripcionDinamica?.Asiento ?? "",
                    });
                }
                if (inscripcionEstatica?.FechaInscripcion != inscripcionDinamica?.FechaInscripcion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA DE INSCRIPCIÓN DEL PREDIO [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.FechaInscripcion?.ToShortDateString() ?? "",
                        ValorActual = inscripcionDinamica?.FechaInscripcion?.ToShortDateString() ?? "",
                    });
                }
                if (inscripcionEstatica?.DeclaratoriaFabrica != inscripcionDinamica?.DeclaratoriaFabrica)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"DECLARATORIA DE FABRICA [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.DeclaratoriaFabrica ?? "",
                        ValorActual = inscripcionDinamica?.DeclaratoriaFabrica ?? "",
                    });
                }
                if (inscripcionEstatica?.AsientoFabrica != inscripcionDinamica?.AsientoFabrica)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"AS.INSC. DE FABRICA [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.AsientoFabrica ?? "",
                        ValorActual = inscripcionDinamica?.AsientoFabrica ?? "",
                    });
                }
                if (inscripcionEstatica?.FechaFabrica != inscripcionDinamica?.FechaFabrica)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA DE INSCRIPCIÓN PUBLICA [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.FechaFabrica?.ToShortDateString() ?? "",
                        ValorActual = inscripcionDinamica?.FechaFabrica?.ToShortDateString() ?? "",
                    });
                }
            }

            var infoLegalEstatica = estatica.InfoLegal;
            var infoLegalDinamica = dinamica.InfoLegal;

            int countInfoLegalEstatica = infoLegalEstatica?.Count ?? 0;
            int countInfoLegalDinamica = infoLegalDinamica?.Count ?? 0;

            for (int j = 0; j < countInfoLegalEstatica; j++)
            {
                var infoEstatica = infoLegalEstatica[j];
                RegistroLegalDto infoDinamica = null;

                if (j < countInfoLegalDinamica) infoDinamica = infoLegalDinamica[j];

                if (infoEstatica?.Notaria?.Trim()?.ToUpper() != infoDinamica?.Notaria?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOTARIA [{j + 1}]",
                        ValorAnterior = infoEstatica?.Notaria ?? "",
                        ValorActual = infoDinamica?.Notaria ?? "",
                    });
                }
                if (infoEstatica?.Kardex?.Trim()?.ToUpper() != infoDinamica?.Kardex?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"KARDEX [{j + 1}]",
                        ValorAnterior = infoEstatica?.Kardex ?? "",
                        ValorActual = infoDinamica?.Kardex ?? "",
                    });
                }
                if (infoEstatica?.FechaEscritura != infoDinamica?.FechaEscritura)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA DE ESCRITURA PUBLICA [{j + 1}]",
                        ValorAnterior = infoEstatica?.FechaEscritura?.ToShortDateString() ?? "",
                        ValorActual = infoDinamica?.FechaEscritura?.ToShortDateString() ?? "",
                    });
                }
            }

            #endregion

            #region "Información complementaria"
            NombreTab = "Información complementaria";

            var infoComplementariaEstatica = estatica.InfoComplementario;
            var infoComplementariaDinamica = dinamica.InfoComplementario;

            if (estatica?.DeclaranteInfo?.CondicionPer?.IdCondicionPer != dinamica?.DeclaranteInfo?.CondicionPer?.IdCondicionPer)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CONDICIÓN DEL DECLARANTE",
                    ValorAnterior = estatica?.DeclaranteInfo?.CondicionPer?.Nombre ?? "",
                    ValorActual = dinamica?.DeclaranteInfo?.CondicionPer?.Nombre ?? "",
                });
            }
            if (infoComplementariaEstatica?.EstadoLLenado?.IdEstadoLlenado != infoComplementariaDinamica?.EstadoLLenado?.IdEstadoLlenado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ESTADO LLENADO DE LA FICHA",
                    ValorAnterior = infoComplementariaEstatica?.EstadoLLenado?.Descripcion ?? "",
                    ValorActual = infoComplementariaDinamica?.EstadoLLenado?.Descripcion ?? "",
                });
            }

            #endregion

            #region "Observaciones"
            NombreTab = "Observaciones";

            if (infoComplementariaEstatica?.Observaciones != infoComplementariaDinamica?.Observaciones)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "OBSERVACIONES",
                    ValorAnterior = infoComplementariaEstatica?.Observaciones ?? "",
                    ValorActual = infoComplementariaDinamica?.Observaciones ?? "",
                });
            }

            #endregion

            return controlFichas;
        }
    }
}
