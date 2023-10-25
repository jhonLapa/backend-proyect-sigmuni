using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.Perfiles;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones;
using Microsoft.IdentityModel.Tokens;

namespace Jca.Sigmuni.Application.Services.Admins.Inplementations
{
    public class DomicilioService : IDomicilioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDomicilioRepository _domicilioRepository;
        private readonly IHabilitacionUrbanaRepository _habilitacionesUrbanaRepository;
        private readonly IEdificacionService _edificacionService;
        public DomicilioService(IMapper mapper, IDomicilioRepository domicilioRepository, IHabilitacionUrbanaRepository habilitacionesUrbanaRepository, ApplicationDbContext context,IEdificacionService edificacionService)
        {
            _context= context;
            _mapper = mapper;
            _domicilioRepository = domicilioRepository;
            _habilitacionesUrbanaRepository = habilitacionesUrbanaRepository;
            _edificacionService= edificacionService;
        }
        public async Task<DomicilioDto> Create(DomicilioFormDto dto)
        {
            var entity = _mapper.Map<Domicilio>(dto);
            var response = await _domicilioRepository.Create(entity);

            return _mapper.Map<DomicilioDto>(response);
        }

        public async Task<DomicilioDto?> Disable(int id)
        {
            var response = await _domicilioRepository.Disable(id);

            return _mapper.Map<DomicilioDto>(response);
        }

        public async Task<DomicilioDto?> Edit(int id, DomicilioFormDto dto)
        {
            var entity = _mapper.Map<Domicilio>(dto);
            var response = await _domicilioRepository.Edit(id, entity);

            return _mapper.Map<DomicilioDto>(response);
        }

        public async Task<DomicilioDto?> Find(int id)
        {
            var response = await _domicilioRepository.Find(id);

            return _mapper.Map<DomicilioDto>(response);
        }

        public async Task<IList<DomicilioDto>> FindAll()
        {
            var response = await _domicilioRepository.FindAll();

            return _mapper.Map<IList<DomicilioDto>>(response);
        }

        public async Task<ResponsePagination<DomicilioDto>> PaginatedSearch(RequestPagination<DomicilioDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Domicilio>>(dto);
            var response = await _domicilioRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<DomicilioDto>>(response);
        }

        public async Task<int> CrearOActualizarDomicilioTitularAsync(DomicilioTitularCatastralDto peticion)
        {
            

            var id = peticion.Id;

            var domicilio = await _domicilioRepository.BuscarPorIdAsync(id);

            if (domicilio == null)
            {
                domicilio = new Domicilio();
            }

            var idTipoInterior = new int?();
            var idVia = default(string);
            var idHabilitacionUrbana = new int?();

            if (peticion.TipoInterior != null)
            {
                idTipoInterior = peticion.TipoInterior.IdTipoInterior != 0 ? peticion.TipoInterior.IdTipoInterior : new int?();
            }

            if (peticion.Via != null)
            {
                idVia = !string.IsNullOrWhiteSpace(peticion.Via.IdVia) ? peticion.Via.IdVia : null;
            }

            if (peticion.HabilitacionesUrbanas != null)
            {
                //idHabilitacionUrbana = !string.IsNullOrWhiteSpace(peticion.HabilitacionesUrbanas.Id) ? RijndaelUtilitario.DecryptRijndaelFromUrl<long>(peticion.HabilitacionesUrbanas.Id) : new long?();
                if (peticion.HabilitacionesUrbanas.IdHabilitacionUrbana != 0)
                {
                    idHabilitacionUrbana = peticion.HabilitacionesUrbanas.IdHabilitacionUrbana;
                }
                else if (!string.IsNullOrWhiteSpace(peticion.HabilitacionesUrbanas.IdHUCarto))
                {
                    var habilitacionUrbana = await _habilitacionesUrbanaRepository.BuscarPorIdHUCartoAsync(peticion.HabilitacionesUrbanas.IdHUCarto);
                    if (habilitacionUrbana != null) idHabilitacionUrbana = habilitacionUrbana.IdHabilitacionUrbana;
                }
            }

            var idEdificacion = peticion.Edificacion.IdEdificacion;

            domicilio.NumMunicipal = peticion.NumMunicipal;
            domicilio.LtPrincipal = peticion.LtPrincipal;
            domicilio.IdTipoInterior = idTipoInterior;
            domicilio.NumInterior = peticion.NumeroInterior;
            domicilio.IdEdificacion = idEdificacion;
            domicilio.CasillaPostal = peticion.CasillaPostal;
            //domicilio.IdVia = idVia;
            domicilio.CodigoUbigeo = peticion.Ubigeo != null ? peticion.Ubigeo.Codigo : null;
            domicilio.LtSecundario = peticion.LtSecundario;
            domicilio.IdHabilitacionUrbana = idHabilitacionUrbana;
            domicilio.IdPersona = peticion.IdPersona;
            domicilio.IdPuerta = peticion.IdPuerta == 0 ? null :peticion.IdPuerta;

            var response = 0;
            if (domicilio.IdDomicilio == 0)
            {
                var entity = await _domicilioRepository.Create(domicilio);
                response = entity.IdDomicilio;
            }
            else
            {
                await _domicilioRepository.Edit(domicilio.IdDomicilio, domicilio);
                response = domicilio.IdDomicilio;
            }
           // await _domicilioRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }

        public async Task<int> CrearOActualizarDomicilioConductorAsync(DomicilioConductorDto peticion)
        {
            

            var id = peticion.IdDomicilioConductor;

            var domicilio = await _domicilioRepository.BuscarPorIdAsync(id);

            if (domicilio == null)
            {
                domicilio = new Domicilio();
            }

            var idTipoInterior = new int?();
            var idVia = default(string);
            var idHabilitacionUrbana = new int?();

            if (peticion.TipoInterior != null)
            {
                idTipoInterior = peticion.TipoInterior.IdTipoInterior != 0 ? peticion.TipoInterior.IdTipoInterior : new int?();
            }

            if (peticion.Via != null)
            {
                idVia = !string.IsNullOrWhiteSpace(peticion.Via.IdVia) ? peticion.Via.IdVia : null;
            }

            if (peticion.HabilitacionesUrbanas != null)
            {
                //idHabilitacionUrbana = !string.IsNullOrWhiteSpace(peticion.HabilitacionesUrbanas.Id) ? RijndaelUtilitario.DecryptRijndaelFromUrl<long>(peticion.HabilitacionesUrbanas.Id) : new long?();
                if (peticion.HabilitacionesUrbanas.IdHabilitacionUrbana != 0)
                {
                    idHabilitacionUrbana = peticion.HabilitacionesUrbanas.IdHabilitacionUrbana;
                }
                else if (!string.IsNullOrWhiteSpace(peticion.HabilitacionesUrbanas.IdHUCarto))
                {
                    var habilitacionUrbana = await _habilitacionesUrbanaRepository.BuscarPorIdHUCartoAsync(peticion.HabilitacionesUrbanas.IdHUCarto);
                    if (habilitacionUrbana != null) idHabilitacionUrbana = habilitacionUrbana.IdHabilitacionUrbana;
                }
            }

            var idEdificacion = peticion.Edificacion.IdEdificacion;

            domicilio.NumMunicipal = peticion.NumMunicipal;
            domicilio.LtPrincipal = peticion.LtPrincipal;
            domicilio.IdTipoInterior = idTipoInterior;
            domicilio.NumInterior = peticion.NumeroInterior;
            domicilio.IdEdificacion = idEdificacion;
            domicilio.CasillaPostal = peticion.CasillaPostal;
            //domicilio.IdVia = idVia;
            domicilio.CodigoUbigeo = peticion.Ubigeo != null ? peticion.Ubigeo.Codigo : null;
            domicilio.LtSecundario = peticion.LtSecundario;
            domicilio.IdHabilitacionUrbana = idHabilitacionUrbana;
            domicilio.IdPersona = peticion.IdPersona == 0 ? null: peticion.IdPersona;
            domicilio.IdPuerta = peticion.IdPuerta == 0 ? 0 : peticion.IdPuerta;

            var response = 0;
            if (domicilio.IdDomicilio == 0)
            {
               var entity = await _domicilioRepository.Create(domicilio);
                response = entity.IdDomicilio;
            }
            else
            {
                var entity = await _domicilioRepository.Edit(domicilio.IdDomicilio,domicilio);
                response = entity.IdDomicilio;
            }

            //await _domicilioRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }

        public async Task<DomicilioDto> CrearDomicilo(DomicilioDto entity, int idPersona)
        {
            var entidad = await _context.Domicilios.FindAsync(entity.IdDomicilio);
            if(entidad== null)
            {
                entidad = new Domicilio();
            }
            if(entity.Ubigeo!=null)
            {
                entidad.CodigoUbigeo = entity.Ubigeo.Codigo;
            }

            entidad.NumMunicipal = entity.NumMunicipal;
            entidad.NumInterior= entity.NumInterior;
            if(entity.HabilitacionUrbana!=null)
            {
                entidad.IdHabilitacionUrbana = entity.HabilitacionUrbana.IdHabilitacionUrbana;
            }

            if (entity.Edificacion != null) 
            {
                var responseDomicilio= await _edificacionService.CrearOActualizarAsync(entity.Edificacion);
                if (responseDomicilio !=null)
                {
                    entidad.IdEdificacion = responseDomicilio.IdEdificacion;
                }
            }
            if(entity.Via!= null)
            {
                entidad.IdVia = entity.Via.IdVia;
            }
            if(entity.TipoVia!= null)
            {
                entidad.IdTipoVia=entity.TipoVia.IdTipoVia;
            }
           
            entidad.IdPersona = idPersona;
            if (entity.IdDomicilio== 0)
            {
                _context.Domicilios.Add(entidad);
            }
            else
            {
                _context.Domicilios.Update(entidad);
            }
            await _context.SaveChangesAsync();
            var response = _mapper.Map<Domicilio>(entidad);
            return _mapper.Map<DomicilioDto>(response);
        }

        public async Task<DomicilioDto> ObtenerPorIdPersonaAsync(int idPersona)
        {
            var response= await _domicilioRepository.BusquedaSimplePorIdPersonaAsync(idPersona);
            return _mapper.Map<DomicilioDto>(response);
        }
    }
}
