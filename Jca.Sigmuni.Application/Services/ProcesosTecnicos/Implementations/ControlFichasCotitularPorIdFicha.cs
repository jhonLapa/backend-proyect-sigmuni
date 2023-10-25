using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CotitularesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public partial class ControlFichaService
    {
        private async Task<List<ControlFichaDto>> ControlFichasCotitularPorIdFicha(int idDinamicaFicha, int idEstaticaFicha)
        {
            List<ControlFichaDto> controlFichas = new List<ControlFichaDto>();
            string NombreFicha = "Cotitular";
            string NombreTab = "";

            var responseDimamica = await _fichaService.FindFichaCotitularByIdAsync(idDinamicaFicha);
            if (responseDimamica == null) throw new Exception("No se encontro la ficha cotitular dinamica");
            var dinamica = responseDimamica;
            var responseIndividualDinamica = await _fichaService.FichaIndividualPorIdAsync(responseDimamica.Ficha.IdFichaPadre ?? 0);
            if (responseIndividualDinamica == null) throw new Exception("No se encontro la ficha individual dinamica");

            var responseEstatica = await _fichaService.FindFichaCotitularByIdAsync(idEstaticaFicha);
            if (responseEstatica == null) throw new Exception("No se encontro la ficha cotitular estatica");
            var estatica = responseEstatica;
            var responseIndividualEstatica = await _fichaService.FichaIndividualPorIdAsync(responseEstatica.Ficha.IdFichaPadre ?? 0);
            if (responseIndividualEstatica == null) throw new Exception("No se encontro la ficha individual estatica");

            #region "Datos del cotitular catastral"
            NombreTab = "Datos del cotitular catastral";

            var cotitularesEstatica = estatica.Cotitulares;
            var cotitularesDinamica = dinamica.Cotitulares;

            int countCotitularesEstatica = cotitularesEstatica?.Count ?? 0;
            int countCotitularesDinamica = cotitularesDinamica?.Count ?? 0;

            for (int i = 0; i < countCotitularesEstatica; i++)
            {
                var cotitularEstatica = cotitularesEstatica[i];
                CotitularCatastralDto cotitularDinamica = null;

                if (i < countCotitularesDinamica) cotitularDinamica = cotitularesDinamica[i];
                if (cotitularEstatica?.Titular?.TipoPersona?.Id != cotitularDinamica?.Titular?.TipoPersona?.Id)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO TITULAR [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.TipoPersona?.Descripcion ?? "",
                        ValorActual = cotitularDinamica?.Titular?.TipoPersona?.Descripcion ?? "",
                    });
                }

                if (cotitularEstatica?.Titular?.NumeroDni != cotitularDinamica?.Titular?.NumeroDni)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Nº DOC [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.NumeroDni ?? "",
                        ValorActual = cotitularDinamica?.Titular?.NumeroDni ?? "",
                    });
                }

                if (cotitularEstatica?.Titular?.Paterno?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Paterno?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"APELLIDO PATERNO [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Paterno ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Paterno ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.Materno?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Materno?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"APELLIDO MATERNO [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Materno ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Materno ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.Nombre?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Nombre?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOMBRES [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Nombre ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Nombre ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.DocumentoIdentidad?.Id != cotitularDinamica?.Titular?.DocumentoIdentidad?.Id)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO DOC. IDENT [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.DocumentoIdentidad?.Descripcion ?? "",
                        ValorActual = cotitularDinamica?.Titular?.DocumentoIdentidad?.Descripcion ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.Contacto?.Correo?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Contacto?.Correo?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CORREO [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Contacto?.Correo ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Contacto?.Correo ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.Contacto?.Telefono?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Contacto?.Telefono?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TELÉFONO [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Contacto?.Telefono ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Contacto?.Telefono ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.Contacto?.Anexo?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Contacto?.Anexo?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ANEXO [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Contacto?.Anexo ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Contacto?.Anexo ?? "",
                    });
                }
                if (cotitularEstatica?.Titular?.Contacto?.Fax?.Trim()?.ToUpper() != cotitularDinamica?.Titular?.Contacto?.Fax?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FAX [{i + 1}]",
                        ValorAnterior = cotitularEstatica?.Titular?.Contacto?.Fax ?? "",
                        ValorActual = cotitularDinamica?.Titular?.Contacto?.Fax ?? "",
                    });
                }
                

                var domicilioEstatica = cotitularEstatica.DomicilioTitular;
                var domicilioDinamica = cotitularDinamica.DomicilioTitular;

                if (domicilioEstatica?.Ubigeo?.Codigo != domicilioDinamica?.Ubigeo?.Codigo)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CÓD. DIST. [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Ubigeo?.CodigoParcial ?? "",
                        ValorActual = domicilioDinamica?.Ubigeo?.CodigoParcial ?? "",
                    });
                }
                if (domicilioEstatica?.Ubigeo?.Codigo != domicilioDinamica?.Ubigeo?.Codigo)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"DISTRITO [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Ubigeo?.Nombre ?? "",
                        ValorActual = domicilioDinamica?.Ubigeo?.Nombre ?? "",
                    });
                }
                if (domicilioEstatica?.Via?.IdVia != domicilioDinamica?.Via?.IdVia)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CÓD. VÍA. [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Via?.CodVia ?? "",
                        ValorActual = domicilioDinamica?.Via?.CodVia ?? "",
                    });
                }
                if (domicilioEstatica?.Via?.TipoVia?.IdTipoVia != domicilioDinamica?.Via?.TipoVia?.IdTipoVia)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO VÍA [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Via?.TipoVia?.Descripcion ?? "",
                        ValorActual = domicilioDinamica?.Via?.TipoVia?.Descripcion ?? "",
                    });
                }
                if (domicilioEstatica?.Via?.IdVia != domicilioDinamica?.Via?.IdVia)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOMBRE DE LA VÍA [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Via?.Nombre ?? "",
                        ValorActual = domicilioDinamica?.Via?.Nombre ?? "",
                    });
                }
                if (domicilioEstatica?.NumMunicipal != domicilioDinamica?.NumMunicipal)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Nº MUNICIPAL [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.NumMunicipal ?? "",
                        ValorActual = domicilioDinamica?.NumMunicipal ?? "",
                    });
                }
                
                if (domicilioEstatica?.NumeroInterior != domicilioDinamica?.NumeroInterior)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Nº INTERIOR [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.NumeroInterior ?? "",
                        ValorActual = domicilioDinamica?.NumeroInterior ?? "",
                    });
                }
                
                if (domicilioEstatica?.Edificacion?.Nombre != domicilioDinamica?.Edificacion?.Nombre)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOMBRE DE EDIF [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Edificacion?.Nombre ?? "",
                        ValorActual = domicilioDinamica?.Edificacion?.Nombre ?? "",
                    });
                }
                if (domicilioEstatica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana?.Trim().ToUpper() != domicilioDinamica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana?.Trim().ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CÓD. HU. [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana ?? "",
                        ValorActual = domicilioDinamica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana ?? "",
                    });
                }
                if (domicilioEstatica?.HabilitacionesUrbanas?.Nombre?.Trim().ToUpper() != domicilioDinamica?.HabilitacionesUrbanas?.Nombre?.Trim().ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOMBRE HU [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.HabilitacionesUrbanas?.Nombre ?? "",
                        ValorActual = domicilioDinamica?.HabilitacionesUrbanas?.Nombre ?? "",
                    });
                }
                if (domicilioEstatica?.Edificacion?.TipoAgrupacion?.IdTipoAgrupacion != domicilioDinamica?.Edificacion?.TipoAgrupacion?.IdTipoAgrupacion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ZONA/SECTOR/ETAPA [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Edificacion?.TipoAgrupacion?.Descripcion ?? "",
                        ValorActual = domicilioDinamica?.Edificacion?.TipoAgrupacion?.Descripcion ?? "",
                    });
                }
                if (domicilioEstatica?.Edificacion?.Manzana?.Trim() != domicilioDinamica?.Edificacion?.Manzana?.Trim())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MANZANA [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Edificacion?.Manzana ?? "",
                        ValorActual = domicilioDinamica?.Edificacion?.Manzana ?? "",
                    });
                }
                if (domicilioEstatica?.Edificacion?.LoteUrbano?.Trim() != domicilioDinamica?.Edificacion?.LoteUrbano?.Trim())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"LOTE [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Edificacion?.LoteUrbano ?? "",
                        ValorActual = domicilioDinamica?.Edificacion?.LoteUrbano ?? "",
                    });
                }
                if (domicilioEstatica?.Edificacion?.SubLote?.Trim() != domicilioDinamica?.Edificacion?.SubLote?.Trim())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"SUB-LOTE [{i + 1}]",
                        ValorAnterior = domicilioEstatica?.Edificacion?.SubLote ?? "",
                        ValorActual = domicilioDinamica?.Edificacion?.SubLote ?? "",
                    });
                }
            }

            #endregion

            #region "Información complementaria"
            NombreTab = "Información complementaria";

            var infoDeclaranteEstatica = estatica.DeclaranteInfo;
            var infoDeclaranteDinamica = dinamica.DeclaranteInfo;

            var infoComplementariaEstatica = estatica.InfoComplementario;
            var infoComplementariaDinamica = dinamica.InfoComplementario;

            if (infoDeclaranteEstatica?.CondicionPer?.IdCondicionPer != infoDeclaranteDinamica?.CondicionPer?.IdCondicionPer)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COND. DE DECLARANTE",
                    ValorAnterior = infoDeclaranteEstatica?.CondicionPer?.Nombre ?? "",
                    ValorActual = infoDeclaranteDinamica?.CondicionPer?.Nombre ?? "",
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
                    NombreCampo = "ESTADO DE LLENADO DE LA FICHA-REPORTE",
                    ValorAnterior = infoComplementariaEstatica?.EstadoLLenado?.Descripcion ?? "",
                    ValorActual = infoComplementariaDinamica?.EstadoLLenado?.Descripcion ?? "",
                });
            }

            #endregion

            #region "Observación"
            NombreTab = "Observación";

            if (infoComplementariaEstatica?.Observaciones?.Trim()?.ToUpper() != infoComplementariaDinamica?.Observaciones?.Trim()?.ToUpper())
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
