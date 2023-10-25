using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Categorias;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IList<CategoriasDto>> findAll()
        {
            var response = await _categoriaRepository.findAll();

            return _mapper.Map<IList<CategoriasDto>>(response);
        }
    }
}
