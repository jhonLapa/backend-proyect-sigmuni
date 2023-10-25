using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;
using Jca.Sigmuni.Domain.Habilitaciones;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas.Maps
{
    public class HabilitacionUrbanaProfileAction : IMappingAction<HabilitacionUrbana, HabilitacionUrbanaDto>
    {


        public void Process(HabilitacionUrbana source, HabilitacionUrbanaDto destination, ResolutionContext context)
        {


            if (source.Ubigeo != null)
            {
                destination.Ubigeo = context.Mapper.Map<UbigeoDto>(source.Ubigeo);
            }


            if (source.TipoHabilitacionUrbana != null)
            {
                destination.TipoHabilitacionUrbana = context.Mapper.Map<TipoHabilitacionUrbanaDto>(source.TipoHabilitacionUrbana);
            }
        }
    }
}
