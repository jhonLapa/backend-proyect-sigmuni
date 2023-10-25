using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes.Maps
{
    internal class LitiganteProfileAction : IMappingAction<Litigante, PersonaLitiganteDto>
    {
        public void Process(Litigante source, PersonaLitiganteDto destination, ResolutionContext context)
        {
            if (source.Persona != null)
            {
                destination.IdPersonaLitigante = source.Persona.Id;
                destination.IdPersona = source.Persona.Id;

                destination.NumeroDni = source.Persona.NumeroDoc;
                destination.Nombre = source.Persona.Nombre;
                destination.Paterno = source.Persona.Paterno;
                destination.Materno = source.Persona.Materno;
                destination.CodigoContribuyenteSat = source.Persona?.CodigoContribuyente;

                if (source.Persona.TipoPersona != null)
                {
                    destination.TipoPersona = context.Mapper.Map<TipoPersonaDto>(source.Persona.TipoPersona);
                }

                if (source.Persona.DocumentoIdentidad != null)
                {
                    destination.DocumentoIdentidad = context.Mapper.Map<DocumentoIdentidadDto>(source.Persona.DocumentoIdentidad);
                }

                if (source.Persona.EstadoCivil != null)
                {
                    destination.EstadoCivil = context.Mapper.Map<EstadoCivilDto>(source.Persona.EstadoCivil);
                }

            }
        }
    }
}
