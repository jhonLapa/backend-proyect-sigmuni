using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ocupantes
{
    public class OcupanteDto
    {
        public int Id { get; set; }
        public int IdFicha { get; set; }
        public int? IdCondicionPer { get; set; }

        public virtual PersonaDto Persona { get; set; }
        public virtual CondicionPerDto CondicionPer { get; set; }
        public virtual FichaDto Ficha { get; set; }
    }
}
