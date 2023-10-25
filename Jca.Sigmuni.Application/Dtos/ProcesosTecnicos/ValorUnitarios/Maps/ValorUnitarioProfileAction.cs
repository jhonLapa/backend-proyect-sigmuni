using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionValorUnitarios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios.Maps
{
    public class ValorUnitarioProfileAction : IMappingAction<ValorUnitario, ValorUnitarioDto>
    {
        public void Process(ValorUnitario source, ValorUnitarioDto destination, ResolutionContext context)
        {
            if (source.ClasificacionValorUnitario != null)
            {
                destination.ClasificacionValorUnitario = context.Mapper.Map<ClasificacionValorUnitarioDto>(source.ClasificacionValorUnitario);
            }

            if (source.CategoriaValorUnitario != null)
            {
                destination.CategoriaValorUnitario = context.Mapper.Map<CategoriaConstruccionDto>(source.CategoriaValorUnitario);
            }

        }
    }
}
