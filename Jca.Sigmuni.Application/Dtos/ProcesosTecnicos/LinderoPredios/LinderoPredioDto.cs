using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.LinderoPredios
{
    public class LinderoPredioDto
    {
        public int Id { get; set; }
        public string? MedidaFrenteCampo { get; set; }
        public string? MedidaFrenteTitulo { get; set; }
        public string? ColindaFrenteCampo { get; set; }
        public string? ColindaFrenteTitulo { get; set; }
        public string? MedidaDerechaCampo { get; set; }
        public string? MedidaDerechaTitulo { get; set; }
        public string? ColindaDerechaCampo { get; set; }
        public string? ColindaDerechaTitulo { get; set; }
        public string? MedidaIzquierdaCampo { get; set; }
        public string? MedidaIzquierdaTitulo { get; set; }
        public string? ColindaIzquierdaCampo { get; set; }
        public string? ColindaIzquierdaTitulo { get; set; }
        public string? MedidaFondoCampo { get; set; }
        public string? MedidaFondoTitulo { get; set; }
        public string? ColindaFondoCampo { get; set; }
        public string? ColindaFondoTitulo { get; set; }
    }
}
