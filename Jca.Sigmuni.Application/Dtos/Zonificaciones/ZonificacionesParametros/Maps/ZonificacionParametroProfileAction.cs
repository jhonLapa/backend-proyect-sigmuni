using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.AreaTratamientos;
using Jca.Sigmuni.Application.Dtos.General.ClasesZonificaciones;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Domain.Zonificaciones;

namespace Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros.Maps
{
    public class ZonificacionParametroProfileAction : IMappingAction<ZonificacionParametro, ZonificacionParametroDto>
    {
       

        public void Process(ZonificacionParametro source, ZonificacionParametroDto destination, ResolutionContext context)
        {

            //if (source.ParametroUrbanistico != null)
            //{
            //    destination.ParametroUrbanistico = context.Mapper.Map<ParametroUrbanisticoDto>(source.ParametroUrbanistico);
            //}

            if (source.ClaseZonificacion != null)
            {
                destination.IdClaseZonificacion = source.IdClaseZonificacion;
                destination.ClaseZonificacion = context.Mapper.Map<ClaseZonificacionDto>(source.ClaseZonificacion);
            }

            if (source.Ubigeo != null)
            {
                destination.Ubigeo = context.Mapper.Map<UbigeoDto>(source.Ubigeo);
            }

            //if (source.ZonificacionParametroNormaInteres != null)
            //{
            //    destination.ZonificacionNormaInteres = context.Mapper.Map<List<ZonificacionNormaInteresDto>>(source.ZonificacionParametroNormaInteres);
            //}

            if (source.AreaTratamiento != null)
            {
                destination.IdAreaTratamiento = source.IdAreaTratamiento;
                destination.AreaTratamiento = context.Mapper.Map<AreaTratamientoDto>(source.AreaTratamiento);
            }

        }
    }
}
