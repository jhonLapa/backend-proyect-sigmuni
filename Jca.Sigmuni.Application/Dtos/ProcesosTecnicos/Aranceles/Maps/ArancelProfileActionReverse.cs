using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles.Maps
{
    public class ArancelProfileActionReverse : IMappingAction<ArancelDto, ArancelBusqueda>
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IManzanaRepository _manzanaRepository;
        private readonly IViaRepository _viaRepository;
        public ArancelProfileActionReverse(ISectorRepository sectorRepository, IManzanaRepository manzanaRepository, IViaRepository viaRepository)
        {
            _sectorRepository = sectorRepository;
            _manzanaRepository = manzanaRepository;
            _viaRepository = viaRepository;

        }
        public void Process(ArancelDto source, ArancelBusqueda destination, ResolutionContext context)
        {

            if (!string.IsNullOrWhiteSpace(source.CodSector))
            {
                var Sector = _sectorRepository.BuscarPorCodigoAsync(source.CodSector);
                if (Sector.Result != null)
                {
                    destination.IdSector = Sector.Result.Id;
                    if (!string.IsNullOrWhiteSpace(source.CodManzana))
                    {
                        var Manzana  = _manzanaRepository.BuscarPorIdSectorYCodManzanaAsync(Sector.Result.Id, source.CodManzana);
                        if (Manzana.Result != null) destination.IdManzana = Manzana.Result.Id;
                        

                    }

                }

            }

            if (!string.IsNullOrWhiteSpace(source.CodVia))
            {
                var Via = _viaRepository.BuscarPorCodigoViaAsync(source.CodVia);
                if (Via.Result != null)
                {
                    destination.IdVia = Via.Result.IdVia;
                }

            }


        }
    }
}
