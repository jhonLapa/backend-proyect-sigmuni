using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using System.Drawing;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class PersonaService : IPersonaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersonaRepository _personaRepository;
        private readonly IExoneracionTitularService _exoneracionTitularService;

        public PersonaService(IMapper mapper, IPersonaRepository personaRepository,ApplicationDbContext context, IExoneracionTitularService exoneracionTitularService)
        {
            _context = context;
            _mapper = mapper;
            _personaRepository = personaRepository;
            _exoneracionTitularService = exoneracionTitularService;
        }

        public async Task<PersonaDto> Create(PersonaFormDto dto)
        {

            var entity = _mapper.Map<Persona>(dto);
            var response = await _personaRepository.Create(entity);

            return _mapper.Map<PersonaDto>(response);

        }


        public async Task<bool> EditPersona(int id, PersonaFormDto requestDto)
        {
        
            //var personaId = await Find(id);

        

            var entity = _mapper.Map<Persona>(requestDto);
            entity.Id = id;


            var response = await  _personaRepository.EditPersona(entity);


            return _mapper.Map<bool>(response);
        }

        public async Task<PersonaDto?> Disable(int id)
        {
            var response = await _personaRepository.Disable(id);

            return _mapper.Map<PersonaDto>(response);
        }

        public async Task<PersonaDto?> Edit(int id, PersonaFormDto dto)
        {
            var entity = _mapper.Map<Persona>(dto);
            var response = await _personaRepository.Edit(id, entity);

            return _mapper.Map<PersonaDto>(response);
        }

        public async Task<PersonaDto?> Find(int id)
        {
            var response = await _personaRepository.Find(id);

            return _mapper.Map<PersonaDto>(response);
        }

        public async Task<IList<PersonaDto>> FindAll()
        {
            var response = await _personaRepository.FindAll();

            return _mapper.Map<IList<PersonaDto>>(response);
        }

        public async Task<ResponsePagination<PersonaDto>> PaginatedSearch(RequestPagination<PersonaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Persona>>(dto);
            var response = await _personaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<PersonaDto>>(response);
        }

        public async Task<PersonaDto> CrearPersona(PersonaFormDto entity)
        {
            var entidad =await _context.Personas.FindAsync(entity.Id);
            if(entidad==null)
            {
                entidad = new Persona();
            }
            if(entity.DocumentoIdentidad!=null)
            {
                entidad.IdDocIdentidad = entity.DocumentoIdentidad.Id;
            }    
            entidad.NumeroDoc = entity.NumeroDoc;
            entidad.NumeroRuc = entity.NumeroRuc;
            entidad.Nombre= entity.Nombre;
            entidad.Materno= entity.Materno;
            entidad.Paterno= entity.Paterno;
            entidad.RazonSocial= entity.RazonSocial;
            entidad.IdTipoPersona = entity.TipoPersona.Id;
            if(entity.CategoriaOrganizacion!=null)
            {
                entidad.IdCategoriaOrganizacion = entity.CategoriaOrganizacion.IdCategoriaOrganizacion;
            }
            if (entity.EstadoCivil != null)
            {
                entidad.IdEstadoCivil = entity.EstadoCivil.Id;
            }
            if (entity.RepresentanteLegal != null)
            {
                entidad.IdRepresentanteLegal = entity.RepresentanteLegal.Id;
            }
            entidad.CodigoContribuyente= entity.CodigoContribuyente;

            if (entity.Id == 0)
            {
                _context.Personas.Add(entidad);
            }
            else
            {
                _context.Personas.Update(entidad);
            }
            await _context.SaveChangesAsync();
            var response = _mapper.Map<PersonaDto>(entidad);
            if(response.Id!=0)
            {
                if (entity.ExoneracionTitular != null)
                {
                   var res = await _exoneracionTitularService.CrearExoneracion(entity.ExoneracionTitular, response.Id);
                    if (res!=null)
                    {
                        entidad.Id=response.Id;
                        entidad.IdExoneracionTitular = res.IdExoneracionTitular;
                        _context.Personas.Update(entidad);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return _mapper.Map<PersonaDto>(response);


        }

        public async Task<bool> BusquedaPersonaPorNumDoc(string numeroDoc)
        {
            
            var response = await _personaRepository.BusquedaPersonaPorNumDoc(numeroDoc);

            return response;
        }

        public async Task<bool> BusquedaPersonaPorNumRuc(string numeroRuc)
        {

            var response = await _personaRepository.BusquedaPersonaPorNumRuc(numeroRuc);

            return response;
        }
    }

}
