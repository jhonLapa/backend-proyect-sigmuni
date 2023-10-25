using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos.Maps
{
    public class ProductoPaginadoProfileAction : IMappingAction<Producto, ProductoPaginadoDto>
    {
        public void Process(Producto source, ProductoPaginadoDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;

            if (source.IdDocumento != null)
            {
                destination.IdDocumento = source.IdDocumento;
            }
        }
    }
}