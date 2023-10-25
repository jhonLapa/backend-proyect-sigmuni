using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ServicioBasicoRepository : IServicioBasicoRepository
    {
        private readonly ApplicationDbContext _context;

        public ServicioBasicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServicioBasico> Create(ServicioBasico entity)
        {
            _context.ServicioBasicos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<ServicioBasico?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServicioBasico?> Edit(int id, ServicioBasico entity)
        {
            var model = await _context.ServicioBasicos.FindAsync(id);

            if (model != null)
            {
                model.IdLuz = entity.IdLuz;
                model.IdAgua = entity.IdAgua;
                model.IdTelefono = entity.IdTelefono;
                model.IdDesague = entity.IdDesague;
                model.IdGas = entity.IdGas;
                model.IdInternet = entity.IdInternet;
                model.IdCable = entity.IdCable;
                model.SuministroLuz = entity.SuministroLuz;
                model.NumContratoAgua = entity.NumContratoAgua;
                model.NumTelefono = entity.NumTelefono;
                model.SuministroGas = entity.SuministroGas;
                model.Anexo = entity.Anexo;
                model.IdFicha = entity.IdFicha;

                _context.ServicioBasicos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ServicioBasico?> Find(int id)
        => await _context.ServicioBasicos.DefaultIfEmpty()
                                         .FirstOrDefaultAsync(i => i.IdServicioBasico.Equals(id));

        public Task<IList<ServicioBasico>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
