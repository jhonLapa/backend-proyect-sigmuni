using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Categorias.Maps
{
    public class CategoriaProfile:Profile
    {
        public CategoriaProfile() {
            CreateMap<Categoria, CategoriasDto>();
            CreateMap<Categoria, CategoriasDto>().ReverseMap();

            CreateMap<RequestPagination<Categoria>, RequestPagination<CategoriasDto>>().ReverseMap();
            CreateMap<ResponsePagination<Categoria>, ResponsePagination<CategoriasDto>>();
        }
    }
}
