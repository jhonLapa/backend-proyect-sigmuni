using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class InfoContactoService : IInfoContactoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IInfoContactoRepository _infoContactoRepository;
        public InfoContactoService(IMapper mapper, IInfoContactoRepository infoContactoRepository,ApplicationDbContext context) 
        {
            _context= context;
            _mapper = mapper;
            _infoContactoRepository = infoContactoRepository;
        }

        public async Task<InfoContactoDto> CrearInfoContacto(InfoContactoDto entity, int idPersona, int? idTipoPersona)
        {
            var entidad = await _context.InfoContactos.FindAsync(entity.Id);
            if (entidad == null)
            {
                entidad = new InfoContacto();
            }
            entidad.Telefono = entity.Telefono;
            entidad.Correo = entity.Correo;
            entidad.Fax = entity.Fax;
            entidad.Anexo = entity.Anexo;
            entidad.IdPersona= idPersona;
            entidad.IdTipoPersona= idTipoPersona;
            if(entity.Id==0) 
            { 
                _context.InfoContactos.Add(entidad);
            }
            else
            {
                _context.InfoContactos.Update(entidad);
            }
            await _context.SaveChangesAsync();
            var response =_mapper.Map<InfoContacto>(entidad);
            return _mapper.Map<InfoContactoDto>(response);

        }

        public async Task<InfoContactoDto> Create(InfoContactoFormDto dto)
        {
            var entity = _mapper.Map<InfoContacto>(dto);
            var response = await _infoContactoRepository.Create(entity);

            return _mapper.Map<InfoContactoDto>(response);
        }

        public Task<InfoContactoDto?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InfoContactoDto?> Edit(int id, InfoContactoFormDto dto)
        {
            var entity = _mapper.Map<InfoContacto>(dto);
            var response = await _infoContactoRepository.Edit(id, entity);

            return _mapper.Map<InfoContactoDto>(response);
        }

        public async Task<InfoContactoDto?> Find(int id)
        {
            var response = await _infoContactoRepository.Find(id);

            return _mapper.Map<InfoContactoDto>(response);
        }

        public async Task<IList<InfoContactoDto>> FindAll()
        {
            var response = await _infoContactoRepository.FindAll();

            return _mapper.Map<IList<InfoContactoDto>>(response);
        }

        public async Task<ResponsePagination<InfoContactoDto>> PaginatedSearch(RequestPagination<InfoContactoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<InfoContacto>>(dto);
            var response = await _infoContactoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InfoContactoDto>>(response);
        }
    }
}
