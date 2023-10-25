using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles.Maps
{
    public class ArancelProfileAction : IMappingAction<Arancel, ArancelDto>
    {


        public void Process(Arancel source, ArancelDto destination, ResolutionContext context)
        {



            if (source.Manzana != null)
            {
                destination.Manzana = context.Mapper.Map<ManzanaDto>(source.Manzana);
                destination.CodManzana = destination.Manzana.Codigo;
                if (source.Manzana.Sector != null)
                {
                    destination.Sector = context.Mapper.Map<SectorDto>(source.Manzana.Sector);
                    destination.CodSector = destination.Sector.Codigo;
                }
            }
            if (source.Via != null)
            {
                destination.Via = context.Mapper.Map<ViaDto>(source.Via);
                destination.CodVia = destination.Via.CodVia;
                if (source.Via.TipoVia != null)
                {
                    destination.TipoVia = context.Mapper.Map<TipoViaDto>(source.Via.TipoVia);
                    destination.IdTipoVia = destination.TipoVia.IdTipoVia;
                }
            }
            

        }
    }
}
