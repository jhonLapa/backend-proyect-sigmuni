using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Implementations;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class DocumentoService : IDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IMapper mapper, IDocumentoRepository documentoRepository)
        {
            _mapper = mapper;
            _documentoRepository = documentoRepository;
        }

        public async Task<DocumentoB64Dto> Create(DocumentoB64FormDto dto)
        {
            var documento = new Documento();

            var base64 = "";
            byte[]? imageBytes = null;

            var arr = (dto.MineType).Split("/");

            if (dto.Contenido != "")
            {
                base64 = (dto.Contenido).Replace("data:" + dto.MineType + ";base64,", ""); //application/pdf
                imageBytes = Convert.FromBase64String(base64);
            }

            documento.Nombre = (DateTime.UtcNow).ToFileTime().ToString();
            documento.Descripcion = dto.Descripcion;
            documento.Contenido = imageBytes;
            documento.MineType = dto.MineType;
            documento.Extencion = arr[1];
            documento.NombreOriginal = dto.NombreOriginal;

            var entity = _mapper.Map<Documento>(documento);
            var response = await _documentoRepository.Create(entity);

            DocumentoB64 documentoB64 = new DocumentoB64();
            documentoB64.IdDocumentoB64 = response.IdDocumento;

            documentoB64.Nombre = response.Nombre;
            documentoB64.Descripcion = response.Descripcion;
            documentoB64.MineType = response.MineType;
            documentoB64.Extencion = response.Extencion;
            documentoB64.NombreOriginal = response.NombreOriginal;
            documentoB64.UbicacionFisica = response.UbicacionFisica;

            documentoB64.Contenido = Convert.ToBase64String(response.Contenido);

            return _mapper.Map<DocumentoB64Dto>(documentoB64);

        }

        public async Task<DocumentoB64Dto?> Disable(int id)
        {
            var response = await _documentoRepository.Disable(id);

            return _mapper.Map<DocumentoB64Dto>(response);
        }

        public async Task<DocumentoB64Dto?> Edit(int id, DocumentoB64FormDto dto)
        {
            var documento = new Documento();

            var base64 = "";
            byte[]? imageBytes = null;

            var arr = (dto.MineType).Split("/");

            if (dto.Contenido != "")
            {
                base64 = (dto.Contenido).Replace("data:" + dto.MineType + ";base64,", ""); //application/pdf
                imageBytes = Convert.FromBase64String(base64);
            }

            documento.Nombre = (DateTime.UtcNow).ToFileTime().ToString();
            documento.Descripcion = dto.Descripcion;
            documento.Contenido = imageBytes;
            documento.MineType = dto.MineType;
            documento.Extencion = arr[1];
            documento.NombreOriginal = dto.NombreOriginal;

            var entity = _mapper.Map<Documento>(dto);
            var response = await _documentoRepository.Edit(id, entity);

            return _mapper.Map<DocumentoB64Dto>(response);
        }

        public async Task<DocumentoB64Dto?> Find(int id)
        {
            var response = await _documentoRepository.Find(id);
            if(response == null)
            {
                return null;
            }

                DocumentoB64 documento = new DocumentoB64();
                documento.Nombre = response?.Nombre;
                documento.Descripcion = response?.Descripcion;
                documento.MineType = response?.MineType;
                documento.Extencion = response?.Extencion;
                documento.NombreOriginal = response?.NombreOriginal;
                documento.UbicacionFisica = response?.UbicacionFisica;
                if (response.IdDocumento != null)
                {
                    documento.IdDocumentoB64 = response.IdDocumento;
                }

                if (response.Contenido != null)
                {
                    documento.Contenido = Convert.ToBase64String(response.Contenido);
                }
                return _mapper.Map<DocumentoB64Dto>(documento);

        }

        public async Task<IList<DocumentoB64Dto>> FindAll()
        {
            var response = await _documentoRepository.FindAll();

            return _mapper.Map<IList<DocumentoB64Dto>>(response);
        }

        public async Task<DocumentoDto?> FindFullDocument(int id)
        {
            var response = await _documentoRepository.Find(id);
            return _mapper.Map<DocumentoDto>(response);
        }

        public async Task<ResponsePagination<DocumentoB64Dto>> PaginatedSearch(RequestPagination<DocumentoB64Dto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Documento>>(dto);
            var response = await _documentoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<DocumentoB64Dto>>(response);
        }


    }

}
