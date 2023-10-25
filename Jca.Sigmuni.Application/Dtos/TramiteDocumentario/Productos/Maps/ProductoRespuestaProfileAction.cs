using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos.Maps
{
    public class ProductoRespuestaProfileAction : IMappingAction<Producto, ProductoRespuestaDto>
    {
        public void Process(Producto source, ProductoRespuestaDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;

            //if (source.Solicitud != null)
            //{
            //    destination.Solicitud = context.Mapper.Map<SolicitudDto>(source.Solicitud);
            //}
        }
    }
}
