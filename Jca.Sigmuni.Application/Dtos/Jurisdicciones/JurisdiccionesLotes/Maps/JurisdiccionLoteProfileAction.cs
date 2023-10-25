using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Domain.Jurisdiccion;

namespace Jca.Sigmuni.Application.Dtos.Jurisdicciones.JurisdiccionesLotes.Maps
{
    public class JurisdiccionLoteProfileAction : IMappingAction<JurisdiccionLote, JurisdiccionLoteDto>
    {
        public void Process(JurisdiccionLote source, JurisdiccionLoteDto destination, ResolutionContext context)
        {
            

            if (destination.Ubigeo != null)
            {
                destination.Ubigeo = context.Mapper.Map<UbigeoDto>(source.Ubigeo);
            }
            if (destination.Lote != null)
            {
                destination.Lote = context.Mapper.Map<LoteDto>(source.Lote);
            }

        }


    }
}
