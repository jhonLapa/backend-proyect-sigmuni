using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class MonumentoColonialRepository: IMonumentoColonialRepository
    {
        private readonly ApplicationDbContext _context;

        public MonumentoColonialRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<MonumentoColonial?> BuscarPorIdAsync(int id)
       => await _context.MonumentoColoniales.Where(e => e.IdMonumentoColonial == id).FirstOrDefaultAsync();

        public async Task<MonumentoColonial> Create(MonumentoColonial entity)
        {
            _context.MonumentoColoniales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<MonumentoColonial?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MonumentoColonial?> Edit(int id, MonumentoColonial entity)
        {
            var model = await _context.MonumentoColoniales.FindAsync(id);

            if (model != null)
            {
                model.PatrimonioCultural = entity.PatrimonioCultural;
                model.Denominacion = entity.Denominacion;
                model.IdTipoArquitectura = entity.IdTipoArquitectura;
                model.IdUsoPredio = entity.IdUsoPredio;
                model.IdUsoOrginalPredio = entity.IdUsoOrginalPredio;
                model.NumeroPisoCifra = entity.NumeroPisoCifra;
                model.NumeroPisoLiteral = entity.NumeroPisoLiteral;
                model.IdTiempoConstruccion = entity.IdTiempoConstruccion;
                model.FechaConstruccion = entity.FechaConstruccion;
                model.AreaTerrenoTitulo = entity.AreaTerrenoTitulo;
                model.AreaTechadaVerificada = entity.AreaTechadaVerificada;
                model.AreaLibre = entity.AreaLibre;
                model.IdElementoArquitectonico = entity.IdElementoArquitectonico;
                model.OtroElementoArquitectonico = entity.OtroElementoArquitectonico;
                model.DescripcionFachada = entity.DescripcionFachada;
                model.DescripcionInterior = entity.DescripcionInterior;
                model.IdFiliacionEstilistica = entity.IdFiliacionEstilistica;
                model.OtroFiliacionEstilistica = entity.OtroFiliacionEstilistica;
                model.IdCimiento = entity.IdCimiento;
                model.IdMuro = entity.IdMuro;
                model.IdPiso = entity.IdPiso;
                model.IdTecho = entity.IdTecho;
                model.IdPilastra = entity.IdPilastra;
                model.IdRevestimiento = entity.IdRevestimiento;
                model.IdBalcon = entity.IdBalcon;
                model.IdPuerta = entity.IdPuerta;
                model.IdVentana = entity.IdVentana;
                model.IdReja = entity.IdReja;
                model.IdOtro = entity.IdOtro;
                model.OtroEstadoAcabado = entity.OtroEstadoAcabado;
                model.IdIntervencionInmueble = entity.IdIntervencionInmueble;
                model.ReseniaHistorica = entity.ReseniaHistorica;
                model.IdObservacion = entity.IdObservacion;
                model.IdFichaBienCultural = entity.IdFichaBienCultural;
                

                _context.MonumentoColoniales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<MonumentoColonial?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MonumentoColonial>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
