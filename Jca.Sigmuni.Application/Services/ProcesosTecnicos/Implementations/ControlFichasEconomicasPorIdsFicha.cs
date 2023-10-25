using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
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
        private async Task<List<ControlFichaDto>> ControlFichasEconomicasPorIdsFicha(List<int> idsDinamicasFicha, List<int> idsEstaticasFicha)
        {
            List<ControlFichaDto> controlFichasParcial = new List<ControlFichaDto>();

            int idsFichaSize = idsDinamicasFicha.Count;

            for (int index = 0; index < idsFichaSize; index++)
            {
                var idDinamicaFicha = idsDinamicasFicha[index];
                var idEstaticaFicha = idsEstaticasFicha[index];
                string NombreFicha = $"Economica [{index + 1}]";
                string NombreTab = "";

                var responseDimamica = await _fichaService.FindFichaActividadEconomicaByIdAsync(idDinamicaFicha);
                if (responseDimamica == null) throw new Exception("No se encontro la ficha economica dinamica");
                var dimamica = responseDimamica;

                var responseEstatica = await _fichaService.FindFichaActividadEconomicaByIdAsync(idEstaticaFicha);
                if (responseEstatica == null) throw new Exception("No se encontro la ficha individual estatica");
                var estatica = responseEstatica;

                #region IDENTIFICACIÓN DEL CONDUCTOR
                NombreTab = "Identificación del conductor";
                var conductorPersonaEstatica = estatica.ConductorPersona;
                var conductorPersonaDinamica = dimamica.ConductorPersona;
                var representanteEstatica = estatica.Representante;
                var representanteDinamica = dimamica.Representante;
                var domicilioConductorEstatica = estatica.DomicilioConductor;
                var domicilioConductorDinamica = dimamica.DomicilioConductor;

                if (conductorPersonaEstatica?.TipoPersona?.Id != conductorPersonaDinamica?.TipoPersona?.Id)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "TIPO DE CONDUCTOR:",
                        ValorAnterior = conductorPersonaEstatica?.TipoPersona?.Descripcion ?? "",
                        ValorActual = conductorPersonaDinamica?.TipoPersona?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.NombreComercial?.Trim()?.ToUpper() != conductorPersonaDinamica?.NombreComercial?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "NOMBRE COMERCIAL:",
                        ValorAnterior = conductorPersonaEstatica?.NombreComercial ?? "",
                        ValorActual = conductorPersonaDinamica?.NombreComercial ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.DocumentoIdentidad?.Id != conductorPersonaDinamica?.DocumentoIdentidad?.Id)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "TIPO DOC. IDENT:",
                        ValorAnterior = conductorPersonaEstatica?.DocumentoIdentidad?.Descripcion ?? "",
                        ValorActual = conductorPersonaDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.Contacto?.Correo?.Trim()?.ToUpper() != conductorPersonaDinamica?.Contacto?.Correo?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "CORREO ELECTRÓNICO:",
                        ValorAnterior = conductorPersonaEstatica?.Contacto?.Correo ?? "",
                        ValorActual = conductorPersonaDinamica?.Contacto?.Correo ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.Contacto?.Telefono?.Trim()?.ToUpper() != conductorPersonaDinamica?.Contacto?.Telefono?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "TELÉFONO:",
                        ValorAnterior = conductorPersonaEstatica?.Contacto?.Telefono ?? "",
                        ValorActual = conductorPersonaDinamica?.Contacto?.Telefono ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.Contacto?.Anexo?.Trim()?.ToUpper() != conductorPersonaDinamica?.Contacto?.Anexo?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ANEXO:",
                        ValorAnterior = conductorPersonaEstatica?.Contacto?.Anexo ?? "",
                        ValorActual = conductorPersonaDinamica?.Contacto?.Anexo ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.CondConductor?.IdCondicionConductor != conductorPersonaDinamica?.CondConductor?.IdCondicionConductor)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "COND. CONDUCTOR:",
                        ValorAnterior = conductorPersonaEstatica?.CondConductor?.Descripcion ?? "",
                        ValorActual = conductorPersonaDinamica?.CondConductor?.Descripcion ?? "",
                        EsConforme = false
                    });
                }



                if (conductorPersonaEstatica?.NumeroDni?.Trim()?.ToUpper() != conductorPersonaDinamica?.NumeroDni?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "N° DOC:",
                        ValorAnterior = conductorPersonaEstatica?.NumeroDni ?? "",
                        ValorActual = conductorPersonaDinamica?.NumeroDni ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.NumeroRuc?.Trim()?.ToUpper() != conductorPersonaDinamica?.NumeroRuc?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "N° RUC:",
                        ValorAnterior = conductorPersonaEstatica?.NumeroRuc ?? "",
                        ValorActual = conductorPersonaDinamica?.NumeroRuc ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.Paterno?.Trim()?.ToUpper() != conductorPersonaDinamica?.Paterno?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "APELLIDO PATERNO:",
                        ValorAnterior = conductorPersonaEstatica?.Paterno ?? "",
                        ValorActual = conductorPersonaDinamica?.Paterno ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.Materno?.Trim()?.ToUpper() != conductorPersonaDinamica?.Materno?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "APELLIDO MATERNO:",
                        ValorAnterior = conductorPersonaEstatica?.Materno ?? "",
                        ValorActual = conductorPersonaDinamica?.Materno ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.Nombre?.Trim()?.ToUpper() != conductorPersonaDinamica?.Nombre?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "NOMBRES:",
                        ValorAnterior = conductorPersonaEstatica?.Nombre ?? "",
                        ValorActual = conductorPersonaDinamica?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.RazonSocial?.Trim()?.ToUpper() != conductorPersonaDinamica?.RazonSocial?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "RAZÓN SOCIAL:",
                        ValorAnterior = conductorPersonaEstatica?.RazonSocial ?? "",
                        ValorActual = conductorPersonaDinamica?.RazonSocial ?? "",
                        EsConforme = false
                    });
                }

                if (conductorPersonaEstatica?.CategoriaOrganizacion?.IdCategoriaOrganizacion != conductorPersonaDinamica?.CategoriaOrganizacion?.IdCategoriaOrganizacion)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "TIPO PERSONA JURÍDICA:",
                        ValorAnterior = conductorPersonaEstatica?.CategoriaOrganizacion?.Descripcion ?? "",
                        ValorActual = conductorPersonaDinamica?.CategoriaOrganizacion?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                // DOMICILIO DEL CONDUCTOR
                if (domicilioConductorEstatica?.Departamento?.Codigo != domicilioConductorDinamica?.Departamento?.Codigo)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "DEPARTAMENTO:",
                        ValorAnterior = domicilioConductorEstatica?.Departamento?.Nombre ?? "",
                        ValorActual = domicilioConductorDinamica?.Departamento?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Provincia?.Codigo != domicilioConductorDinamica?.Provincia?.Codigo)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "PROVINCIA:",
                        ValorAnterior = domicilioConductorEstatica?.Provincia?.Nombre ?? "",
                        ValorActual = domicilioConductorDinamica?.Provincia?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Ubigeo?.Codigo != domicilioConductorDinamica?.Ubigeo?.Codigo)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "CÓD. DIST.",
                        ValorAnterior = domicilioConductorEstatica?.Ubigeo?.CodigoParcial ?? "",
                        ValorActual = domicilioConductorDinamica?.Ubigeo?.CodigoParcial ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Ubigeo?.Codigo != domicilioConductorDinamica?.Ubigeo?.Codigo)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "DISTRITO:",
                        ValorAnterior = domicilioConductorEstatica?.Ubigeo?.Nombre ?? "",
                        ValorActual = domicilioConductorDinamica?.Ubigeo?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Via?.IdVia != domicilioConductorDinamica?.Via?.IdVia)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "CÓD. VÍA.",
                        ValorAnterior = domicilioConductorEstatica?.Via?.CodVia ?? "",
                        ValorActual = domicilioConductorDinamica?.Via?.CodVia ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Via?.TipoVia?.IdTipoVia != domicilioConductorDinamica?.Via?.TipoVia?.IdTipoVia)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "TIPO VÍA",
                        ValorAnterior = domicilioConductorEstatica?.Via?.TipoVia?.Descripcion ?? "",
                        ValorActual = domicilioConductorDinamica?.Via?.TipoVia?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Via?.IdVia != domicilioConductorDinamica?.Via?.IdVia)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "NOMBRE DE LA VÍA",
                        ValorAnterior = domicilioConductorEstatica?.Via?.Nombre ?? "",
                        ValorActual = domicilioConductorDinamica?.Via?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.NumMunicipal?.Trim()?.ToUpper() != domicilioConductorDinamica?.NumMunicipal?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "Nº MUNICIPAL",
                        ValorAnterior = domicilioConductorEstatica?.NumMunicipal ?? "",
                        ValorActual = domicilioConductorDinamica?.NumMunicipal ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.NumeroInterior?.Trim()?.ToUpper() != domicilioConductorDinamica?.NumeroInterior?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "Nº INTER",
                        ValorAnterior = domicilioConductorEstatica?.NumeroInterior ?? "",
                        ValorActual = domicilioConductorDinamica?.NumeroInterior ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Edificacion?.Nombre?.Trim()?.ToUpper() != domicilioConductorDinamica?.Edificacion?.Nombre?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "NOMBRE DE EDIF",
                        ValorAnterior = domicilioConductorEstatica?.Edificacion?.Nombre ?? "",
                        ValorActual = domicilioConductorDinamica?.Edificacion?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana?.Trim()?.ToUpper() != domicilioConductorDinamica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "CÓD. HU.",
                        ValorAnterior = domicilioConductorEstatica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana ?? "",
                        ValorActual = domicilioConductorDinamica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.HabilitacionesUrbanas?.Nombre?.Trim()?.ToUpper() != domicilioConductorDinamica?.HabilitacionesUrbanas?.Nombre?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "NOMBRE HU",
                        ValorAnterior = domicilioConductorEstatica?.HabilitacionesUrbanas?.Nombre ?? "",
                        ValorActual = domicilioConductorDinamica?.HabilitacionesUrbanas?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Edificacion?.TipoAgrupacion?.IdTipoAgrupacion != domicilioConductorDinamica?.Edificacion?.TipoAgrupacion?.IdTipoAgrupacion)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ZONA/SECTOR/ETAPA",
                        ValorAnterior = domicilioConductorEstatica?.Edificacion?.TipoAgrupacion?.Descripcion ?? "",
                        ValorActual = domicilioConductorDinamica?.Edificacion?.TipoAgrupacion?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Edificacion?.Manzana?.Trim()?.ToUpper() != domicilioConductorDinamica?.Edificacion?.Manzana?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "MANZANA",
                        ValorAnterior = domicilioConductorEstatica?.Edificacion?.Manzana ?? "",
                        ValorActual = domicilioConductorDinamica?.Edificacion?.Manzana ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Edificacion?.LoteUrbano?.Trim()?.ToUpper() != domicilioConductorDinamica?.Edificacion?.LoteUrbano?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "LOTE",
                        ValorAnterior = domicilioConductorEstatica?.Edificacion?.LoteUrbano ?? "",
                        ValorActual = domicilioConductorDinamica?.Edificacion?.LoteUrbano ?? "",
                        EsConforme = false
                    });
                }

                if (domicilioConductorEstatica?.Edificacion?.SubLote?.Trim()?.ToUpper() != domicilioConductorDinamica?.Edificacion?.SubLote?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "SUB-LOTE",
                        ValorAnterior = domicilioConductorEstatica?.Edificacion?.SubLote ?? "",
                        ValorActual = domicilioConductorDinamica?.Edificacion?.SubLote ?? "",
                        EsConforme = false
                    });
                }
                #endregion

                #region AUTORIZACIÓN MUNICIPAL
                NombreTab = "Autorización Municipal";
                var areaActEconomicaEstatica = estatica.AreaActEconomica;
                var areaActEconomicaDinamica = dimamica.AreaActEconomica;
                var arrayAutorizacionMunicipalEstatica = estatica.AutorizacionMunicipal;
                var arrayAutorizacionMunicipalDinamica = dimamica.AutorizacionMunicipal;

                int countArrayAutorizacionMunicipalEstatica = arrayAutorizacionMunicipalEstatica?.Count ?? 0;
                int countArrayAutorizacionMunicipalDinamica = arrayAutorizacionMunicipalDinamica?.Count ?? 0;

                if (areaActEconomicaEstatica?.NumLicencia?.Trim()?.ToUpper() != areaActEconomicaDinamica?.NumLicencia?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "N° DE LICENCIA:",
                        ValorAnterior = areaActEconomicaEstatica?.NumLicencia ?? "",
                        ValorActual = areaActEconomicaDinamica?.NumLicencia ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.FechaExpedicion != areaActEconomicaDinamica?.FechaExpedicion)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "FECHA DE EXPEDICIÓN:",
                        ValorAnterior = areaActEconomicaEstatica?.FechaExpedicion?.ToShortDateString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.FechaExpedicion?.ToShortDateString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.FechaVencimiento != areaActEconomicaDinamica?.FechaVencimiento)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "FECHA DE VENCIMIENTO:",
                        ValorAnterior = areaActEconomicaEstatica?.FechaVencimiento?.ToShortDateString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.FechaVencimiento?.ToShortDateString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.NumExpediente?.Trim()?.ToUpper() != areaActEconomicaDinamica?.NumExpediente?.Trim()?.ToUpper())
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "N° EXPEDIENTE:",
                        ValorAnterior = areaActEconomicaEstatica?.NumExpediente ?? "",
                        ValorActual = areaActEconomicaDinamica?.NumExpediente ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.InicioActividad != areaActEconomicaDinamica?.InicioActividad)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "FECHA INICIO DE ACTIVIDAD:",
                        ValorAnterior = areaActEconomicaEstatica?.InicioActividad?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.InicioActividad?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                // ÁREA DE LA ACTIVIDAD ECONÓMICA (M²)
                if (areaActEconomicaEstatica?.PredioCatAutorizada != areaActEconomicaDinamica?.PredioCatAutorizada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA AUTORIZADA / Predio Catastral",
                        ValorAnterior = areaActEconomicaEstatica?.PredioCatAutorizada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.PredioCatAutorizada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.ViaPubAutorizada != areaActEconomicaDinamica?.ViaPubAutorizada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA AUTORIZADA / Vía Pública",
                        ValorAnterior = areaActEconomicaEstatica?.ViaPubAutorizada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.ViaPubAutorizada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.BienComunAutorizada != areaActEconomicaDinamica?.BienComunAutorizada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA AUTORIZADA / Bien Común",
                        ValorAnterior = areaActEconomicaEstatica?.BienComunAutorizada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.BienComunAutorizada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.TotalAutorizada != areaActEconomicaDinamica?.TotalAutorizada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA AUTORIZADA / Total",
                        ValorAnterior = areaActEconomicaEstatica?.TotalAutorizada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.TotalAutorizada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.PredioCatVerificada != areaActEconomicaDinamica?.PredioCatVerificada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA VERIFICADA / Predio Catastral",
                        ValorAnterior = areaActEconomicaEstatica?.PredioCatVerificada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.PredioCatVerificada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.ViaPubVerificada != areaActEconomicaDinamica?.ViaPubVerificada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA VERIFICADA / Vía Pública",
                        ValorAnterior = areaActEconomicaEstatica?.ViaPubVerificada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.ViaPubVerificada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.BienComunVerificada != areaActEconomicaDinamica?.BienComunVerificada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA VERIFICADA / Bien Común",
                        ValorAnterior = areaActEconomicaEstatica?.BienComunVerificada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.BienComunVerificada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                if (areaActEconomicaEstatica?.TotalVerificada != areaActEconomicaDinamica?.TotalVerificada)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ÁREA VERIFICADA / Total",
                        ValorAnterior = areaActEconomicaEstatica?.TotalVerificada?.ToString() ?? "",
                        ValorActual = areaActEconomicaDinamica?.TotalVerificada?.ToString() ?? "",
                        EsConforme = false
                    });
                }

                // ÁREA DE LA ACTIVIDAD ECONÓMICA (M²)
                for (int i = 0; i < countArrayAutorizacionMunicipalEstatica; i++)
                {
                    var autorizacionMunicipalEstatica = arrayAutorizacionMunicipalEstatica[i];
                    AutorizacionMunicipalDto autorizacionMunicipalDinamica = null;

                    if (i < countArrayAutorizacionMunicipalDinamica) autorizacionMunicipalDinamica = arrayAutorizacionMunicipalDinamica[i];

                    if (autorizacionMunicipalEstatica?.ActividadVerificada?.IdActividadVerificada != autorizacionMunicipalDinamica?.ActividadVerificada?.IdActividadVerificada)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"CÓD ACT ECONÓMICA [{i + 1}]",
                            ValorAnterior = autorizacionMunicipalEstatica?.ActividadVerificada?.Codigo ?? "",
                            ValorActual = autorizacionMunicipalDinamica?.ActividadVerificada?.Codigo ?? "",
                        });
                    }

                    if (autorizacionMunicipalEstatica?.ActividadVerificada?.IdActividadVerificada != autorizacionMunicipalDinamica?.ActividadVerificada?.IdActividadVerificada)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"DESCRIPCIÓN ACT ECONÓMICA [{i + 1}]",
                            ValorAnterior = autorizacionMunicipalEstatica?.ActividadVerificada?.Descripcion ?? "",
                            ValorActual = autorizacionMunicipalDinamica?.ActividadVerificada?.Descripcion ?? "",
                        });
                    }
                }
                #endregion

                #region AUTORIZACION ANUNCIO
                NombreTab = "Autorización Anuncio";
                var arrayAutorizacionAnuncioEstatica = estatica.AutorizacionAnuncio;
                var arrayAutorizacionAnuncioDinamica = dimamica.AutorizacionAnuncio;

                int countArrayAutorizacionAnuncioEstatica = arrayAutorizacionAnuncioEstatica?.Count ?? 0;
                int countArrayAutorizacionAnuncioDinamica = arrayAutorizacionAnuncioDinamica?.Count ?? 0;

                for (int i = 0; i < countArrayAutorizacionAnuncioEstatica; i++)
                {
                    var autorizacionAnuncioEstatica = arrayAutorizacionAnuncioEstatica[i];
                    AutorizacionAnuncioDto autorizacionAnuncioDinamica = null;

                    if (i < countArrayAutorizacionAnuncioDinamica) autorizacionAnuncioDinamica = arrayAutorizacionAnuncioDinamica[i];

                    if (autorizacionAnuncioEstatica?.TipoAnuncio?.IdTipoAnuncio != autorizacionAnuncioDinamica?.TipoAnuncio?.IdTipoAnuncio)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"CÓDIGO TIPO DE ANUNCIO [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.TipoAnuncio?.Codigo ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.TipoAnuncio?.Codigo ?? "",
                        });
                    }

                    if (autorizacionAnuncioEstatica?.TipoAnuncio?.IdTipoAnuncio != autorizacionAnuncioDinamica?.TipoAnuncio?.IdTipoAnuncio)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"DESCRIPCIÓN TIPO DE ANUNCIO [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.TipoAnuncio?.Descripcion ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.TipoAnuncio?.Descripcion ?? "",
                        });
                    }

                    if (autorizacionAnuncioEstatica?.NumeLados != autorizacionAnuncioDinamica?.NumeLados)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"N° DE LADOS [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.NumeLados?.ToString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.NumeLados?.ToString() ?? "",
                            EsConforme = false
                        });
                    }

                    if (autorizacionAnuncioEstatica?.AreaAutorizada != autorizacionAnuncioDinamica?.AreaAutorizada)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"ÁREA AUTORIZADA DEL ANUNCIO (M²) [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.AreaAutorizada?.ToString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.AreaAutorizada?.ToString() ?? "",
                            EsConforme = false
                        });
                    }

                    if (autorizacionAnuncioEstatica?.AreaVerificada != autorizacionAnuncioDinamica?.AreaVerificada)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"ÁREA VERIFICADA DEL ANUNCIO (M²) [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.AreaVerificada?.ToString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.AreaVerificada?.ToString() ?? "",
                            EsConforme = false
                        });
                    }

                    if (autorizacionAnuncioEstatica?.NumeExpediente != autorizacionAnuncioDinamica?.NumeExpediente)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"N° EXPEDIENTE [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.NumeExpediente?.ToString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.NumeExpediente?.ToString() ?? "",
                            EsConforme = false
                        });
                    }

                    if (autorizacionAnuncioEstatica?.NumeLicencia != autorizacionAnuncioDinamica?.NumeLicencia)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"N° LICENCIA [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.NumeLicencia?.ToString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.NumeLicencia?.ToString() ?? "",
                            EsConforme = false
                        });
                    }

                    if (autorizacionAnuncioEstatica?.FechaExpedicion != autorizacionAnuncioDinamica?.FechaExpedicion)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"F. EXPEDICIÓN [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.FechaExpedicion?.ToShortDateString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.FechaExpedicion?.ToShortDateString() ?? "",
                            EsConforme = false
                        });
                    }

                    if (autorizacionAnuncioEstatica?.FechaVencimiento != autorizacionAnuncioDinamica?.FechaVencimiento)
                    {
                        controlFichasParcial.Add(new ControlFichaDto()
                        {
                            IdFicha = dimamica.Ficha.IdFicha,
                            IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                            NombreFicha = NombreFicha,
                            NombreTab = NombreTab,
                            NombreCampo = $"F. VENCIMIENTO [{i + 1}]",
                            ValorAnterior = autorizacionAnuncioEstatica?.FechaVencimiento?.ToShortDateString() ?? "",
                            ValorActual = autorizacionAnuncioDinamica?.FechaVencimiento?.ToShortDateString() ?? "",
                            EsConforme = false
                        });
                    }
                }
                #endregion

                #region INFORMACION COMPLEMENTARIA
                NombreTab = "Información complementaria";
                var infoComplementariaEstatica = estatica.InfoComplementaria;
                var infoComplementariaDinamica = dimamica.InfoComplementaria;
                var declaranteInfoEstatica = estatica.DeclaranteInfo;
                var declaranteInfoDinamica = dimamica.DeclaranteInfo;

                if (declaranteInfoEstatica?.CondicionPer?.IdCondicionPer != declaranteInfoDinamica?.CondicionPer?.IdCondicionPer)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "CONDICIÓN DE DECLARANTE:",
                        ValorAnterior = declaranteInfoEstatica?.CondicionPer?.Nombre ?? "",
                        ValorActual = declaranteInfoDinamica?.CondicionPer?.Nombre ?? "",
                        EsConforme = false
                    });
                }

                if (infoComplementariaEstatica?.TipoDocPresentado?.IdTipoDocumentoFicha != infoComplementariaDinamica?.TipoDocPresentado?.IdTipoDocumentoFicha)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "DOCUMENTOS PRESENTADOS:",
                        ValorAnterior = infoComplementariaEstatica?.TipoDocPresentado?.Descripcion ?? "",
                        ValorActual = infoComplementariaDinamica?.TipoDocPresentado?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                if (infoComplementariaEstatica?.EstadoLLenado?.IdEstadoLlenado != infoComplementariaDinamica?.EstadoLLenado?.IdEstadoLlenado)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "ESTADO DE LLENADO DE LA FICHA:",
                        ValorAnterior = infoComplementariaEstatica?.EstadoLLenado?.Descripcion ?? "",
                        ValorActual = infoComplementariaDinamica?.EstadoLLenado?.Descripcion ?? "",
                        EsConforme = false
                    });
                }

                if (infoComplementariaEstatica?.TipoMantenimiento?.IdTipoMantenimiento != infoComplementariaDinamica?.TipoMantenimiento?.IdTipoMantenimiento)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "MANTENIMIENTO:",
                        ValorAnterior = infoComplementariaEstatica?.TipoMantenimiento?.Descripcion ?? "",
                        ValorActual = infoComplementariaDinamica?.TipoMantenimiento?.Descripcion ?? "",
                        EsConforme = false
                    });
                }
                #endregion

                #region OBSERVACIONES
                NombreTab = "Información complementaria";

                if (infoComplementariaEstatica?.Observaciones != infoComplementariaDinamica?.Observaciones)
                {
                    controlFichasParcial.Add(new ControlFichaDto()
                    {
                        IdFicha = dimamica.Ficha.IdFicha,
                        IdUnidadCatastral = dimamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = "TIPO DE OBSERVACIÓN",
                        ValorAnterior = infoComplementariaEstatica?.Observaciones ?? "",
                        ValorActual = infoComplementariaDinamica?.Observaciones ?? "",
                        EsConforme = false
                    });
                }
                #endregion
            }

            return controlFichasParcial;
        }
    }
}
