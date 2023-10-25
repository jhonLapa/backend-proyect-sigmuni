using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Core.Security.Services.Abstractions;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Usuario> _paginator;
        private readonly ISecurityService _securityService;

        public UsuarioRepository(ApplicationDbContext context, IPaginator<Usuario> paginator, ISecurityService securityService)
        {
            _context = context;
            _paginator = paginator;
            _securityService = securityService;
        }

        public async Task<Usuario> Create(Usuario entity)
        {
            var entidad =await _context.Usuarios.FindAsync(entity.Id);
            if (entidad == null)
            {
                entidad=new Usuario();
            }
            if(entity.Persona!=null)
            {
                entidad.Id = entity.Persona.Id;
            }
            if(entity.Cargo!=null)
            {
                entidad.IdCargo = entity.Cargo.Id;
            }
            if(entity.Area!=null)
            {
                entidad.IdArea= entity.Area.Id;
            }
            if (entity.Perfil != null)
            {
                entidad.IdPerfil= entity.Perfil.Id;
            }
            entidad.Clave = _securityService.HashPassword(entity.NombreUsuario, entity.Clave);
            entidad.NombreUsuario=entity.NombreUsuario;
            entidad.Estado = entity.Estado;
            if (entity.Id == 0)
            {
                _context.Usuarios.Add(entidad);
            }
            else
            {
                _context.Usuarios.Update(entidad);
            }
            
            await _context.SaveChangesAsync();

            return entidad;
        }

        public async Task<Usuario?> Disable(int id)
        {
            var model = await _context.Usuarios.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Usuarios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }


        public async Task<Usuario?> Edit(int id, Usuario entity)
        {
            var model = await _context.Usuarios.FindAsync(id);

            if (model != null)
            {
                model.NombreUsuario = entity.NombreUsuario;
                model.IdPerfil = entity.IdPerfil;
                model.TrabajadorPermanente = entity.TrabajadorPermanente;
                model.IdAreaCargo = entity.IdAreaCargo;
                model.FechaAlta = entity.FechaAlta;
                model.FechaBaja = entity.FechaBaja;
                model.IdCargo = entity.IdCargo;
                model.IdArea = entity.IdArea;

                _context.Users.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Usuario?> Find(int id)
        => await _context.Usuarios
                .Include(x => x.Area)
                .Include(x => x.Cargo)
                .Include(x => x.Perfil)
                .Include(x => x.Persona)
                .Include(x => x.Persona).ThenInclude(x=>x.DocumentoIdentidad)
                .DefaultIfEmpty()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IList<Usuario>> FindAll()
        => await _context.Usuarios
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Usuario>> PaginatedSearch(RequestPagination<Usuario> entity)
        {
            var filter = entity.Filter;
            var query = _context.Users
                .Include(x=>x.Area)
                .Include(x=>x.Cargo)
                .Include(x=>x.Perfil)
                .Include(x=>x.Persona)
                .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.NombreUsuario) || e.NombreUsuario.ToUpper().Contains(filter.NombreUsuario))
                    &&(!filter.IdArea.HasValue||e.IdArea==filter.IdArea)
                    && (!filter.IdCargo.HasValue || e.IdCargo == filter.IdCargo)
                    
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }

        public async Task<Usuario?> LoginAsync(string nombreUsuario, string clave)
        {
            var model = await _context.Usuarios.FirstOrDefaultAsync(e => e.NombreUsuario == nombreUsuario);

            if (model == null) throw new Exception("Usuario no está registrado en nuestro sistema");

            var verificationResult = _securityService.VerifyHashedPassword(nombreUsuario, model.Clave, clave);
            if (!verificationResult) throw new Exception("Su contraseña no es correcta");

            if (model.Estado == false) throw new Exception("Usuario no está activo, comuníquese con área técnica");

            return model;
        }
    }
}
