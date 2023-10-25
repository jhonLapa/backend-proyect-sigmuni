using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaDocumentos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Domain.Vias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public partial class ControlFichaService
    {
        private List<ControlFichaDto> ControlFichasIndividual(IndividualDto dinamica, IndividualDto estatica)
        {
            List<ControlFichaDto> controlFichas = new List<ControlFichaDto>();
            string NombreFicha = "Individual";

            string NombreTab = "";

            #region "Ubicación del predio catastral"
            NombreTab = "Ubicación del predio catastral";
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

                if (puertaEstatica?.Via?.TipoVia?.IdTipoVia != puertaDinamica?.Via?.TipoVia?.IdTipoVia)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO VÍA [{i + 1}]",
                        ValorAnterior = puertaEstatica?.Via?.TipoVia?.Descripcion ?? "",
                        ValorActual = puertaDinamica?.Via?.TipoVia?.Descripcion ?? "",
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
                if (puertaEstatica?.NumeracionMunicipal != puertaDinamica?.NumeracionMunicipal)
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

                if (puertaEstatica?.CondicionNumeracion?.IdCondicionNumeracion != puertaDinamica?.CondicionNumeracion?.IdCondicionNumeracion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"COND NUMERACIÓN [{i + 1}]",
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
                        NombreCampo = $"Nº CERTIF DE NUMERACIÓN [{i + 1}]",
                        ValorAnterior = puertaEstatica?.NumCertifPrincipal ?? "",
                        ValorActual = puertaDinamica?.NumCertifPrincipal ?? "",
                    });
                }
                if (puertaEstatica?.TipoInterior?.IdTipoInterior != puertaDinamica?.TipoInterior?.IdTipoInterior)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO INT[{i + 1}]",
                        ValorAnterior = puertaEstatica?.TipoInterior?.Descripcion ?? "",
                        ValorActual = puertaDinamica?.TipoInterior?.Descripcion ?? "",
                    });
                }
                if (puertaEstatica?.NumeroInterior != puertaDinamica?.NumeroInterior)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"N° INTER[{i + 1}]",
                        ValorAnterior = puertaEstatica?.NumeroInterior ?? "",
                        ValorActual = puertaDinamica?.NumeroInterior ?? "",
                    });
                }
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

            if (ubicacionEstatica?.HabilitacionUrbana?.IdHabilitacionUrbana != ubicacionDinamica?.HabilitacionUrbana?.IdHabilitacionUrbana)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE DE LA HABILITACIÓN URBANA",
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
                    NombreCampo = "SUB-LOTE",
                    ValorAnterior = edificacionEstatica?.SubLote ?? "",
                    ValorActual = edificacionDinamica?.SubLote ?? "",
                    EsConforme = false,
                });
            }
            #endregion "Ubicación del predio catastral"

            #region "Identificación del titular catastral"
            NombreTab = "Identificación del titular catastral";
            var titularEstatica = estatica.Titular;
            var titularDinamica = dinamica.Titular;
            var domicilioTitularEstatica = estatica.DomicilioTitular;
            var domicilioTitularDinamica = dinamica.DomicilioTitular;

            if (titularEstatica?.DocumentoIdentidad?.Id != titularDinamica?.DocumentoIdentidad?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DOC. IDENT. (TITULAR)",
                    ValorAnterior = titularEstatica?.DocumentoIdentidad?.Descripcion ?? "",
                    ValorActual = titularDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.EstadoCivil?.Id != titularDinamica?.EstadoCivil?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ESTADO CIVIL (TITULAR)",
                    ValorAnterior = titularEstatica?.EstadoCivil?.Descripcion ?? "",
                    ValorActual = titularDinamica?.EstadoCivil?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.NumeroDni?.Trim()?.ToUpper() != titularDinamica?.NumeroDni?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DOC. (TITULAR)",
                    ValorAnterior = titularEstatica?.NumeroDni ?? "",
                    ValorActual = titularDinamica?.NumeroDni ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.NumeroRuc?.Trim()?.ToUpper() != titularDinamica?.NumeroRuc?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° RUC (TITULAR)",
                    ValorAnterior = titularEstatica?.NumeroRuc ?? "",
                    ValorActual = titularDinamica?.NumeroRuc ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.CodigoContribuyente?.Trim()?.ToUpper() != titularDinamica?.CodigoContribuyente?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COD. CONTRIBUYENTE SAT (TITULAR)",
                    ValorAnterior = titularEstatica?.CodigoContribuyente ?? "",
                    ValorActual = titularDinamica?.CodigoContribuyente ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Paterno?.Trim()?.ToUpper() != titularDinamica?.Paterno?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO PATERNO (TITULAR)",
                    ValorAnterior = titularEstatica?.Paterno ?? "",
                    ValorActual = titularDinamica?.Paterno ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Materno?.Trim()?.ToUpper() != titularDinamica?.Materno?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO MATERNO (TITULAR)",
                    ValorAnterior = titularEstatica?.Materno ?? "",
                    ValorActual = titularDinamica?.Materno ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Nombre?.Trim()?.ToUpper() != titularDinamica?.Nombre?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRES (TITULAR)",
                    ValorAnterior = titularEstatica?.Nombre ?? "",
                    ValorActual = titularDinamica?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Contacto?.Correo?.Trim()?.ToUpper() != titularDinamica?.Contacto?.Correo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CORREO ELECTRÓNICO (TITULAR)",
                    ValorAnterior = titularEstatica?.Contacto?.Correo ?? "",
                    ValorActual = titularDinamica?.Contacto?.Correo ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Contacto?.Telefono?.Trim()?.ToUpper() != titularDinamica?.Contacto?.Telefono?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TELÉFONO. (TITULAR)",
                    ValorAnterior = titularEstatica?.Contacto?.Telefono ?? "",
                    ValorActual = titularDinamica?.Contacto?.Telefono ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Contacto?.Anexo?.Trim()?.ToUpper() != titularDinamica?.Contacto?.Anexo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ANEXO (TITULAR)",
                    ValorAnterior = titularEstatica?.Contacto?.Anexo ?? "",
                    ValorActual = titularDinamica?.Contacto?.Anexo ?? "",
                    EsConforme = false,
                });
            }
            if(titularEstatica?.Contacto?.Fax?.Trim()?.ToUpper() != titularDinamica?.Contacto?.Fax?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FAX (TITULAR)",
                    ValorAnterior = titularEstatica?.Contacto?.Fax ?? "",
                    ValorActual = titularDinamica?.Contacto?.Fax ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.CategoriaOrganizacion?.IdCategoriaOrganizacion != titularDinamica?.CategoriaOrganizacion?.IdCategoriaOrganizacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PERSONA JURIDICA (TITULAR)",
                    ValorAnterior = titularEstatica?.CategoriaOrganizacion?.Descripcion ?? "",
                    ValorActual = titularDinamica?.CategoriaOrganizacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (titularEstatica?.Conyuge?.DocumentoIdentidad?.Id != titularDinamica?.Conyuge?.DocumentoIdentidad?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DOC. IDENT. (CONYUGE)",
                    ValorAnterior = titularEstatica?.Conyuge?.DocumentoIdentidad?.Descripcion ?? "",
                    ValorActual = titularDinamica?.Conyuge?.DocumentoIdentidad?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Conyuge?.NumeroDni?.Trim()?.ToUpper() != titularDinamica?.Conyuge?.NumeroDni?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DOC (CONYUGE)",
                    ValorAnterior = titularEstatica?.Conyuge?.NumeroDni ?? "",
                    ValorActual = titularDinamica?.Conyuge?.NumeroDni ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Conyuge?.Paterno?.Trim()?.ToUpper() != titularDinamica?.Conyuge?.Paterno?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO PATERNO (CONYUGE)",
                    ValorAnterior = titularEstatica?.Conyuge?.Paterno ?? "",
                    ValorActual = titularDinamica?.Conyuge?.Paterno ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Conyuge?.Materno?.Trim()?.ToUpper() != titularDinamica?.Conyuge?.Materno?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO MATERNO (CONYUGE)",
                    ValorAnterior = titularEstatica?.Conyuge?.Materno ?? "",
                    ValorActual = titularDinamica?.Conyuge?.Materno ?? "",
                    EsConforme = false,
                });
            }
            if (titularEstatica?.Conyuge?.Nombre?.Trim()?.ToUpper() != titularDinamica?.Conyuge?.Nombre?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRES (CONYUGE)",
                    ValorAnterior = titularEstatica?.Conyuge?.Nombre ?? "",
                    ValorActual = titularDinamica?.Conyuge?.Nombre ?? "",
                    EsConforme = false,
                });
            }

            if (domicilioTitularEstatica?.IdPuerta != domicilioTitularDinamica?.IdPuerta)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "DIRECCIONES",
                    ValorAnterior = domicilioTitularEstatica?.IdPuerta.ToString() ?? "",
                    ValorActual = domicilioTitularDinamica?.IdPuerta.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Ubigeo?.CodigoParcial?.Trim().ToUpper() != domicilioTitularDinamica?.Ubigeo?.CodigoParcial?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CÓDIGO DE VÍA",
                    ValorAnterior = domicilioTitularEstatica?.Ubigeo?.CodigoParcial ?? "",
                    ValorActual = domicilioTitularDinamica?.Ubigeo?.CodigoParcial ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Ubigeo?.Codigo != domicilioTitularDinamica?.Ubigeo?.Codigo)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "DISTRITO",
                    ValorAnterior = domicilioTitularEstatica?.Ubigeo?.Nombre ?? "",
                    ValorActual = domicilioTitularDinamica?.Ubigeo?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.NumMunicipal?.Trim()?.ToUpper() != domicilioTitularDinamica?.NumMunicipal?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° MUNICIPAL",
                    ValorAnterior = domicilioTitularEstatica?.Ubigeo?.CodigoParcial ?? "",
                    ValorActual = domicilioTitularDinamica?.Ubigeo?.CodigoParcial ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.LtPrincipal?.Trim()?.ToUpper() != domicilioTitularDinamica?.LtPrincipal?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "LOTE",
                    ValorAnterior = domicilioTitularEstatica?.LtPrincipal ?? "",
                    ValorActual = domicilioTitularDinamica?.LtPrincipal ?? "",
                    EsConforme = false,
                });
            }

            if (domicilioTitularEstatica?.Edificacion?.Nombre?.Trim()?.ToUpper() != domicilioTitularDinamica?.Edificacion?.Nombre?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE DE EDIFICACIÓN",
                    ValorAnterior = domicilioTitularEstatica?.Edificacion?.Nombre ?? "",
                    ValorActual = domicilioTitularDinamica?.Edificacion?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana?.Trim()?.ToUpper() != domicilioTitularDinamica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CÓDIGO HU",
                    ValorAnterior = domicilioTitularEstatica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana ?? "",
                    ValorActual = domicilioTitularDinamica?.HabilitacionesUrbanas?.CodigoHabilitacioUrbana ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.HabilitacionesUrbanas?.IdHabilitacionUrbana != domicilioTitularDinamica?.HabilitacionesUrbanas?.IdHabilitacionUrbana)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRE HU",
                    ValorAnterior = domicilioTitularEstatica?.HabilitacionesUrbanas?.Nombre ?? "",
                    ValorActual = domicilioTitularDinamica?.HabilitacionesUrbanas?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Edificacion?.TipoAgrupacion?.IdTipoAgrupacion != domicilioTitularDinamica?.Edificacion?.TipoAgrupacion?.IdTipoAgrupacion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ZONA/SECTOR/ETAPA",
                    ValorAnterior = domicilioTitularEstatica?.Edificacion?.TipoAgrupacion?.Descripcion ?? "",
                    ValorActual = domicilioTitularDinamica?.Edificacion?.TipoAgrupacion?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Edificacion?.NumLote?.Trim()?.ToUpper() != domicilioTitularDinamica?.Edificacion?.NumLote?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "LOTE",
                    ValorAnterior = domicilioTitularEstatica?.Edificacion?.NumLote ?? "",
                    ValorActual = domicilioTitularDinamica?.Edificacion?.NumLote ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Edificacion?.Manzana?.Trim()?.ToUpper() != domicilioTitularDinamica?.Edificacion?.Manzana?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MANZANA",
                    ValorAnterior = domicilioTitularEstatica?.Edificacion?.Manzana ?? "",
                    ValorActual = domicilioTitularDinamica?.Edificacion?.Manzana ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Edificacion?.LoteUrbano?.Trim()?.ToUpper() != domicilioTitularDinamica?.Edificacion?.LoteUrbano?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "LOTE",
                    ValorAnterior = domicilioTitularEstatica?.Edificacion?.LoteUrbano ?? "",
                    ValorActual = domicilioTitularDinamica?.Edificacion?.LoteUrbano ?? "",
                    EsConforme = false,
                });
            }
            if (domicilioTitularEstatica?.Edificacion?.SubLote?.Trim()?.ToUpper() != domicilioTitularDinamica?.Edificacion?.SubLote?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "SUB-LOTE",
                    ValorAnterior = domicilioTitularEstatica?.Edificacion?.SubLote ?? "",
                    ValorActual = domicilioTitularDinamica?.Edificacion?.SubLote ?? "",
                    EsConforme = false,
                });
            }

            #endregion

            #region "Características de la titularidad"

            NombreTab = "Características de la titularidad";
            var caracteristicaTitularidadEstatica = estatica.CaracteristicaTitularidad;
            var caracteristicaTitularidadDinamica = dinamica.CaracteristicaTitularidad;

            if (caracteristicaTitularidadEstatica?.CondicionTitular?.IdCondicionTitular != caracteristicaTitularidadDinamica?.CondicionTitular?.IdCondicionTitular)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CONDICIÓN DEL TITULAR CATASTRAL",
                    ValorAnterior = caracteristicaTitularidadEstatica?.CondicionTitular?.Descripcion ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.CondicionTitular?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.FormaAdquisicion?.IdFormaAdquisicion != caracteristicaTitularidadDinamica?.FormaAdquisicion?.IdFormaAdquisicion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FORMA DE ADQUISICIÓN",
                    ValorAnterior = caracteristicaTitularidadEstatica?.FormaAdquisicion?.Nombre ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.FormaAdquisicion?.Nombre ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.FechaAdquisicion != caracteristicaTitularidadDinamica?.FechaAdquisicion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA DE ADQUISICIÓN",
                    ValorAnterior = caracteristicaTitularidadEstatica?.FechaAdquisicion?.ToShortDateString() ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.FechaAdquisicion?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.ExoneracionPredio?.CondicionEspecialPredio?.IdCondicionEspecialPredio != caracteristicaTitularidadDinamica?.ExoneracionPredio?.CondicionEspecialPredio?.IdCondicionEspecialPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CONDICION ESPECIAL DEL PREDIO(Exoneración)",
                    ValorAnterior = caracteristicaTitularidadEstatica?.ExoneracionPredio?.CondicionEspecialPredio?.Nombre ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.ExoneracionPredio?.CondicionEspecialPredio?.Nombre ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.ExoneracionPredio?.NumeroResolucion != caracteristicaTitularidadDinamica?.ExoneracionPredio?.NumeroResolucion)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DE RESOLUCIÓN DE EXONERACIÓN DEL PREDIO",
                    ValorAnterior = caracteristicaTitularidadEstatica?.ExoneracionPredio?.NumeroResolucion ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.ExoneracionPredio?.NumeroResolucion ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.ExoneracionPredio?.Porcentaje != caracteristicaTitularidadDinamica?.ExoneracionPredio?.Porcentaje)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PORCENTAJE",
                    ValorAnterior = caracteristicaTitularidadEstatica?.ExoneracionPredio?.Porcentaje.ToString() ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.ExoneracionPredio?.Porcentaje.ToString() ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.ExoneracionPredio?.FechaInicio != caracteristicaTitularidadDinamica?.ExoneracionPredio?.FechaInicio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA DE INICIO",
                    ValorAnterior = caracteristicaTitularidadEstatica?.ExoneracionPredio?.FechaInicio?.ToShortDateString() ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.ExoneracionPredio?.FechaInicio?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }

            if (caracteristicaTitularidadEstatica?.ExoneracionPredio?.FechaVencimiento != caracteristicaTitularidadDinamica?.ExoneracionPredio?.FechaVencimiento)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA DE VENCIMIENTO",
                    ValorAnterior = caracteristicaTitularidadEstatica?.ExoneracionPredio?.FechaVencimiento?.ToShortDateString() ?? "",
                    ValorActual = caracteristicaTitularidadDinamica?.ExoneracionPredio?.FechaVencimiento?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }

            #endregion

            #region "Descripción del predio"

            NombreTab = "Descripción del predio";
            var descripPredioEstatica = estatica.DescripcionPredio;
            var descripPredioDinamica = dinamica.DescripcionPredio;
            var evaluacionEstatica = estatica.EvaluacionPredio;
            var evaluacionDinamica = dinamica.EvaluacionPredio;

            if (descripPredioEstatica?.ClasificacionPredio?.IdClasificacionPredio != descripPredioDinamica?.ClasificacionPredio?.IdClasificacionPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CLASIFICACIÓN DEL PREDIO",
                    ValorAnterior = descripPredioEstatica?.ClasificacionPredio?.Descripcion ?? "",
                    ValorActual = descripPredioDinamica?.ClasificacionPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (descripPredioEstatica?.PredioCatastralEn?.IdPredioCatastralEn != descripPredioDinamica?.PredioCatastralEn?.IdPredioCatastralEn)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PREDIO CATASTRAL EN.",
                    ValorAnterior = descripPredioEstatica?.PredioCatastralEn?.Descripcion ?? "",
                    ValorActual = descripPredioDinamica?.PredioCatastralEn?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (descripPredioEstatica?.UsoPredio?.Codigo?.Trim()?.ToUpper() != descripPredioDinamica?.UsoPredio?.Codigo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CÓDIGO DE USO",
                    ValorAnterior = descripPredioEstatica?.UsoPredio?.Codigo ?? "",
                    ValorActual = descripPredioDinamica?.UsoPredio?.Codigo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.UsoPredio?.IdUsoPredio != descripPredioDinamica?.UsoPredio?.IdUsoPredio)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "USO DEL PREDIO CATASTRAL",
                    ValorAnterior = descripPredioEstatica?.UsoPredio?.Descripcion ?? "",
                    ValorActual = descripPredioDinamica?.UsoPredio?.Descripcion ?? "",
                    EsConforme = false,
                });
            }

            if (descripPredioEstatica?.AreaTitulo != descripPredioDinamica?.AreaTitulo)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA DE TERRENO SEGÚN TÍTULO (M2)",
                    ValorAnterior = descripPredioEstatica?.AreaTitulo?.ToString() ?? "",
                    ValorActual = descripPredioDinamica?.AreaTitulo?.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.AreaVerificada != descripPredioDinamica?.AreaVerificada)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "ÁREA DE TERRENO VERIFICADA (M2)",
                    ValorAnterior = descripPredioEstatica?.AreaVerificada?.ToString() ?? "",
                    ValorActual = descripPredioDinamica?.AreaVerificada?.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaFrenteCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaFrenteCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-FRENTE",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaFrenteCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaFrenteCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaFrenteTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaFrenteTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-FRENTE",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaFrenteTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaFrenteTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaFrenteCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaFrenteCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-FRENTE",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaFrenteCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaFrenteCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaFrenteTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaFrenteTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-FRENTE",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaFrenteTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaFrenteTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaDerechaCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaDerechaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-DERECHA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaDerechaCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaDerechaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaDerechaTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaDerechaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-DERECHA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaDerechaTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaDerechaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaDerechaCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaDerechaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-DERECHA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaDerechaCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaDerechaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaDerechaTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaDerechaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-DERECHA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaDerechaTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaDerechaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaIzquierdaCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaIzquierdaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-IZQUIERDA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaIzquierdaCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaIzquierdaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaIzquierdaTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaIzquierdaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-IZQUIERDA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaIzquierdaTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaIzquierdaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaIzquierdaCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaIzquierdaCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-IZQUIERDA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaIzquierdaCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaIzquierdaCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaIzquierdaTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaIzquierdaTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-IZQUIERDA",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaIzquierdaTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaIzquierdaTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaFondoCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaFondoCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN CAMPO-FONDO",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaFondoCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaFondoCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.MedidaFondoTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.MedidaFondoTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "MEDIDA SEGÚN TÍTULO-FONDO",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.MedidaFondoTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.MedidaFondoTitulo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaFondoCampo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaFondoCampo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN CAMPO-FONDO",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaFondoCampo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaFondoCampo ?? "",
                    EsConforme = false,
                });
            }
            if (descripPredioEstatica?.LinderoPredio?.ColindaFondoTitulo?.Trim()?.ToUpper() != descripPredioDinamica?.LinderoPredio?.ColindaFondoTitulo?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COLINDANCIAS SEGÚN TÍTULO-FONDO",
                    ValorAnterior = descripPredioEstatica?.LinderoPredio?.ColindaFondoTitulo ?? "",
                    ValorActual = descripPredioDinamica?.LinderoPredio?.ColindaFondoTitulo ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Servicios que cuenta el predio"
            NombreTab = "Servicios que cuenta el predio";
            var servicioEstatica = estatica.ServicioBasico;
            var servicioDinamica = dinamica.ServicioBasico;

            if (servicioEstatica?.Luz?.IdTipoServicioBasico != servicioDinamica?.Luz?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "LUZ",
                    ValorAnterior = servicioEstatica?.Luz?.Descripcion ?? "",
                    ValorActual = servicioDinamica?.Luz?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (servicioEstatica?.SuministroLuz != servicioDinamica?.SuministroLuz)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° SUM LUZ",
                    ValorAnterior = servicioEstatica?.SuministroLuz ?? "",
                    ValorActual = servicioDinamica?.SuministroLuz ?? "",
                    EsConforme = false,
                });
            }
            if (servicioEstatica?.Agua?.IdTipoServicioBasico != servicioDinamica?.Agua?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "AGUA",
                    ValorAnterior = servicioEstatica?.Agua?.Descripcion ?? "",
                    ValorActual = servicioDinamica?.Agua?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (servicioEstatica?.NumContratoAgua != servicioDinamica?.NumContratoAgua)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° CONTRATO DE AGUA",
                    ValorAnterior = servicioEstatica?.NumContratoAgua ?? "",
                    ValorActual = servicioDinamica?.NumContratoAgua ?? "",
                    EsConforme = false,
                });
            }
            if (servicioEstatica?.Telefono?.IdTipoServicioBasico != servicioDinamica?.Telefono?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TELÉFONO",
                    ValorAnterior = servicioEstatica?.Telefono?.Descripcion ?? "",
                    ValorActual = servicioDinamica?.Telefono?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (servicioEstatica?.NumTelefono != servicioDinamica?.NumTelefono)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° TELEFONO",
                    ValorAnterior = servicioEstatica?.NumTelefono ?? "",
                    ValorActual = servicioDinamica?.NumTelefono ?? "",
                    EsConforme = false,
                });
            }
            if (servicioEstatica?.Desague?.IdTipoServicioBasico != servicioDinamica?.Desague?.IdTipoServicioBasico)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "DESAGÜE",
                    ValorAnterior = servicioEstatica?.Desague?.Descripcion ?? "",
                    ValorActual = servicioDinamica?.Desague?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Construcciones"
            NombreTab = "Construcciones";

            var individualAdicionalEstatica = estatica.IndividualAdicional;
            var individualAdicionalDinamica = dinamica.IndividualAdicional;
            var construccionesEstatica = estatica.Construcciones;
            var construccionesDinamica = dinamica.Construcciones;

            int countConstruccionesEstatica = construccionesEstatica?.Count ?? 0;
            int countConstruccionesDinamica = construccionesDinamica?.Count ?? 0;
            for (int i = 0; i < countConstruccionesEstatica; i++)
            {
                var construccionEstatica = construccionesEstatica[i];
                ConstruccionDto construccionDinamica = null;

                if (i < countConstruccionesDinamica) construccionDinamica = construccionesDinamica[i];

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
                if (construccionEstatica?.EstructuraMuroColumna?.Trim()?.ToUpper() != construccionDinamica?.EstructuraMuroColumna?.Trim()?.ToUpper())
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
                        NombreCampo = $"ÁREA TECHADA DECLARADA (M2) [{i + 1}]",
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
                        NombreCampo = $"ÁREA TECHADA VERIFICADA (M2) [{i + 1}]",
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

            if (individualAdicionalEstatica?.PorcBcLegalTerr != individualAdicionalDinamica?.PorcBcLegalTerr)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "% DE BC-LEGAL TERRENO",
                    ValorAnterior = individualAdicionalEstatica?.PorcBcLegalTerr.ToString() ?? "",
                    ValorActual = individualAdicionalDinamica?.PorcBcLegalTerr.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (individualAdicionalEstatica?.PorcBcFiscTerr != individualAdicionalDinamica?.PorcBcFiscTerr)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "% DE BC-FÍSICO TERRENO",
                    ValorAnterior = individualAdicionalEstatica?.PorcBcFiscTerr.ToString() ?? "",
                    ValorActual = individualAdicionalDinamica?.PorcBcFiscTerr.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (individualAdicionalEstatica?.PorcBcLegalConst != individualAdicionalDinamica?.PorcBcLegalConst)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "% DE BC-LEGAL CONSTRUCCIÓN",
                    ValorAnterior = individualAdicionalEstatica?.PorcBcLegalConst.ToString() ?? "",
                    ValorActual = individualAdicionalDinamica?.PorcBcLegalConst.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (individualAdicionalEstatica?.PorcBcFiscConst != individualAdicionalDinamica?.PorcBcFiscConst)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "% DE BC-FÍSICO CONSTRUCCIÓN",
                    ValorAnterior = individualAdicionalEstatica?.PorcBcFiscConst.ToString() ?? "",
                    ValorActual = individualAdicionalDinamica?.PorcBcFiscConst.ToString() ?? "",
                    EsConforme = false,
                });
            }
            #endregion

            #region "Obras complementarias e instalaciones fijas y permanentes"
            NombreTab = "Obras complementarias e instalaciones fijas y permanentes";

            var individualAdicionalObrasEstatica = estatica.IndividualAdicional;
            var individualAdicionalObrasDinamica = dinamica.IndividualAdicional;
            var otrasInstalacionesEstatica = estatica.OtraInstalaciones;
            var otrasInstalacionesDinamica = dinamica.OtraInstalaciones;

            int countotrasInstalacionesEstatica = otrasInstalacionesEstatica?.Count ?? 0;
            int countotrasInstalacionesDinamica = otrasInstalacionesDinamica?.Count ?? 0;
            for (int i = 0; i < countotrasInstalacionesEstatica; i++)
            {
                var otraInstalacionesEstatica = otrasInstalacionesEstatica[i];
                OtraInstalacionDto otraInstalacionDinamica = null;

                if (i < countotrasInstalacionesDinamica) otraInstalacionDinamica = otrasInstalacionesDinamica[i];

                if (otraInstalacionesEstatica?.TipoOtraInstalacion?.Codigo != otraInstalacionDinamica?.TipoOtraInstalacion?.Codigo)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"CODIGO [{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.TipoOtraInstalacion?.Codigo ?? "",
                        ValorActual = otraInstalacionDinamica?.TipoOtraInstalacion?.Codigo ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.TipoOtraInstalacion?.IdTipoOtraInstalacion != otraInstalacionDinamica?.TipoOtraInstalacion?.IdTipoOtraInstalacion)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"DESCRIPCIÓN [{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.TipoOtraInstalacion?.Descripcion ?? "",
                        ValorActual = otraInstalacionDinamica?.TipoOtraInstalacion?.Descripcion ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.MesAnio?.Month != otraInstalacionDinamica?.MesAnio?.Month)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MES [{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.MesAnio?.Month.ToString() ?? "",
                        ValorActual = otraInstalacionDinamica?.MesAnio?.Month.ToString() ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.MesAnio?.Year != otraInstalacionDinamica?.MesAnio?.Year)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"AÑO[{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.MesAnio?.Year.ToString() ?? "",
                        ValorActual = otraInstalacionDinamica?.MesAnio?.Year.ToString() ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Mep?.IdMep != otraInstalacionDinamica?.Mep?.IdMep)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MEP[{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Mep?.Descripcion ?? "",
                        ValorActual = otraInstalacionDinamica?.Mep?.Descripcion ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Ecs?.IdEcs != otraInstalacionDinamica?.Ecs?.IdEcs)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ECS[{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Ecs?.Descripcion ?? "",
                        ValorActual = otraInstalacionDinamica?.Ecs?.Descripcion ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Ecc?.IdEcc != otraInstalacionDinamica?.Ecc?.IdEcc)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ECC[{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Ecc?.Descripcion ?? "",
                        ValorActual = otraInstalacionDinamica?.Ecc?.Descripcion ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Largo != otraInstalacionDinamica?.Largo)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"LARGO [{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Largo.ToString() ?? "",
                        ValorActual = otraInstalacionDinamica?.Largo.ToString() ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Ancho != otraInstalacionDinamica?.Ancho)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ANCHO [{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Ancho.ToString() ?? "",
                        ValorActual = otraInstalacionDinamica?.Ancho.ToString() ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Alto != otraInstalacionDinamica?.Alto)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ALTO [{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Alto.ToString() ?? "",
                        ValorActual = otraInstalacionDinamica?.Alto.ToString() ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.ProductoTotal != otraInstalacionDinamica?.ProductoTotal)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"PRODUCTO TOTAL[{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.ProductoTotal.ToString() ?? "",
                        ValorActual = otraInstalacionDinamica?.ProductoTotal.ToString() ?? "",
                    });
                }
                if (otraInstalacionesEstatica?.Uca?.IdUca != otraInstalacionDinamica?.Uca?.IdUca)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"U.C.A[{i + 1}]",
                        ValorAnterior = otraInstalacionesEstatica?.Uca?.Descripcion ?? "",
                        ValorActual = otraInstalacionDinamica?.Uca?.Descripcion ?? "",
                    });
                }
            }
            #endregion

            #region "Documentos presentados"
            NombreTab = "Documentos presentados";
            var documentosEstatico = estatica.Documentos;
            var documentosDinamica = dinamica.Documentos;

            int countDocumentosEstatico = documentosEstatico?.Count ?? 0;
            int countDocumentosDinamica = documentosDinamica?.Count ?? 0;
            for (int i = 0; i < countDocumentosEstatico; i++)
            {
                var documentoEstatico = documentosEstatico[i];
                FichaDocumentoDto documentoDinamica = null;

                if (i < countDocumentosDinamica) documentoDinamica = documentosDinamica[i];
                if (documentoEstatico?.TipoDocumentoPresentado?.IdTipoDocumentoFicha != documentoDinamica?.TipoDocumentoPresentado?.IdTipoDocumentoFicha)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO DOC. [{i + 1}]",
                        ValorAnterior = documentoEstatico?.TipoDocumentoPresentado?.Descripcion ?? "",
                        ValorActual = documentoDinamica?.TipoDocumentoPresentado?.Descripcion ?? "",
                    });
                }
                if (documentoEstatico?.NumeroDocumento != documentoDinamica?.NumeroDocumento)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Nº DOC. [{i + 1}]",
                        ValorAnterior = documentoEstatico?.NumeroDocumento ?? "",
                        ValorActual = documentoDinamica?.NumeroDocumento ?? "",
                    });
                }
                if (documentoEstatico?.Fecha != documentoDinamica?.Fecha)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA [{i + 1}]",
                        ValorAnterior = documentoEstatico?.Fecha?.ToShortDateString() ?? "",
                        ValorActual = documentoDinamica?.Fecha?.ToShortDateString() ?? "",
                    });
                }
                if (documentoEstatico?.TotalArea != documentoDinamica?.TotalArea)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"ÁREA AUTORIZADA (M2) [{i + 1}]",
                        ValorAnterior = documentoEstatico?.TotalArea?.ToString() ?? "",
                        ValorActual = documentoDinamica?.TotalArea?.ToString() ?? "",
                    });
                }
            }

            var infosLegalEstatica = estatica.InfoLegal;
            var infosLegalDinamica = dinamica.InfoLegal;
            int countInfosLegalEstatica = infosLegalEstatica?.Count ?? 0;
            int countInfosLegalDinamica = infosLegalDinamica?.Count ?? 0;

            for (int i = 0; i < countInfosLegalEstatica; i++)
            {
                var infoLegalEstatica = infosLegalEstatica[i];
                RegistroLegalDto infoLegalDinamica = null;

                if (i < countInfosLegalDinamica) infoLegalDinamica = infosLegalDinamica[i];

                if (infoLegalEstatica?.Notaria != infoLegalDinamica?.Notaria)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOTARIA [{i + 1}]",
                        ValorAnterior = infoLegalEstatica?.Notaria ?? "",
                        ValorActual = infoLegalDinamica?.Notaria ?? "",
                    });
                }
                if (infoLegalEstatica?.Kardex?.Trim()?.ToUpper() != infoLegalDinamica?.Kardex?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"KARDEX [{i + 1}]",
                        ValorAnterior = infoLegalEstatica?.Kardex ?? "",
                        ValorActual = infoLegalDinamica?.Kardex ?? "",
                    });
                }
                if (infoLegalEstatica?.FechaEscritura != infoLegalDinamica?.FechaEscritura)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA DE ESCRITURA PUBLICA [{i + 1}]",
                        ValorAnterior = infoLegalEstatica?.FechaEscritura?.ToShortDateString() ?? "",
                        ValorActual = infoLegalDinamica?.FechaEscritura?.ToShortDateString() ?? "",
                    });
                }
            }

            #endregion

            #region "Inscripcion en el registro de predios"
            NombreTab = "Inscripcion en el registro de predios";

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
                        NombreCampo = $"TIPO PART. REG. [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.TipoPartidaRegistral?.Descripcion ?? "",
                        ValorActual = inscripcionDinamica?.TipoPartidaRegistral?.Descripcion ?? "",
                    });
                }
                if (inscripcionEstatica?.NumeroPartida?.Trim()?.ToUpper() != inscripcionDinamica?.NumeroPartida?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NÚMERO [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.NumeroPartida?.ToString() ?? "",
                        ValorActual = inscripcionDinamica?.NumeroPartida?.ToString() ?? "",
                    });
                }
                if (inscripcionEstatica?.Fojas?.Trim()?.ToUpper() != inscripcionDinamica?.Fojas?.Trim()?.ToUpper())
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
                if (inscripcionEstatica?.Asiento?.Trim()?.ToUpper() != inscripcionDinamica?.Asiento?.Trim()?.ToUpper())
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
                if (inscripcionEstatica?.FechaFabrica != inscripcionDinamica?.FechaFabrica)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"FECHA INSCRIPCIÓN DE FABRICA [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.FechaFabrica?.ToShortDateString() ?? "",
                        ValorActual = inscripcionDinamica?.FechaFabrica?.ToShortDateString() ?? "",
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
                        NombreCampo = $"FECHA INSCRIPCIÓN [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.FechaInscripcion?.ToShortDateString() ?? "",
                        ValorActual = inscripcionDinamica?.FechaInscripcion?.ToShortDateString() ?? "",
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
                        NombreCampo = $"AS.INSC.DE FABRICA [{i + 1}]",
                        ValorAnterior = inscripcionEstatica?.AsientoFabrica ?? "",
                        ValorActual = inscripcionDinamica?.AsientoFabrica ?? "",
                    });
                }
            }





            #endregion

            #region "Evaluacion del predio catastral"
            NombreTab = "Evaluacion del predio catastral";
            var evaluacionPredioCatastralEstatica = estatica.EvaluacionPredioCatastral;
            var evaluacionPredioCatastralDinamica = dinamica.EvaluacionPredioCatastral;

            if (evaluacionPredioCatastralEstatica?.PredioCatastralOmiso != evaluacionPredioCatastralDinamica?.PredioCatastralOmiso)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PREDIO CATASTRAL OMISO",
                    ValorAnterior = evaluacionPredioCatastralEstatica?.PredioCatastralOmiso.ToString() ?? "",
                    ValorActual = evaluacionPredioCatastralDinamica?.PredioCatastralOmiso.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (evaluacionPredioCatastralEstatica?.PredioCatastralSubEvaluado != evaluacionPredioCatastralDinamica?.PredioCatastralSubEvaluado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PREDIO CATASTRAL SUBVALUADO",
                    ValorAnterior = evaluacionPredioCatastralEstatica?.PredioCatastralSubEvaluado.ToString() ?? "",
                    ValorActual = evaluacionPredioCatastralDinamica?.PredioCatastralSubEvaluado.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (evaluacionPredioCatastralEstatica?.PredioCatastralSobreEvaluado != evaluacionPredioCatastralDinamica?.PredioCatastralSobreEvaluado)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PREDIO CATASTRAL SOBREVALUADO",
                    ValorAnterior = evaluacionPredioCatastralEstatica?.PredioCatastralSobreEvaluado.ToString() ?? "",
                    ValorActual = evaluacionPredioCatastralDinamica?.PredioCatastralSobreEvaluado.ToString() ?? "",
                    EsConforme = false,
                });
            }
            if (evaluacionPredioCatastralEstatica?.PredioCatastralConforme != evaluacionPredioCatastralDinamica?.PredioCatastralConforme)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "PREDIO CATASTRAL CONFORME",
                    ValorAnterior = evaluacionPredioCatastralEstatica?.PredioCatastralConforme.ToString() ?? "",
                    ValorActual = evaluacionPredioCatastralDinamica?.PredioCatastralConforme.ToString() ?? "",
                    EsConforme = false,
                });
            }

            
            #endregion

            #region "Información complementaria"
            var declaranteInfoComplementariaEstatica = estatica.DeclaranteInfo;
            var declaranteInfoComplementariaDinamica = dinamica.DeclaranteInfo;
            if (declaranteInfoComplementariaEstatica?.CondicionPer?.IdCondicionPer != declaranteInfoComplementariaDinamica?.CondicionPer?.IdCondicionPer)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "COND. DE DECLARANTE",
                    ValorAnterior = declaranteInfoComplementariaEstatica?.CondicionPer?.Nombre ?? "",
                    ValorActual = declaranteInfoComplementariaDinamica?.CondicionPer?.Nombre ?? "",
                    EsConforme = false,
                });
            }

            var litigantesEstatica = estatica.Litigantes;
            var litigantesDinamica = dinamica.Litigantes;

            int countLitigantesEstatica = litigantesEstatica?.Count ?? 0;
            int countLitigantesDinamica = litigantesDinamica?.Count ?? 0;
            for (int i = 0; i < countLitigantesEstatica; i++)
            {
                var litiganteEstatica = litigantesEstatica[i];
                PersonaLitiganteDto litiganteDinamica = null;
                if (i < countLitigantesDinamica) litiganteDinamica = litigantesDinamica[i];
                if (litiganteEstatica?.DocumentoIdentidad?.Id != litiganteDinamica?.DocumentoIdentidad?.Id)
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"TIPO DOC IDENT[{i + 1}]",
                        ValorAnterior = litiganteEstatica?.DocumentoIdentidad?.Descripcion ?? "",
                        ValorActual = litiganteDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                    });
                }
                if (litiganteEstatica?.NumeroDni?.Trim()?.ToUpper() != litiganteDinamica?.NumeroDni?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"Nº DOC[{i + 1}]",
                        ValorAnterior = litiganteEstatica?.NumeroDni ?? "",
                        ValorActual = litiganteDinamica?.NumeroDni ?? "",
                    });
                }
                if (litiganteEstatica?.Paterno?.Trim()?.ToUpper() != litiganteDinamica?.Paterno?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"PATERNO[{i + 1}]",
                        ValorAnterior = litiganteEstatica?.Paterno ?? "",
                        ValorActual = litiganteDinamica?.Paterno ?? "",
                    });
                }
                if (litiganteEstatica?.Materno?.Trim()?.ToUpper() != litiganteDinamica?.Materno?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"MATERNO[{i + 1}]",
                        ValorAnterior = litiganteEstatica?.Materno ?? "",
                        ValorActual = litiganteDinamica?.Materno ?? "",
                    });
                }
                if (litiganteEstatica?.Nombre?.Trim()?.ToUpper() != litiganteDinamica?.Nombre?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"NOMBRES[{i + 1}]",
                        ValorAnterior = litiganteEstatica?.Nombre ?? "",
                        ValorActual = litiganteDinamica?.Nombre ?? "",
                    });
                }
                if (litiganteEstatica?.CodigoContribuyenteSat?.Trim()?.ToUpper() != litiganteDinamica?.CodigoContribuyenteSat?.Trim()?.ToUpper())
                {
                    controlFichas.Add(new ControlFichaDto()
                    {
                        IdFicha = dinamica.Ficha.IdFicha,
                        IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                        NombreFicha = NombreFicha,
                        NombreTab = NombreTab,
                        NombreCampo = $"COD CONTRIBUYENTE SAT[{i + 1}]",
                        ValorAnterior = litiganteEstatica?.CodigoContribuyenteSat ?? "",
                        ValorActual = litiganteDinamica?.CodigoContribuyenteSat ?? "",
                    });
                }
            }
            #endregion

            #region "Observaciones"
            NombreTab = "Observaciones";
            var infoComplementariaEstatico = estatica.InfoComplementario;
            var infoComplementariaDinamica = dinamica.InfoComplementario;

            if (infoComplementariaEstatico?.Observaciones != infoComplementariaDinamica?.Observaciones)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "OBSERVACIONES",
                    ValorAnterior = infoComplementariaEstatico?.Observaciones ?? "",
                    ValorActual = infoComplementariaDinamica?.Observaciones ?? "",
                    EsConforme = false,
                });
            }

            #endregion

            #region "Datos de personas que intervienen"
            NombreTab = "Datos de personas que intervienen";
            var declaranteInfoEstatico = estatica.DeclaranteInfo;
            var declaranteInfoDinamica = dinamica.DeclaranteInfo;
            var supervisorInfoEstatico = estatica.SupervisorInfo;
            var supervisorInfoDinamica = dinamica.SupervisorInfo;
            var tecnicoInfoEstatico = estatica.TecnicoInfo;
            var tecnicoInfoDinamica = dinamica.TecnicoInfo;
            var verificadorEstatico = estatica.VerificadorCatastral;
            var verificadorDinamica = dinamica.VerificadorCatastral;

            if (declaranteInfoEstatico?.TieneFirma != declaranteInfoDinamica?.TieneFirma)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CUENTA CON FIRMA (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.TieneFirma == true ? "SI" : "NO" ?? "",
                    ValorActual = declaranteInfoDinamica?.TieneFirma == true ? "SI" : "NO" ?? "",
                    EsConforme = false,
                });
            }
            if (declaranteInfoEstatico?.DocumentoIdentidad?.Id != declaranteInfoDinamica?.DocumentoIdentidad?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DOC. IDENT (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.DocumentoIdentidad?.Descripcion ?? "",
                    ValorActual = declaranteInfoDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (declaranteInfoEstatico?.NumeroDni?.Trim()?.ToUpper() != declaranteInfoDinamica?.NumeroDni?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DOC (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.NumeroDni ?? "",
                    ValorActual = declaranteInfoDinamica?.NumeroDni ?? "",
                    EsConforme = false,
                });
            }
            if (declaranteInfoEstatico?.Paterno?.Trim().ToUpper() != declaranteInfoDinamica?.Paterno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO PATERNO (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.Paterno ?? "",
                    ValorActual = declaranteInfoDinamica?.Paterno ?? "",
                    EsConforme = false,
                });
            }
            if (declaranteInfoEstatico?.Materno?.Trim().ToUpper() != declaranteInfoDinamica?.Materno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO MATERNO (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.Materno ?? "",
                    ValorActual = declaranteInfoDinamica?.Materno ?? "",
                    EsConforme = false,
                });
            }
            if (declaranteInfoEstatico?.Nombre?.Trim().ToUpper() != declaranteInfoDinamica?.Nombre?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRES (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.Nombre ?? "",
                    ValorActual = declaranteInfoDinamica?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (declaranteInfoEstatico?.Fecha != declaranteInfoDinamica?.Fecha)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA (DECLARANTE)",
                    ValorAnterior = declaranteInfoEstatico?.Fecha?.ToShortDateString() ?? "",
                    ValorActual = declaranteInfoDinamica?.Fecha?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }

            if (supervisorInfoEstatico?.TieneFirma != supervisorInfoDinamica?.TieneFirma)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CUENTA CON FIRMA (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.TieneFirma == true ? "SI" : "NO" ?? "",
                    ValorActual = supervisorInfoDinamica?.TieneFirma == true ? "SI" : "NO" ?? "",
                    EsConforme = false,
                });
            }
            if (supervisorInfoEstatico?.DocumentoIdentidad?.Id != supervisorInfoDinamica?.DocumentoIdentidad?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DOC. IDENT (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.DocumentoIdentidad?.Descripcion ?? "",
                    ValorActual = supervisorInfoDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (supervisorInfoEstatico?.NumeroDni?.Trim()?.ToUpper() != supervisorInfoDinamica?.NumeroDni?.Trim()?.ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DOC (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.NumeroDni ?? "",
                    ValorActual = supervisorInfoDinamica?.NumeroDni ?? "",
                    EsConforme = false,
                });
            }
            if (supervisorInfoEstatico?.Paterno?.Trim().ToUpper() != supervisorInfoDinamica?.Paterno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO PATERNO (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.Paterno ?? "",
                    ValorActual = supervisorInfoDinamica?.Paterno ?? "",
                    EsConforme = false,
                });
            }
            if (supervisorInfoEstatico?.Materno?.Trim().ToUpper() != supervisorInfoDinamica?.Materno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO MATERNO (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.Materno ?? "",
                    ValorActual = supervisorInfoDinamica?.Materno ?? "",
                    EsConforme = false,
                });
            }
            if (supervisorInfoEstatico?.Nombre?.Trim().ToUpper() != supervisorInfoDinamica?.Nombre?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRES (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.Nombre ?? "",
                    ValorActual = supervisorInfoDinamica?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (supervisorInfoEstatico?.Fecha != supervisorInfoDinamica?.Fecha)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA (SUPERVISOR)",
                    ValorAnterior = supervisorInfoEstatico?.Fecha?.ToShortDateString() ?? "",
                    ValorActual = supervisorInfoDinamica?.Fecha?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }

            if (tecnicoInfoEstatico?.TieneFirma != tecnicoInfoDinamica?.TieneFirma)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CUENTA CON FIRMA (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.TieneFirma == true ? "SI" : "NO" ?? "",
                    ValorActual = tecnicoInfoDinamica?.TieneFirma == true ? "SI" : "NO" ?? "",
                    EsConforme = false,
                });
            }
            if (tecnicoInfoEstatico?.DocumentoIdentidad?.Id != tecnicoInfoDinamica?.DocumentoIdentidad?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DOC. IDENT (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.DocumentoIdentidad?.Descripcion ?? "",
                    ValorActual = tecnicoInfoDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (tecnicoInfoEstatico?.NumeroDni != tecnicoInfoDinamica?.NumeroDni)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DOC (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.NumeroDni ?? "",
                    ValorActual = tecnicoInfoDinamica?.NumeroDni ?? "",
                    EsConforme = false,
                });
            }
            if (tecnicoInfoEstatico?.Paterno?.Trim().ToUpper() != tecnicoInfoDinamica?.Paterno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO PATERNO (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.Paterno ?? "",
                    ValorActual = tecnicoInfoDinamica?.Paterno ?? "",
                    EsConforme = false,
                });
            }
            if (tecnicoInfoEstatico?.Materno?.Trim().ToUpper() != tecnicoInfoDinamica?.Materno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO MATERNO (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.Materno ?? "",
                    ValorActual = tecnicoInfoDinamica?.Materno ?? "",
                    EsConforme = false,
                });
            }
            if (tecnicoInfoEstatico?.Nombre?.Trim().ToUpper() != tecnicoInfoDinamica?.Nombre?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRES (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.Nombre ?? "",
                    ValorActual = tecnicoInfoDinamica?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (tecnicoInfoEstatico?.Fecha != tecnicoInfoDinamica?.Fecha)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA (TECNICO)",
                    ValorAnterior = tecnicoInfoEstatico?.Fecha?.ToShortDateString() ?? "",
                    ValorActual = tecnicoInfoDinamica?.Fecha?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.TieneFirma != verificadorDinamica?.TieneFirma)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "CUENTA CON FIRMA (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.TieneFirma == true ? "SI" : "NO" ?? "",
                    ValorActual = verificadorDinamica?.TieneFirma == true ? "SI" : "NO" ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.DocumentoIdentidad?.Id != verificadorDinamica?.DocumentoIdentidad?.Id)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "TIPO DOC. IDENT (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.DocumentoIdentidad?.Descripcion ?? "",
                    ValorActual = verificadorDinamica?.DocumentoIdentidad?.Descripcion ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.NumeroDni != verificadorDinamica?.NumeroDni)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "N° DOC (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.NumeroDni ?? "",
                    ValorActual = verificadorDinamica?.NumeroDni ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.Paterno?.Trim().ToUpper() != verificadorDinamica?.Paterno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO PATERNO (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.Paterno ?? "",
                    ValorActual = verificadorDinamica?.Paterno ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.Materno?.Trim().ToUpper() != verificadorDinamica?.Materno?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "APELLIDO MATERNO (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.Materno ?? "",
                    ValorActual = verificadorDinamica?.Materno ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.Nombre?.Trim().ToUpper() != verificadorDinamica?.Nombre?.Trim().ToUpper())
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NOMBRES (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.Nombre ?? "",
                    ValorActual = verificadorDinamica?.Nombre ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.Fecha != verificadorDinamica?.Fecha)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "FECHA (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.Fecha?.ToShortDateString() ?? "",
                    ValorActual = verificadorDinamica?.Fecha?.ToShortDateString() ?? "",
                    EsConforme = false,
                });
            }
            if (verificadorEstatico?.NumeroRegistro != verificadorDinamica?.NumeroRegistro)
            {
                controlFichas.Add(new ControlFichaDto()
                {
                    IdFicha = dinamica.Ficha.IdFicha,
                    IdUnidadCatastral = dinamica.Ficha.IdUnidadCatastral,
                    NombreFicha = NombreFicha,
                    NombreTab = NombreTab,
                    NombreCampo = "NÚMERO DE REGISTRO (VERIFICADOR)",
                    ValorAnterior = verificadorEstatico?.NumeroRegistro ?? "",
                    ValorActual = verificadorDinamica?.NumeroRegistro ?? "",
                    EsConforme = false,
                });
            }

            #endregion

            return controlFichas;
        }
    }
}
