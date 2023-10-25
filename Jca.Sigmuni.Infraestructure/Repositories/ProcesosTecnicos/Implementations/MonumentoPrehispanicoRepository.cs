using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class MonumentoPrehispanicoRepository : IMonumentoPrehispanicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MonumentoPrehispanicoRepository(ApplicationDbContext context, IPaginator<MonumentoPrehispanico> paginator)
        {
            _context = context;

        }
        public async Task<MonumentoPrehispanico?> BuscarPorIdAsync(int id)
        => await _context.MonumentoPrehispanicos.Where(e => e.IdMonumentoPrehispanico == id).FirstOrDefaultAsync();

        public async Task<MonumentoPrehispanico> Create(MonumentoPrehispanico entity)
        {
            _context.MonumentoPrehispanicos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<MonumentoPrehispanico?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MonumentoPrehispanico?> Edit(int id, MonumentoPrehispanico entity)
        {
            var model = await _context.MonumentoPrehispanicos.FindAsync(id);

            if (model != null)
            {
                model.IdTipoMaterial = entity.IdTipoMaterial;
                model.IdTipoArquitectura = entity.IdTipoArquitectura;
                model.PresenciaArquitectura = entity.PresenciaArquitectura;
                model.IdFiliacionCronologica = entity.IdFiliacionCronologica;
                model.Perimetro = entity.Perimetro;
                model.IdUnidadMedida = entity.IdUnidadMedida;
                model.Area = entity.Area;
                model.Nombre = entity.Nombre;
                model.Codigo = entity.Codigo;
                model.IdCategoriaInmueble = entity.IdCategoriaInmueble;
                model.OtroTipoMaterial = entity.OtroTipoMaterial;
                model.IdAfectacionNatural = entity.IdAfectacionNatural;
                model.OtroAfectacionNatural = entity.OtroAfectacionNatural;
                model.IdAfectacionAntropica = entity.IdAfectacionAntropica;
                model.OtroAfectacionAntropica = entity.OtroAfectacionAntropica;
                model.IdIntervencionConservacion = entity.IdIntervencionConservacion;
                model.IdObservacion = entity.IdObservacion;
                model.ObservacionOtros = entity.ObservacionOtros;
                model.IdFichaBienCultural = entity.IdFichaBienCultural;
                


                _context.MonumentoPrehispanicos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<MonumentoPrehispanico?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MonumentoPrehispanico>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
