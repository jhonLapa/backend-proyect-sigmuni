using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;
using Jca.Sigmuni.Domain.Habilitaciones;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas.Maps
{
    public class HabilitacionUrbanaBusquedaProfileAction : IMappingAction<HabilitacionUrbana, HabilitacionUrbanaBusquedaDto>
    {


        public void Process(HabilitacionUrbana source, HabilitacionUrbanaBusquedaDto destination, ResolutionContext context)
        {

            if (source.TipoHabilitacionUrbana != null)
            {
                destination.TipoHabilitacionUrbana = context.Mapper.Map<TipoHabilitacionUrbanaDto>(source.TipoHabilitacionUrbana);
            }

            if (source.Ubigeo != null)
            {
                destination.Ubigeo = context.Mapper.Map<UbigeoDto>(source.Ubigeo);
            }



        }
    }
}
