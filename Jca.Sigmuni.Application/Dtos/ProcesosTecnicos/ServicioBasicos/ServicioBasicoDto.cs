using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos
{
    public class ServicioBasicoDto
    {
        public int IdServicioBasico { get; set; }

        public string? SuministroLuz { get; set; }
        public string? NumContratoAgua { get; set; }
        public string? NumTelefono { get; set; }
        public string? SuministroGas { get; set; }
        public string? Anexo { get; set; }

        public string? IdLuz { get; set; }
        public string? IdAgua { get; set; }
        public string? IdTelefono { get; set; }
        public string? IdDesague { get; set; }
        public string? IdGas { get; set; }
        public string? IdInternet { get; set; }
        public string? IdCable { get; set; }


        public TipoServicioBasicoDto? Luz { get; set; }
        public TipoServicioBasicoDto? Agua { get; set; }
        public TipoServicioBasicoDto? Telefono { get; set; }
        public TipoServicioBasicoDto? Desague { get; set; }
        public TipoServicioBasicoDto? Gas { get; set; }
        public TipoServicioBasicoDto? Internet { get; set; }
        public TipoServicioBasicoDto? Cable { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
