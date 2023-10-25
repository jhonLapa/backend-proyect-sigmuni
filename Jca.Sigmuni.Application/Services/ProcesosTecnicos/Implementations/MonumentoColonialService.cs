using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class MonumentoColonialService : IMonumentoColonialService
    {
        private readonly IMonumentoColonialRepository _monumentoColonialRepository;

        public MonumentoColonialService(
                                          IMonumentoColonialRepository monumentoColonialRepository
                                        )
        {
            _monumentoColonialRepository = monumentoColonialRepository;
        }

        public async Task<int?> CrearOActualizarAsync(MonumentoColonialDto peticion)
        {
            

            var id = peticion.IdMonumentoColonial;

            var monumentoColonial = await _monumentoColonialRepository.BuscarPorIdAsync(id);

            if (monumentoColonial == null)
            {
                monumentoColonial = new MonumentoColonial();
            }

            var idTipoArquitectura = default(int?);
            if (peticion.TipoArquitectura != null)
            {
                idTipoArquitectura = peticion.TipoArquitectura.IdTipoArquitecturas != 0 ? peticion.TipoArquitectura.IdTipoArquitecturas : new int?();
            }

            var idUsoPredio = default(int?);
            if (peticion.UsoPredio != null)
            {
                idUsoPredio = peticion.UsoPredio.IdUsoPredio != 0 ? peticion.UsoPredio.IdUsoPredio : new int?();
            }

            var idUsoOrginalPredio = default(int?);
            if (peticion.UsoOrginalPredio != null)
            {
                idUsoOrginalPredio = peticion.UsoOrginalPredio.IdUsoPredio != 0 ? peticion.UsoOrginalPredio.IdUsoPredio : new int?();
            }

            var idTiempoConstruccion = default(int?);
            if (peticion.TiempoConstruccion != null)
            {
                idTiempoConstruccion = peticion.TiempoConstruccion.IdTiempoConstruccion != 0 ? peticion.TiempoConstruccion.IdTiempoConstruccion : new int?();
            }

            var idElementoArquitectonico = default(int?);
            if (peticion.ElementoArquitectonico != null)
            {
                idElementoArquitectonico = peticion.ElementoArquitectonico.IdElementoArquitectonico != 0 ? peticion.ElementoArquitectonico.IdElementoArquitectonico : new int?();
            }

            var idFiliacionEstilistica = default(int?);
            if (peticion.FiliacionEstilistica != null)
            {
                idFiliacionEstilistica = peticion.FiliacionEstilistica.IdFiliacionEstilistica != 0 ? peticion.FiliacionEstilistica.IdFiliacionEstilistica : new int?();
            }

            var idEstadoCimiento = default(int?);
            if (peticion.EstadoCimiento != null)
            {
                idEstadoCimiento = peticion.EstadoCimiento.IdEstadoAcabado != 0 ? peticion.EstadoCimiento.IdEstadoAcabado : new int?();
            }

            var idEstadoMuro = default(int?);
            if (peticion.EstadoMuro != null)
            {
                idEstadoMuro = peticion.EstadoMuro.IdEstadoAcabado != 0 ? peticion.EstadoMuro.IdEstadoAcabado : new int?();
            }

            var idEstadoPiso = default(int?);
            if (peticion.EstadoPiso != null)
            {
                idEstadoPiso = peticion.EstadoPiso.IdEstadoAcabado != 0 ? peticion.EstadoPiso.IdEstadoAcabado : new int?();
            }

            var idEstadoTecho = default(int?);
            if (peticion.EstadoTecho != null)
            {
                idEstadoTecho = peticion.EstadoTecho.IdEstadoAcabado != 0 ? peticion.EstadoTecho.IdEstadoAcabado : new int?();
            }

            var idEstadoPilastra = default(int?);
            if (peticion.EstadoPilastra != null)
            {
                idEstadoPilastra = peticion.EstadoPilastra.IdEstadoAcabado != 0 ? peticion.EstadoPilastra.IdEstadoAcabado : new int?();
            }

            var idEstadoRevestimiento = default(int?);
            if (peticion.EstadoRevestimiento != null)
            {
                idEstadoRevestimiento = peticion.EstadoRevestimiento.IdEstadoAcabado != 0 ? peticion.EstadoRevestimiento.IdEstadoAcabado : new int?();
            }

            var idEstadoBalcon = default(int?);
            if (peticion.EstadoBalcon != null)
            {
                idEstadoBalcon = peticion.EstadoBalcon.IdEstadoAcabado != 0 ? peticion.EstadoBalcon.IdEstadoAcabado : new int?();
            }

            var idEstadoPuerta = default(int?);
            if (peticion.EstadoPuerta != null)
            {
                idEstadoPuerta = peticion.EstadoPuerta.IdEstadoAcabado != 0 ? peticion.EstadoPuerta.IdEstadoAcabado : new int?();
            }

            var idEstadoVentana = default(int?);
            if (peticion.EstadoVentana != null)
            {
                idEstadoVentana = peticion.EstadoVentana.IdEstadoAcabado != 0 ? peticion.EstadoVentana.IdEstadoAcabado : new int?();
            }

            var idEstadoReja = default(int?);
            if (peticion.EstadoReja != null)
            {
                idEstadoReja = peticion.EstadoReja.IdEstadoAcabado != 0 ? peticion.EstadoReja.IdEstadoAcabado : new int?();
            }

            var idOtroEstadoAcabado = default(int?);
            if (peticion.EstadoOtro != null)
            {
                idOtroEstadoAcabado = peticion.EstadoOtro.IdEstadoAcabado != 0 ? peticion.EstadoOtro.IdEstadoAcabado : new int?();
            }

            var idIntervencionInmueble = default(int?);
            if (peticion.IntervencionInmueble != null)
            {
                idIntervencionInmueble = peticion.IntervencionInmueble.IdIntervencionInmueble != 0 ?peticion.IntervencionInmueble.IdIntervencionInmueble : new int?();
            }

            var idObservacion = default(int?);
            if (peticion.Observacion != null)
            {
                idObservacion = peticion.Observacion.IdObservacion != 0 ? peticion.Observacion.IdObservacion : new int?();
            }

            monumentoColonial.PatrimonioCultural = peticion.PatrimonioCultural;
            monumentoColonial.Denominacion = peticion.Denominacion;
            monumentoColonial.IdTipoArquitectura = idTipoArquitectura;
            monumentoColonial.IdUsoPredio = idUsoPredio;
            monumentoColonial.IdUsoOrginalPredio = idUsoOrginalPredio;
            monumentoColonial.NumeroPisoCifra = peticion.NumeroPisoCifra;
            monumentoColonial.NumeroPisoLiteral = peticion.NumeroPisoLiteral;
            monumentoColonial.IdTiempoConstruccion = idTiempoConstruccion;
            monumentoColonial.FechaConstruccion = peticion.FechaConstruccion;
            monumentoColonial.AreaTerrenoTitulo = peticion.AreaTerrenoTitulo;
            monumentoColonial.AreaTechadaVerificada = peticion.AreaTechadaVerificada;
            monumentoColonial.AreaLibre = peticion.AreaLibre;
            monumentoColonial.IdElementoArquitectonico = idElementoArquitectonico;
            monumentoColonial.OtroElementoArquitectonico = peticion.OtroElementoArquitectonico;
            monumentoColonial.DescripcionFachada = peticion.DescripcionFachada;
            monumentoColonial.DescripcionInterior = peticion.DescripcionInterior;
            monumentoColonial.IdFiliacionEstilistica = idFiliacionEstilistica;
            monumentoColonial.OtroFiliacionEstilistica = peticion.OtroFiliacionEstilistica;
            monumentoColonial.IdCimiento = idEstadoCimiento;
            monumentoColonial.IdMuro = idEstadoMuro;
            monumentoColonial.IdPiso = idEstadoPiso;
            monumentoColonial.IdTecho = idEstadoTecho;
            monumentoColonial.IdPilastra = idEstadoPilastra ?? 0;
            monumentoColonial.IdCimiento = idEstadoCimiento;
            monumentoColonial.IdRevestimiento = idEstadoRevestimiento;
            monumentoColonial.IdBalcon = idEstadoBalcon;
            monumentoColonial.IdPuerta = idEstadoPuerta;
            monumentoColonial.IdVentana = idEstadoVentana;
            monumentoColonial.IdReja = idEstadoReja;
            monumentoColonial.IdOtro = idOtroEstadoAcabado;
            monumentoColonial.OtroEstadoAcabado = peticion.OtroEstadoAcabado;
            monumentoColonial.IdIntervencionInmueble = idIntervencionInmueble;
            monumentoColonial.ReseniaHistorica = peticion.ReseniaHistorica;
            monumentoColonial.IdObservacion = idObservacion;
            //monumentoColonial.ObservacionOtros = peticion.ObservacionOtros;
            monumentoColonial.IdFichaBienCultural = peticion.IdFichaBienCultural;

            var response = 0;
            if (monumentoColonial.IdMonumentoColonial == 0)
            {
                var entity = await _monumentoColonialRepository.Create(monumentoColonial);
                response = entity.IdMonumentoColonial;
            }
            else
            {
                var entity = await  _monumentoColonialRepository.Edit(2,monumentoColonial);
                response = entity.IdMonumentoColonial;
            }

            //await _monumentoColonialRepository.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }
    }
}
