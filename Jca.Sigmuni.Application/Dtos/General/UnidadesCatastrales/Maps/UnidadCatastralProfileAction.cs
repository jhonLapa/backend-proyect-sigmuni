using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales.Maps
{
    public class UnidadCatastralProfileAction : IMappingAction<UnidadCatastral, UnidadCatastralDto>
    {
        public void Process(UnidadCatastral source, UnidadCatastralDto destination, ResolutionContext context)
        {
            if(source.TblCodigo!=null)
            {
                destination.TblCodigo = context.Mapper.Map<List<TblCodigoCatastralDto>>(source.TblCodigo);
            }
        }
    }
}
