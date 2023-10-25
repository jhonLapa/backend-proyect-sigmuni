using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosPrehispanicos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class MonumentoPrehispanicoService : IMonumentoPrehispanicoService
    {
        private readonly IMonumentoPrehispanicoRepository _monumentoPrehispanicoRepository;

        public MonumentoPrehispanicoService(
                                             IMonumentoPrehispanicoRepository monumentoPrehispanicoRepository
                                            )
        {
            _monumentoPrehispanicoRepository = monumentoPrehispanicoRepository;
        }

        public async Task<int?> CrearOActualizarAsync(MonumentoPrehispanicoDto peticion)
        {
            

            var id = peticion.IdMonumentoPrehispanico;

            var monumentoPreinspanico = await _monumentoPrehispanicoRepository.BuscarPorIdAsync(id);

            if (monumentoPreinspanico == null)
            {
                monumentoPreinspanico = new MonumentoPrehispanico();
            }

            var idCategoriaInmueble = default(int?);
            if (peticion.CategoriaInmueble != null)
            {
                idCategoriaInmueble = peticion.CategoriaInmueble.IdCategoriaInmueble != 0 ? peticion.CategoriaInmueble.IdCategoriaInmueble : new int?();
            }

            var idUnidadMedida = default(int?);
            if (peticion.UnidadMedida != null)
            {
                idUnidadMedida = peticion.UnidadMedida.IdUnidadMedida != 0 ? peticion.UnidadMedida.IdUnidadMedida : new int?();
            }

            var idFiliacionCronologica = default(int?);
            if (peticion.FiliacionCronologica != null)
            {
                idFiliacionCronologica = peticion.FiliacionCronologica.IdFiliacionCronologica != 0 ? peticion.FiliacionCronologica.IdFiliacionCronologica : new int?();
            }

            var idTipoArquitectura = default(int?);
            if (peticion.TipoArquitectura != null)
            {
                idTipoArquitectura = peticion.TipoArquitectura.IdTipoArquitecturas != 0 ? peticion.TipoArquitectura.IdTipoArquitecturas : new int?();
            }

            var idTipoMaterial = default(int?);
            if (peticion.TipoMaterial != null)
            {
                idTipoMaterial = peticion.TipoMaterial.IdTipoMaterial != 0 ? peticion.TipoMaterial.IdTipoMaterial : new int?();
            }

            var idAfectacionNatural = default(int?);
            if (peticion.AfectacionNatural != null)
            {
                idAfectacionNatural = peticion.AfectacionNatural.IdAfectacionNatural != 0 ? peticion.AfectacionNatural.IdAfectacionNatural : new int?();
            }

            var idAfectacionAntropica = default(int?);
            if (peticion.AfectacionAntropica != null)
            {
                idAfectacionAntropica = peticion.AfectacionAntropica.IdAfectacionAntropica != 0 ? peticion.AfectacionAntropica.IdAfectacionAntropica : new int?();
            }

            var idIntervencionConservacion = default(int?);
            if (peticion.IntervencionConservacion != null)
            {
                idIntervencionConservacion = peticion.IntervencionConservacion.IdIntervencionConservacion != 0 ? peticion.IntervencionConservacion.IdIntervencionConservacion : new int?();
            }

            var idObservacion = default(int?);
            if (peticion.Observacion != null)
            {
                idObservacion = peticion.Observacion.IdObservacion != 0 ? peticion.Observacion.IdObservacion : new int?();
            }

            monumentoPreinspanico.IdCategoriaInmueble = idCategoriaInmueble;
            monumentoPreinspanico.Codigo = peticion.Codigo;
            monumentoPreinspanico.Nombre = peticion.Nombre;
            monumentoPreinspanico.Area = peticion.Area;
            monumentoPreinspanico.IdUnidadMedida = idUnidadMedida;
            monumentoPreinspanico.Perimetro = peticion.Perimetro;
            monumentoPreinspanico.IdFiliacionCronologica = idFiliacionCronologica;
            if(peticion.PresenciaAr!=null)
            {
                monumentoPreinspanico.PresenciaArquitectura = peticion.PresenciaAr.Descripcion;
            }
            monumentoPreinspanico.IdTipoArquitectura = idTipoArquitectura;
            monumentoPreinspanico.IdTipoMaterial = idTipoMaterial;
            monumentoPreinspanico.OtroTipoMaterial = peticion.OtroTipoMaterial;
            monumentoPreinspanico.IdAfectacionNatural = idAfectacionNatural;
            monumentoPreinspanico.OtroAfectacionNatural = peticion.OtroAfectacionNatural;
            monumentoPreinspanico.IdAfectacionAntropica = idAfectacionAntropica;
            monumentoPreinspanico.OtroAfectacionAntropica = peticion.OtroAfectacionAntropica;
            monumentoPreinspanico.IdIntervencionConservacion = idIntervencionConservacion;
            monumentoPreinspanico.IdObservacion = idObservacion;
            monumentoPreinspanico.ObservacionOtros = peticion.ObservacionOtros;
            monumentoPreinspanico.IdFichaBienCultural = peticion.IdFichaBienCultural;


            var response = 0;
            if (monumentoPreinspanico.IdMonumentoPrehispanico == 0)
            {
                var entity = await _monumentoPrehispanicoRepository.Create(monumentoPreinspanico);
                response = entity.IdMonumentoPrehispanico;
            }
            else
            {
                var entity = await _monumentoPrehispanicoRepository.Edit(monumentoPreinspanico.IdMonumentoPrehispanico,monumentoPreinspanico);
                response = entity.IdMonumentoPrehispanico;
            }

            //await _monumentoPreinspanicoRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }
    }
}
