using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ActividadTipoDocumentos
{
    public class ActividadTipoDocumentoDto
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int IdActividad { get; set; }
        public int IdTipoDocumento { get; set; }
        public int? IdDocumento { get; set; }
        public virtual ActividadDto Actividad { get; set; }
        //public virtual TipoDocumentoPresentadoDto TipoDocumento { get; set; }
    }
}
