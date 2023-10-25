using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CotitularesCatastrales.Maps
{
    public class CotitularCatastralProfileAction : IMappingAction<TitularCatastral, CotitularCatastralDto>
    {
        public void Process(TitularCatastral source, CotitularCatastralDto destination, ResolutionContext context)
        {
            if(source.CaracteristicaTitularidad != null)
            {
                destination.CaracteristicaTitularidad = context.Mapper.Map<CaracteristicaTitularidadDto>(source.CaracteristicaTitularidad);
                if(source.Persona != null)
                {
                    destination.Titular = context.Mapper.Map<PersonaTitularDto>(source.Persona);
                    destination.Titular.IdTitularCatastral = source.IdTitularCatastral;
                    destination.Titular.CodigoContribuyente = source.CodContribuyente;
                    destination.Titular.NumTitularidad = source.NumTitularidad;
                    //destination.Titular.NumeroDni = source.n
                    if(source.Persona.Domicilio != null && source.Persona.Domicilio.Count > 0)
                    {
                        destination.DomicilioTitular = context.Mapper.Map<DomicilioTitularCatastralDto>(source.Persona.Domicilio.FirstOrDefault());
                    }
                }
            }
        }
    }
}
