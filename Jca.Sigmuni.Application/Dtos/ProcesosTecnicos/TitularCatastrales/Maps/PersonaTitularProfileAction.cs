using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales.Maps
{
    public class PersonaTitularProfileAction : IMappingAction<Persona, PersonaTitularDto>
    {
        public void Process(Persona source, PersonaTitularDto destination, ResolutionContext context)
        {
            destination.IdPersona = source.Id;
            destination.NumeroDni = source.NumeroDoc;
            destination.NumeroRuc = source.NumeroRuc;
            if (source.TipoPersona != null)
            {
                destination.TipoPersona = context.Mapper.Map<TipoPersonaDto>(source.TipoPersona);
            }

            if(source.InfoContacto.Count > 0)
            {
                destination.Contacto = context.Mapper.Map<InfoContactoPersonaDto>(source.InfoContacto.FirstOrDefault());
            }
        }
    }
}
