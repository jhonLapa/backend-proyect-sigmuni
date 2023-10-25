using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class FichaBusqueda
    {
        public long? Id { get; set; }
        public long? IdUnidadCatastral { get; set; }
        public long? IdFichaControl { get; set; }
        public string? IdLoteCarto { get; set; }
        public string? Anio { get; set; }
        public string? CodigoUbigeo { get; set; }
        public string? CodigoSector { get; set; }
        public string? CodigoManzana { get; set; }
        public string? CodigoLote { get; set; }
        public string? CodigoEdif { get; set; }
        public string? CodigoEnt { get; set; }
        public string? CodigoPiso { get; set; }
        public string? CodigoUnid { get; set; }
        public string? DigitoControl { get; set; }
        public string? FlagTipo { get; set; }
        public string? TipoPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Titular { get; set; }
        public string? NombreVia { get; set; }
        public string? NumeroMunicipal { get; set; }
        public string? NumeroInterior { get; set; }
        public string? HabilitacionUrbana { get; set; }
        public string? ManzanaUrbana { get; set; }
        public string? LoteUrbano { get; set; }
        public string? NumeroPartida { get; set; }
        public string? FichaActividadEconomica { get; set; }
        public string? FichaBienComun { get; set; }
        public string? FichaCotitularidad { get; set; }
        public string? FichaBienesCulturales { get; set; }
        public int? Estado { get; set; }
        public string? EstadoFicha { get; set; }
        public decimal? AreaGrafica { get; set; }
        public decimal? AreaConstruida { get; set; }
        public string? Perfil { get; set; }
    }
}
