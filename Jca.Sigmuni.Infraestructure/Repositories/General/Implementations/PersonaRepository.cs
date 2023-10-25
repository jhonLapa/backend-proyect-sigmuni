using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Persona> _paginator;

        public PersonaRepository(ApplicationDbContext context, IPaginator<Persona> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Persona> Create(Persona entity)
        {
            _context.Personas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Persona?> Edit(int id, Persona entity)
        {
            var model = await _context.Personas.FindAsync(id);

            if (model != null)
            {
                model.NumeroDoc = entity.NumeroDoc;
                model.NumeroRuc = entity.NumeroRuc;
                model.Nombre = entity.Nombre;

                _context.Personas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<bool?> EditPersona(Persona entity)
        {
         
            _context.Update(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<Persona?> Disable(int id)
        {
            var model = await _context.Personas.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Personas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Persona?> Find(int id)
        => await _context.Personas
            .Include(x => x.TipoPersona)
            .Include(x => x.EstadoCivil)
            .Include(x => x.Usuario)
            .Include(x => x.Domicilio).ThenInclude(e=>e.TipoVia)
            .Include(x => x.Domicilio).ThenInclude(e=>e.HabilitacionUrbana)
            .Include(x => x.Domicilio).ThenInclude(e => e.Edificacion)
            .Include(x => x.Domicilio).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoAgrupacion)
            .Include(x => x.Domicilio).ThenInclude(e => e.Via)
            .Include(x => x.Domicilio).ThenInclude(e => e.Ubigeo)
            .Include(x => x.InfoContacto)
            .Include(x=> x.ExoneracionTitulares)
            .Include(x => x.ExoneracionTitulares).ThenInclude(e=>e.CondicionEspecialTitular)
            .Include(x => x.ExoneracionTitulares).ThenInclude(e => e.TipoExoneracion)
            .Include(x=> x.RepresentanteLegalDD)
            .Include(x=> x.CategoriaOrganizacion)
            .Include(x => x.DocumentoIdentidad).DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.Id.Equals(id));

        //FindAsync(id);

        public async Task<IList<Persona>> FindAll()
        => await _context.Personas
            .Include(x =>x.TipoPersona )
            .Include(x => x.EstadoCivil)
            .Include(x => x.DocumentoIdentidad)
            .Include(x => x.Usuario)
            .Include(x => x.RepresentanteLegalDD)
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Persona>> PaginatedSearch(RequestPagination<Persona> entity)
        {

            var filter = entity.Filter;
            var query = _context.Personas
            .Include(x => x.TipoPersona)
            .Include(x => x.EstadoCivil)
            .Include(x => x.Usuario)
            .Include(x => x.Domicilio.Where(x => x.Estado == true))
            .Include(x => x.DocumentoIdentidad).AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    &&(!filter.IdTipoPersona.HasValue||e.IdTipoPersona== filter.IdTipoPersona)
                    && (string.IsNullOrWhiteSpace(filter.NumeroDoc) || e.NumeroDoc.ToUpper().Contains(filter.NumeroDoc.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.NumeroRuc) || e.NumeroRuc.ToUpper().Contains(filter.NumeroRuc.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Paterno) || e.Paterno.ToUpper().Contains(filter.Paterno.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Materno) || e.Materno.ToUpper().Contains(filter.Materno.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.RazonSocial) || e.RazonSocial.ToUpper().Contains(filter.RazonSocial.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }

        public async Task<bool> BusquedaPersonaPorNumDoc(string numeroDoc)
        {
            var res = false;
            var response=await _context.Personas.Where(x => x.NumeroDoc==numeroDoc).FirstOrDefaultAsync();
            if(response != null)
            {
                res = true;
            }
            return res;
        }

        public async Task<bool> BusquedaPersonaPorNumRuc(string numeroRuc)
        {
            var res = false;
            var response = await _context.Personas.Where(x => x.NumeroRuc==numeroRuc).FirstOrDefaultAsync();
            if (response != null)
            {
                res = true;
            }
            return res;
        }
    }
}
