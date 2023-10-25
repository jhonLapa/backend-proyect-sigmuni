using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Documentos
{
    public class DocumentoDto
    {
        public int IdDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public byte[]? Contenido { get; set; }
        public string? MineType { get; set; }
        public string? Extencion { get; set; }
        public string? NombreOriginal { get; set; }
        public string? UbicacionFisica { get; set; }
    }
}
