using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Util.Flags;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class FichaRepository : IFichaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Ficha> _paginator;

        public FichaRepository(ApplicationDbContext context, IPaginator<Ficha> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Ficha?> Find(int id)
        => await _context.Fichas.Include(e => e.UbicacionPredios)
                                .Include(e => e.TitularCatastral)
                                .Include(e => e.DescripcionPredios)
                                .Include(e => e.EvaluacionPredios)
                                .Include(e => e.ServicioBasicos)
                                .Include(e => e.FichaIndividuales)
                                .Include(e => e.InfoComplementarios)
                                .Include(e => e.Declarantes)
                                .Include(e => e.Supervisores)
                                .Include(e => e.TecnicoCatastrales)
                                .Include(e => e.FichaBienCulturales).ThenInclude(x => x.MonumentoPreinspanico)
                                .Include(e => e.FichaBienCulturales).ThenInclude(x => x.MonumentoColonial)
                                .Include(e => e.Conductores)
                                .Include(e => e.AreaActividadEconomicas)
                                .DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.IdFicha.Equals(id));

        public async Task<Ficha?> ObtenerPorIdUnidadEstadoFichaIdTipoAsync(int idUnidadCatastral, EstadoFicha estadoFicha, TipoFichaEnum tipoFicha)
        {
            var response = await _context.Fichas.Where(e =>
                    e.IdUnidadCatastral == idUnidadCatastral
                    && e.Estado == (int)estadoFicha
                    && e.IdTipoFicha == (int)tipoFicha
                ).FirstOrDefaultAsync();

            return response;
        }

        public async Task<List<Ficha>> BuscarPorIdLoteCartoYIdTipoAsync(string idLoteCartografia, int idTipo)
        {
            var response = await _context.Fichas.Where(e =>
            e.Estado == 1
            && e.IdLoteCarto == idLoteCartografia
            && e.IdTipoFicha == idTipo).Include(e => e.UnidadCatastral).ToListAsync();

            return response;
        }

        public Task<ResponsePagination<Ficha>> PaginatedSearch(RequestPagination<Ficha> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Ficha> Create(Ficha entity)
        {
            _context.Fichas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<IList<Ficha>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Ficha?> Edit(int id, Ficha entity)
        {
            var model = await _context.Fichas.FindAsync(id);

            if (model != null)
            {
                model.NumExpediente = entity.NumExpediente;
                model.NtTf = entity.NtTf;
                model.NumFicha = entity.NumFicha;
                model.Dc = entity.Dc;
                model.IdTipoFicha = entity.IdTipoFicha;
                model.IdUnidadCatastral = entity.IdUnidadCatastral;
                model.IdLoteCarto = entity.IdLoteCarto;
                model.AnioFicha = entity.AnioFicha;
                model.IdFichaPadre = entity.IdFichaPadre;
                model.TipoBienComun = entity.TipoBienComun;
                model.FechaActualizacion = entity.FechaActualizacion;
                model.IdUsuario = entity.IdUsuario;

                _context.Fichas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<Ficha?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ficha?> FindByIdAsync(int id)
        => await _context.Fichas.Include(e => e.UnidadCatastral).ThenInclude(f => f.TblCodigo)
                                //.Include(e => e.UnidadCatastral).ThenInclude(f => f.ImagenPredio)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Edificacion)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Edificacion).ThenInclude(g => g.TipoAgrupacion)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Edificacion).ThenInclude(g => g.TipoEdificacion)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.HabilitacionUrbana)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.HabilitacionUrbana).ThenInclude(g => g.TipoHabilitacionUrbana)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.Via)
                                //.Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas.OrderBy(g => g.Via.Nombre).ThenBy(g => g.TipoPuerta.Codigo).ThenBy(g => g.NumeracionMunicipal))
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.TipoPuerta)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.Via).ThenInclude(h => h.TipoVia)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.TipoInterior)
                                //.Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas)//.ThenInclude(g => g.TipoNumeracion)
                                //.Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas)//.ThenInclude(g => g.TipoNumeracion2)
                                .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.CondicionNumeracion)
                                //.Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas)//.ThenInclude(g => g.CondicionNumeracion2)
                                //.Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas)//.ThenInclude(g => g.UbicacionNumeracion)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad).ThenInclude(g => g.CondicionTitular)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad).ThenInclude(g => g.FormaAdquisicion)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad).ThenInclude(g => g.ExoneracionPredio).ThenInclude(h => h.CondicionEspecialPredio)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.DocumentoIdentidad)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.EstadoCivil)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.TipoPersona)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.InfoContacto)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.TipoInterior)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Edificacion)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Edificacion).ThenInclude(e => e.TipoEdificacion)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Edificacion).ThenInclude(e => e.TipoAgrupacion)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.HabilitacionUrbana)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.HabilitacionUrbana)//.ThenInclude(e => e.TipoHabilitacionUrbana)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Via)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Via).ThenInclude(e => e.TipoVia)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Ubigeo)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.Domicilio).ThenInclude(h => h.Ubigeo)//.ThenInclude(f => f.Provincia)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(g => g.ExoneracionTitulares)
                                .Include(e => e.TitularCatastral).ThenInclude(f => f.Dependientes).ThenInclude(g => g.Persona)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.PredioCatastralEn)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.ClasificacionPredio)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.UsoPredio)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.LinderoPredio)
                                .Include(e => e.EvaluacionPredios).ThenInclude(f => f.TipoEvaluacion)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoLuz)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoAgua)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoTelefono)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoDesague)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoGas)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoInternet)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoCable)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Mep)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Ecc)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Ecs)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Uca)
                                .Include(e => e.Construcciones).ThenInclude(f => f.EdificacionIndustrial)
                                .Include(e => e.Construcciones.OrderBy(e => e.NumeroPiso).ThenBy(e => e.MesAnio))
                                .Include(e => e.FichaIndividuales).ThenInclude(f => f.TipoDeclaratoria)
                                .Include(e => e.FichaIndividuales).ThenInclude(f => f.PredioCatastralAn)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Uca)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.UnidadMedida)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.TipoOtraInstalacion)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.TipoOtraInstalacion).ThenInclude(e => e.UnidadMedida)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Ecc)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Ecs)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Mep)
                                .Include(e => e.OtraInstalaciones.OrderBy(e => e.TipoOtraInstalacion.Codigo).ThenBy(e => e.MesAnio))
                                .Include(e => e.FichaDocumentos).ThenInclude(f => f.TipoDocumentoPresentado)
                                .Include(e => e.FichaDocumentos).ThenInclude(f => f.Area)
                                .Include(e => e.Sunarps).ThenInclude(f => f.TipoPartidaRegistral)
                                .Include(e => e.Sunarps).ThenInclude(f => f.TipoTituloInscrito)
                                .Include(e => e.RegistroLegales).ThenInclude(f => f.TipoDocNotarial)
                                .Include(e => e.Ocupantes).ThenInclude(f => f.CondicionPer)
                                .Include(e => e.Ocupantes).ThenInclude(f => f.Persona).ThenInclude(e => e.TipoPersona)
                                .Include(e => e.Ocupantes).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.Litigantes).ThenInclude(f => f.Persona)
                                .Include(e => e.Litigantes).ThenInclude(f => f.Persona).ThenInclude(e => e.TipoPersona)
                                .Include(e => e.Litigantes).ThenInclude(f => f.Persona).ThenInclude(e => e.EstadoCivil)
                                .Include(e => e.Litigantes).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.Litigantes).ThenInclude(f => f.Persona).ThenInclude(e => e.CategoriaOrganizacion)
                                .Include(e => e.Litigantes)//.ThenInclude(f => f.Dependiente).ThenInclude(e => e.Persona)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.Observacion)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.TipoMantenimiento)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.EstadoLLenado)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.TipoInspeccion)
                                .Include(e => e.InfoComplementarios)//.ThenInclude(f => f.Motivo)
                                .Include(e => e.Declarantes).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.Declarantes).ThenInclude(f => f.CondicionPer)
                                .Include(e => e.Supervisores).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.TecnicoCatastrales).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.DocumentoObras).ThenInclude(f => f.TipoDocumentoObra)
                                .Include(e => e.Resoluciones).ThenInclude(f => f.TipoResolucion)
                                .Include(e => e.EvaluacionPredioCatastrales)
                                .Include(e => e.AreaTerrenoInvalids)
                                .Include(e => e.VerificadorCatastrales).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.IdFicha.Equals(id));

        public async Task<Ficha?> FindBienComunByIdAsync(int id)
        => await _context.Fichas.Include(e => e.UnidadCatastral).ThenInclude(f => f.TblCodigo)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Edificacion)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoEdificacion)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoAgrupacion)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.HabilitacionUrbana)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.HabilitacionUrbana).ThenInclude(e => e.TipoHabilitacionUrbana)
                                .Include(e => e.UbicacionPredios)//.ThenInclude(e => e.Puertas.OrderBy(e => e.Via.Nombre).ThenBy(e => e.TipoPuerta.Codigo).ThenBy(e => e.NumeracionMunicipal))
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas).ThenInclude(e => e.TipoPuerta)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.Via)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.Via).ThenInclude(e => e.TipoVia)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas).ThenInclude(e => e.TipoInterior)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.TipoNumeracion)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.TipoNumeracion2)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.CondicionNumeracion)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.CondicionNumeracion2)
                                .Include(e => e.UbicacionPredios).ThenInclude(e => e.Puertas)//.ThenInclude(e => e.UbicacionNumeracion)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.PredioCatastralEn)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.ClasificacionPredio)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.UsoPredio)
                                .Include(e => e.DescripcionPredios).ThenInclude(f => f.LinderoPredio)
                                .Include(e => e.EvaluacionPredios).ThenInclude(f => f.TipoEvaluacion)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoLuz)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoAgua)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoTelefono)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoDesague)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoGas)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoInternet)
                                .Include(e => e.ServicioBasicos).ThenInclude(f => f.TipoServicioBasicoCable)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Mep)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Ecc)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Ecs)
                                .Include(e => e.Construcciones).ThenInclude(f => f.Uca)
                                .Include(e => e.Construcciones.OrderBy(e => e.NumeroPiso).ThenBy(e => e.MesAnio))
                                .Include(e => e.FichaIndividuales).ThenInclude(e => e.TipoDeclaratoria)
                                .Include(e => e.FichaIndividuales).ThenInclude(e => e.PredioCatastralAn)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Uca)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.TipoOtraInstalacion)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.TipoOtraInstalacion).ThenInclude(e => e.UnidadMedida)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Ecc)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Ecs)
                                .Include(e => e.OtraInstalaciones).ThenInclude(f => f.Mep)
                                .Include(e => e.OtraInstalaciones.OrderBy(e => e.TipoOtraInstalacion.Codigo).ThenBy(e => e.MesAnio))
                                .Include(e => e.RecapitulacionEdificios)
                                .Include(e => e.RecapitulacionBienComunes)
                                .Include(e => e.RecapBienComunComplementarios)
                                .Include(e => e.Sunarps).ThenInclude(f => f.TipoPartidaRegistral)
                                .Include(e => e.Sunarps).ThenInclude(f => f.TipoTituloInscrito)
                                .Include(e => e.RegistroLegales).ThenInclude(e => e.TipoDocNotarial)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.Observacion)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.TipoMantenimiento)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.EstadoLLenado)
                                .Include(e => e.InfoComplementarios).ThenInclude(f => f.TipoInspeccion)
                                .Include(e => e.InfoComplementarios)//.ThenInclude(f => f.Motivo)
                                .Include(e => e.Declarantes).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.Supervisores).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.TecnicoCatastrales).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                .Include(e => e.DocumentoObras).ThenInclude(e => e.TipoDocumentoObra)
                                .Include(e => e.Resoluciones).ThenInclude(e => e.TipoResolucion)
                                .Include(e => e.AreaTerrenoInvalids)
                                .DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.IdFicha.Equals(id));

        public async Task<Ficha?> FindCotitularByIdAsync(int id)
           => await _context.Fichas.Include(e => e.UnidadCatastral).ThenInclude(f => f.TblCodigo)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad).ThenInclude(x => x.CondicionTitular)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad).ThenInclude(x => x.FormaAdquisicion)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.CaracteristicaTitularidad).ThenInclude(g => g.ExoneracionPredio).ThenInclude(h => h.CondicionEspecialPredio)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(x => x.TipoPersona)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(x => x.EstadoCivil)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(x => x.DocumentoIdentidad)
                                   .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona).ThenInclude(x => x.CategoriaOrganizacion)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.InfoContacto)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.ExoneracionTitulares).ThenInclude(e => e.CondicionEspecialTitular)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.ExoneracionTitulares).ThenInclude(e => e.TipoExoneracion)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Dependientes).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Dependientes).ThenInclude(e => e.Persona).ThenInclude(e => e.InfoContacto)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.TipoInterior)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Edificacion)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoEdificacion)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoAgrupacion)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.HabilitacionUrbana)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.HabilitacionUrbana)//.ThenInclude(e => e.TipoHabilitacionesUrbanas)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Via)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Via).ThenInclude(e => e.TipoVia)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Ubigeo)
                                   .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Ubigeo)//.ThenInclude(e => e.Provincia)
                                   .Include(e => e.Ocupantes).ThenInclude(e => e.CondicionPer)
                                   .Include(e => e.Ocupantes).ThenInclude(e => e.Persona).ThenInclude(e => e.TipoPersona)
                                   .Include(e => e.InfoComplementarios).ThenInclude(e => e.Observacion)
                                   .Include(e => e.InfoComplementarios).ThenInclude(e => e.EstadoLLenado)
                                   .Include(e => e.Declarantes).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                   .Include(e => e.Declarantes).ThenInclude(e => e.CondicionPer)
                                   .Include(e => e.Supervisores).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                   .Include(e => e.TecnicoCatastrales).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                   .DefaultIfEmpty()
                                   .FirstOrDefaultAsync(i => i.IdFicha.Equals(id));

        public Task<List<Ficha?>> FindFichasActividadesEconomicasByIdAsync(List<int> idFicha)
        {
            throw new NotImplementedException();
        }

        public async Task<Ficha?> FindFichaActividadEconomicaByIdAsync(int idFicha)
            => await _context.Fichas.Include(e => e.UnidadCatastral).ThenInclude(e => e.TblCodigo)
                                    .Include(e => e.Conductores).ThenInclude(e => e.CondicionConductor)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.RepresentanteLegalDD)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.RepresentanteLegalDD).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.RepresentanteLegalDD).ThenInclude(e => e.InfoContacto)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.TipoPersona)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.CategoriaOrganizacion)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.InfoContacto)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.TipoInterior)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Edificacion)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoEdificacion)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Edificacion).ThenInclude(e => e.TipoAgrupacion)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Via)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Via).ThenInclude(e => e.TipoVia)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.HabilitacionUrbana)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.HabilitacionUrbana).ThenInclude(e => e.TipoHabilitacionUrbana)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Ubigeo)
                                    .Include(e => e.Conductores).ThenInclude(e => e.Persona).ThenInclude(e => e.Domicilio).ThenInclude(e => e.Ubigeo)//.ThenInclude(e => e.Provincia)
                                    .Include(e => e.AreaActividadEconomicas)
                                    .Include(e => e.AutorizacionMunicipales).ThenInclude(e => e.GiroAutorizado)
                                    .Include(e => e.AutorizacionMunicipales).ThenInclude(e => e.ActividadVerificada)
                                    .Include(e => e.AutorizacionAnuncios).ThenInclude(e => e.TipoAnuncio)
                                    .Include(e => e.AutorizacionAnuncios).ThenInclude(e => e.CondicionAnuncio)
                                    .Include(e => e.InfoComplementarios).ThenInclude(e => e.Observacion)
                                    .Include(e => e.InfoComplementarios).ThenInclude(e => e.TipoMantenimiento)
                                    .Include(e => e.InfoComplementarios).ThenInclude(e => e.EstadoLLenado)
                                    //.Include(e => e.InfoComplementarios).ThenInclude(e => e.TipoDocumentoPresentado)
                                    .Include(e => e.Declarantes).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.Declarantes).ThenInclude(e => e.CondicionPer)
                                    .Include(e => e.Supervisores).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.TecnicoCatastrales).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .DefaultIfEmpty()
                                    .FirstOrDefaultAsync(i => i.IdFicha.Equals(idFicha));

        public async Task<Ficha?> FindFichaBienCulturalByIdAsync(int idFicha)
            => await _context.Fichas.Include(e => e.UnidadCatastral).ThenInclude(e => e.TblCodigo)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.CategoriaInmueble)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.UnidadMedida)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.FiliacionCronologica)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.TipoArquitectura)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.TipoMaterial)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.AfectacionNatural)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.AfectacionAntropica)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.IntervencionConservacion)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.Observacion)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.Sunarp.OrderBy(e => e.TipoPartidaRegistral.Codigo)).ThenInclude(f => f.TipoPartidaRegistral)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.Sunarp.OrderBy(e => e.TipoPartidaRegistral.Codigo)).ThenInclude(f => f.TipoTituloInscrito)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.NormaIntMonPreins)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoPreinspanico).ThenInclude(e => e.NormaIntMonPreins).ThenInclude(e => e.NormaInteres).ThenInclude(f => f.NormaDiaDetalles)//.ThenInclude(g => g.NormaDia).ThenInclude(h => h.TipoNorma)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.TipoArquitectura)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.UsoPredio)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.UsoPredioOrginal)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.TiempoConstruccion)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.ElementoArquitectonico)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.FiliacionEstilistica)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoCimiento)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoMuro)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoPiso)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoTecho)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoPilastra)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoRevestimiento)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoBalcon)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoPuerta)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoVentana)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoReja)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.EstadoOtro)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.IntervencionInmueble)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.Observacion)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.Sunarp.OrderBy(e => e.TipoPartidaRegistral.Codigo).Where(e => e.Estado == true)).ThenInclude(f => f.TipoPartidaRegistral)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.Sunarp.OrderBy(e => e.TipoPartidaRegistral.Codigo).Where(e => e.Estado == true)).ThenInclude(f => f.TipoTituloInscrito)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.NormaIntMonColonial.Where(f => f.Estado == true)).ThenInclude(e => e.NormaInteres).ThenInclude(f => f.NormaDiaDetalles)
                                    .Include(e => e.FichaBienCulturales).ThenInclude(e => e.MonumentoColonial).ThenInclude(e => e.NormaIntMonColonial.Where(f => f.Estado == true))
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.CaracteristicaTitularidad)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.CaracteristicaTitularidad).ThenInclude(e => e.CondicionTitular)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.CaracteristicaTitularidad).ThenInclude(e => e.FormaAdquisicion)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.TipoPersona)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.EstadoCivil)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.CategoriaOrganizacion)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Persona).ThenInclude(e => e.InfoContacto)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Dependientes).ThenInclude(e => e.Persona)
                                    .Include(e => e.TitularCatastral).ThenInclude(e => e.Dependientes).ThenInclude(e => e.Persona).ThenInclude(e => e.InfoContacto)
                                    .Include(e => e.Litigantes).ThenInclude(e => e.Persona)
                                    .Include(e => e.Litigantes).ThenInclude(e => e.Persona).ThenInclude(e => e.TipoPersona)
                                    .Include(e => e.Litigantes).ThenInclude(e => e.Persona).ThenInclude(e => e.EstadoCivil)
                                    .Include(e => e.Litigantes).ThenInclude(e => e.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.Litigantes).ThenInclude(e => e.Persona).ThenInclude(e => e.CategoriaOrganizacion)
                                    .Include(e => e.Litigantes).ThenInclude(e => e.Dependientes).ThenInclude(e => e.Persona).ThenInclude(f => f.DocumentoIdentidad)
                                    .Include(e => e.InfoComplementarios).ThenInclude(e => e.Observacion)
                                    .Include(e => e.InfoComplementarios).ThenInclude(e => e.EstadoLLenado)
                                    .Include(e => e.Declarantes).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.Declarantes).ThenInclude(e => e.CondicionPer)
                                    .Include(e => e.Supervisores).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .Include(e => e.TecnicoCatastrales).ThenInclude(f => f.Persona).ThenInclude(e => e.DocumentoIdentidad)
                                    .DefaultIfEmpty()
                                    .FirstOrDefaultAsync(i => i.IdFicha.Equals(idFicha));

        public async Task<List<Ficha>> BuscarPorIdFichaPadreYEstadoFichaAsync(int? idFichaPadre, int estadoFicha)
        => await _context.Fichas.Include(e => e.Construcciones)
                                .Include(e => e.OtraInstalaciones)
                                .Where(e => e.Estado == estadoFicha && e.IdFichaPadre == idFichaPadre).ToListAsync();

        public async Task<Ficha> ObtenerPorIdUnidadAnioFichaIdTipoAsync(int idUnidadCatastral, EstadoFicha estadoFicha, int? anioFicha, TipoFichaEnum tipoFicha)
        {
            var response = await _context.Fichas.Where(e =>
                    e.Estado == (int)estadoFicha
                    && e.IdUnidadCatastral == idUnidadCatastral
                    && e.AnioFicha == anioFicha
                    && e.IdTipoFicha == (int)tipoFicha
                ).FirstOrDefaultAsync();

            return response;
        }

        public async Task<ResponsePagination<FichaBusqueda>> SelectPaginatedSearch(RequestPagination<FichaBusqueda> entity)
        {
            IList<FichaBusqueda> data=new List<FichaBusqueda>();
            string sqlQuery = "SELECT * from fic.ficha_select_paginated (@p_cod_ubigeo , @p_cod_sector , @p_cod_manzana , @p_cod_lote ,@p_cod_edif ,@p_cod_ent , @p_cod_piso ,@p_cod_unid , @p_digito_control , @p_numero_documento , @p_titular ,@p_nom_via , @p_num_municipal , @p_num_interior , @p_nombre_hu , @p_manzana_urbano , @p_lote_urbano , @p_num_partida , @p_anio , @p_estado , @p_perfil , @p_page ,@p_per_page )";
            var filter = entity?.Filter;
            int total = 0;

            using DbConnection connection= _context.Database.GetDbConnection();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = sqlQuery;

            //Parameters start
            var p_cod_ubigeo = command.CreateParameter();
            p_cod_ubigeo.ParameterName = "@p_cod_ubigeo";
            p_cod_ubigeo.Value = filter?.CodigoUbigeo ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_ubigeo);

            var p_cod_sector = command.CreateParameter();
            p_cod_sector.ParameterName = "@p_cod_sector";
            p_cod_sector.Value = filter?.CodigoSector ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_sector);

            var p_cod_manzana = command.CreateParameter();
            p_cod_manzana.ParameterName = "@p_cod_manzana";
            p_cod_manzana.Value = filter?.CodigoManzana ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_manzana);

            var p_cod_lote = command.CreateParameter();
            p_cod_lote.ParameterName = "@p_cod_lote";
            p_cod_lote.Value = filter?.CodigoLote ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_lote);

            var p_cod_edif = command.CreateParameter();
            p_cod_edif.ParameterName = "@p_cod_edif";
            p_cod_edif.Value = filter?.CodigoEdif ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_edif);

            var p_cod_ent = command.CreateParameter();
            p_cod_ent.ParameterName = "@p_cod_ent";
            p_cod_ent.Value = filter?.CodigoEnt ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_ent);

            var p_cod_piso = command.CreateParameter();
            p_cod_piso.ParameterName = "@p_cod_piso";
            p_cod_piso.Value = filter?.CodigoPiso ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_piso);

            var p_cod_unid = command.CreateParameter();
            p_cod_unid.ParameterName = "@p_cod_unid";
            p_cod_unid.Value = filter?.CodigoUnid ?? (object)DBNull.Value;
            command.Parameters.Add(p_cod_unid);

            var p_digito_control = command.CreateParameter();
            p_digito_control.ParameterName = "@p_digito_control";
            p_digito_control.Value = filter?.DigitoControl ?? (object)DBNull.Value;
            command.Parameters.Add(p_digito_control);

            var p_numero_documento = command.CreateParameter();
            p_numero_documento.ParameterName = "@p_numero_documento";
            p_numero_documento.Value = filter?.NumeroDocumento ?? (object)DBNull.Value;
            command.Parameters.Add(p_numero_documento);

            var p_titular = command.CreateParameter();
            p_titular.ParameterName = "@p_titular";
            p_titular.Value = filter?.Titular ?? (object)DBNull.Value;
            command.Parameters.Add(p_titular);

            var p_nom_via = command.CreateParameter();
            p_nom_via.ParameterName = "@p_nom_via";
            p_nom_via.Value = filter?.NombreVia ?? (object)DBNull.Value;
            command.Parameters.Add(p_nom_via);

            var p_num_municipal = command.CreateParameter();
            p_num_municipal.ParameterName = "@p_num_municipal";
            p_num_municipal.Value = filter?.NumeroMunicipal ?? (object)DBNull.Value;
            command.Parameters.Add(p_num_municipal);

            var p_num_interior = command.CreateParameter();
            p_num_interior.ParameterName = "@p_num_interior";
            p_num_interior.Value = filter?.NumeroInterior ?? (object)DBNull.Value;
            command.Parameters.Add(p_num_interior);

            var p_nombre_hu = command.CreateParameter();
            p_nombre_hu.ParameterName = "@p_nombre_hu";
            p_nombre_hu.Value = filter?.HabilitacionUrbana ?? (object)DBNull.Value;
            command.Parameters.Add(p_nombre_hu);

            var p_manzana_urbano = command.CreateParameter();
            p_manzana_urbano.ParameterName = "@p_manzana_urbano";
            p_manzana_urbano.Value = filter?.ManzanaUrbana ?? (object)DBNull.Value;
            command.Parameters.Add(p_manzana_urbano);

            var p_lote_urbano = command.CreateParameter();
            p_lote_urbano.ParameterName = "@p_lote_urbano";
            p_lote_urbano.Value = filter?.LoteUrbano ?? (object)DBNull.Value;
            command.Parameters.Add(p_lote_urbano);

            var p_num_partida = command.CreateParameter();
            p_num_partida.ParameterName = "@p_num_partida";
            p_num_partida.Value = filter?.NumeroPartida ?? (object)DBNull.Value;
            command.Parameters.Add(p_num_partida);

            var p_anio = command.CreateParameter();
            p_anio.ParameterName = "@p_anio";
            p_anio.Value = filter?.Anio ?? (object)DBNull.Value;
            command.Parameters.Add(p_anio);

            var p_estado = command.CreateParameter();
            p_estado.ParameterName = "@p_estado";
            p_estado.Value = filter?.Estado ?? (object)DBNull.Value;
            command.Parameters.Add(p_estado);

            var p_perfil = command.CreateParameter();
            p_perfil.ParameterName = "@p_perfil";
            p_perfil.Value = filter?.Perfil ?? (object)DBNull.Value;
            command.Parameters.Add(p_perfil);


            var p_page = command.CreateParameter();
            p_page.ParameterName = "@p_page";
            p_page.Value = entity.Page;
            command.Parameters.Add(p_page);

            var p_per_page = command.CreateParameter();
            p_per_page.ParameterName = "@p_per_page";
            p_per_page.Value = entity.PerPage;
            command.Parameters.Add(p_per_page);
            //Parameters end

            await connection.OpenAsync();
            using IDataReader reader =await command.ExecuteReaderAsync();
            
            // if (reader.Read())
            //      total = !reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0;

            while (reader.Read())
            {
                total = !reader.IsDBNull(reader.GetOrdinal("total_records")) ? reader.GetInt32(reader.GetOrdinal("total_records")) : 0;

                var item = new FichaBusqueda()
                {
                    Id = !reader.IsDBNull(reader.GetOrdinal("id_ficha")) ? reader.GetInt32(reader.GetOrdinal("id_ficha")) : 0,
                    IdUnidadCatastral = !reader.IsDBNull(reader.GetOrdinal("id_unidad_catastral")) ? reader.GetInt64(reader.GetOrdinal("id_unidad_catastral")) : 0,
                    IdLoteCarto = !reader.IsDBNull(reader.GetOrdinal("id_lote")) ? reader.GetString(reader.GetOrdinal("id_lote")) : null,
                    Anio = !reader.IsDBNull(reader.GetOrdinal("anio_ficha")) ? reader.GetInt32(reader.GetOrdinal("anio_ficha")).ToString() : null,
                    CodigoUbigeo = !reader.IsDBNull(reader.GetOrdinal("codigo_ubigeo")) ? reader.GetString(reader.GetOrdinal("codigo_ubigeo")) : null,
                    CodigoSector = !reader.IsDBNull(reader.GetOrdinal("codigo_sector")) ? reader.GetString(reader.GetOrdinal("codigo_sector")) : null,
                    CodigoManzana = !reader.IsDBNull(reader.GetOrdinal("codigo_manzana")) ? reader.GetString(reader.GetOrdinal("codigo_manzana")) : null,
                    CodigoLote = !reader.IsDBNull(reader.GetOrdinal("codigo_lote")) ? reader.GetString(reader.GetOrdinal("codigo_lote")) : null,
                    CodigoEdif = !reader.IsDBNull(reader.GetOrdinal("cod_edif")) ? reader.GetString(reader.GetOrdinal("cod_edif")) : null,
                    CodigoEnt = !reader.IsDBNull(reader.GetOrdinal("cod_ent")) ? reader.GetString(reader.GetOrdinal("cod_ent")) : null,
                    CodigoPiso = !reader.IsDBNull(reader.GetOrdinal("cod_piso")) ? reader.GetString(reader.GetOrdinal("cod_piso")) : null,
                    CodigoUnid = !reader.IsDBNull(reader.GetOrdinal("cod_unid")) ? reader.GetString(reader.GetOrdinal("cod_unid")) : null,
                    DigitoControl = !reader.IsDBNull(reader.GetOrdinal("digito_control")) ? reader.GetString(reader.GetOrdinal("digito_control")) : null,
                    FlagTipo = !reader.IsDBNull(reader.GetOrdinal("flag_tipo")) ? reader.GetString(reader.GetOrdinal("flag_tipo")) : null,
                    TipoPersona = !reader.IsDBNull(reader.GetOrdinal("nombre_tipo_persona")) ? reader.GetString(reader.GetOrdinal("nombre_tipo_persona")) : null,
                    NumeroDocumento = !reader.IsDBNull(reader.GetOrdinal("numero_documento")) ? reader.GetString(reader.GetOrdinal("numero_documento")) : null,
                    Titular = !reader.IsDBNull(reader.GetOrdinal("titular")) ? reader.GetString(reader.GetOrdinal("titular")) : null,
                    NombreVia = !reader.IsDBNull(reader.GetOrdinal("nombre_via")) ? reader.GetString(reader.GetOrdinal("nombre_via")) : null,
                    NumeroMunicipal = !reader.IsDBNull(reader.GetOrdinal("num_municipal")) ? reader.GetString(reader.GetOrdinal("num_municipal")) : null,
                    NumeroInterior = !reader.IsDBNull(reader.GetOrdinal("num_interior")) ? reader.GetString(reader.GetOrdinal("num_interior")) : null,
                    HabilitacionUrbana = !reader.IsDBNull(reader.GetOrdinal("nombre_hu")) ? reader.GetString(reader.GetOrdinal("nombre_hu")) : null,
                    ManzanaUrbana = !reader.IsDBNull(reader.GetOrdinal("manzana_urbana")) ? reader.GetString(reader.GetOrdinal("manzana_urbana")) : null,
                    LoteUrbano = !reader.IsDBNull(reader.GetOrdinal("lote_urbano")) ? reader.GetString(reader.GetOrdinal("lote_urbano")) : null,
                    NumeroPartida = !reader.IsDBNull(reader.GetOrdinal("num_partida")) ? reader.GetString(reader.GetOrdinal("num_partida")) : null,
                    Estado = !reader.IsDBNull(reader.GetOrdinal("estado")) ? reader.GetInt32(reader.GetOrdinal("estado")) : 0,
                    EstadoFicha = !reader.IsDBNull(reader.GetOrdinal("estado_ficha")) ? reader.GetString(reader.GetOrdinal("estado_ficha")) : null,
                    FichaCotitularidad = !reader.IsDBNull(reader.GetOrdinal("ficha_cotitularidad")) ? reader.GetInt64(reader.GetOrdinal("ficha_cotitularidad")).ToString() : null,
                    FichaBienComun = !reader.IsDBNull(reader.GetOrdinal("ficha_bienes_comunes")) ? reader.GetInt64(reader.GetOrdinal("ficha_bienes_comunes")).ToString() : null,
                    FichaActividadEconomica = !reader.IsDBNull(reader.GetOrdinal("ficha_actividad_economica")) ? reader.GetString(reader.GetOrdinal("ficha_actividad_economica")) : null,
                    FichaBienesCulturales = !reader.IsDBNull(reader.GetOrdinal("ficha_bienes_culturales")) ? reader.GetInt64(reader.GetOrdinal("ficha_bienes_culturales")).ToString() : null,
                    AreaGrafica = !reader.IsDBNull(reader.GetOrdinal("area_grafica")) ? reader.GetDecimal(reader.GetOrdinal("area_grafica")) : 0,
                    AreaConstruida = !reader.IsDBNull(reader.GetOrdinal("area_construida")) ? reader.GetDecimal(reader.GetOrdinal("area_construida")) : 0,
                    IdFichaControl = !reader.IsDBNull(reader.GetOrdinal("id_ficha_control")) ? reader.GetInt64(reader.GetOrdinal("id_ficha_control")) : null,
                };
                data.Add(item);
            }
            reader.Close();
            var pagination = new Pagination(total, entity.Page, entity.PerPage);
            var response = new ResponsePagination<FichaBusqueda>(pagination)
            {
                Data = data
            };
            return response;

        }
        public async Task<List<Ficha>> BuscarPorIdUnidadCatrastalAsync(int idUnidadCatrastal)
        => await _context.Fichas.Where(e => e.Estado != 0 && e.IdUnidadCatastral == idUnidadCatrastal).ToListAsync();

        public async Task<ResponsePagination<AnioReporte>> ListarAniosValorizacionAsync(RequestPagination<AnioReporte> entity)
        {
            var data = await _context.Fichas.Include(e => e.Construcciones)
            .Where(e => e.Estado == 1 && e.IdTipoFicha == (int)TipoFichaEnum.Individual && e.Construcciones.Any(e => e.ValorConstruccion != null)).ToListAsync();

            //var lista = new List<int>();
            //foreach (var item in data)
            //{
            //    lista.Add((int)item.AnioFicha);
            //}

            //lista = lista.Distinct().ToList();

            //return lista;

            var lista = new List<AnioReporte>();
            foreach (var item in data)
            {
                var anio = new AnioReporte()
                {
                    Anio = item.AnioFicha
                };
                lista.Add(anio);
            }

            lista = lista.Distinct().ToList();

            var pagination = new Pagination(lista.Count, entity.Page, entity.PerPage);

            var response = new ResponsePagination<AnioReporte>(pagination)
            {
                Data = lista
            };

            return response;
        }

        public async Task<ResponsePagination<Ficha>> PaginatedSearchValorizacion(RequestPagination<ValorizacionBusqueda> entity)
        {
            var filter = entity?.Filter;
            var query = _context.Fichas.Include(e => e.DescripcionPredios)
                                       .Include(e => e.Construcciones)
                                       .Include(e => e.OtraInstalaciones)
                                       .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona)
                                       .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.Via)
                                       .Include(e => e.UnidadCatastral).ThenInclude(f => f.TblCodigo)
                                       .AsQueryable();

            if(filter != null)
            {
                query = query.Include(e => e.DescripcionPredios)
                             .Include(e => e.Construcciones)
                             .Include(e => e.OtraInstalaciones)
                             .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona)
                             .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.Via)
                             .Include(e => e.UnidadCatastral).ThenInclude(f => f.TblCodigo)
                             .Where(e => e.Estado == (int)EstadoFicha.Estatico && e.IdTipoFicha == (int)TipoFichaEnum.Individual
                                    && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodDistrito == filter.CodigoUbigeo))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoSector) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodSector == filter.CodigoSector))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoManzana) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodManzana == filter.CodigoManzana))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoLote) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoLote))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoEdif) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoEdif))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoEnt) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoEnt))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoPiso) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoPiso))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoUnid) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoUnid))
                                    && (string.IsNullOrWhiteSpace(filter.DigitoControl) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.DigitoControl))

                                    && (string.IsNullOrWhiteSpace(filter.NumeroDocumento) || e.TitularCatastral.Any(e => e.Persona.NumeroDoc.Trim().Contains(filter.NumeroDocumento.Trim())))
                                    );

            }

            var entityFicha = new RequestPagination<Ficha>()
            {
                Page = entity.Page,
                PerPage = entity.PerPage,
                Filter = null
            };

            var response = await _paginator.Paginate(query, entityFicha);

            return response;
        }

        public async Task<List<Ficha>> SearchValorizacion(ValorizacionBusqueda filter)
        {
            var response = await _context.Fichas.Include(e => e.DescripcionPredios)
                             .Include(e => e.Construcciones)
                             .Include(e => e.OtraInstalaciones)
                             .Include(e => e.TitularCatastral).ThenInclude(f => f.Persona)
                             .Include(e => e.UbicacionPredios).ThenInclude(f => f.Puertas).ThenInclude(g => g.Via)
                             .Include(e => e.UnidadCatastral).ThenInclude(f => f.TblCodigo)
                             .Where(e => e.Estado == (int)EstadoFicha.Estatico && e.IdTipoFicha == (int)TipoFichaEnum.Individual
                                    && (string.IsNullOrWhiteSpace(filter.Anio) || e.AnioFicha.ToString() == filter.Anio)
                                    && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodDistrito == filter.CodigoUbigeo))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoSector) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodSector == filter.CodigoSector))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoManzana) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodManzana == filter.CodigoManzana))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoLote) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoLote))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoEdif) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoEdif))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoEnt) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoEnt))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoPiso) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoPiso))
                                    && (string.IsNullOrWhiteSpace(filter.CodigoUnid) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.CodigoUnid))
                                    && (string.IsNullOrWhiteSpace(filter.DigitoControl) || e.UnidadCatastral.TblCodigo.Any(e => e.Estado == true && e.FlagTipo == FlagTipoCodigo.CodigoCatastral && e.CodLote == filter.DigitoControl))

                                    && (string.IsNullOrWhiteSpace(filter.NumeroDocumento) || e.TitularCatastral.Any(e => e.Persona.NumeroDoc.Trim().Contains(filter.NumeroDocumento.Trim())))
                                    ).ToListAsync();

            return response;
        }
    }
}
