using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoNormaIntereses;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos
{
    public class ProcedimientoFormDto
    {
        public string? AsuntoTramite { get; set; }
        public string? Descripcion { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTipoTramite { get; set; }
        public string? Normativa { get; set; }
        public string? PlazoResolver { get; set; }
        public string? PlazoReconsAdministrativo { get; set; }
        public string? PlazoReconsIcl { get; set; }
        public string? PlazoApelAdministrativo { get; set; }
        public string? PlazoApelIcl { get; set; }
        public string? PlazoRevAdministrativo { get; set; }
        public string? PlazoRevIcl { get; set; }
        public int? RequiereCuc { get; set; }
        public string? Codigo { get; set; }
        public int? EsParaVirtual { get; set; }
        public TipoTramiteDto? TipoTramite { get; set; }
        public UsuarioDto? Usuario { get; set; }
        public AsuntoDto? Asunto { get; set; }
        public List<ActividadDto>? Actividad { get; set; }
        public List<ProcedimientoNormaInteresDto>? ProcedimientoNormaInteres { get; set; }
    }
}
