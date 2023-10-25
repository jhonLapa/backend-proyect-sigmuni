using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos.Maps
{
    public class ProductoProfileAction : IMappingAction<Producto, ProductoDto>
    {
        public void Process(Producto source, ProductoDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;

            if (source.IdDocumento != null)
            {
                destination.IdDocumento = source.IdDocumento;
            }
        }
    }
}
