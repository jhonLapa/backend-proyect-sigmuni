using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class NormaintMonPrehiService : INormaIntMonPrehiService
    {
        private readonly INormaIntMonPrehiRepository _normaintMonPrehiRepository;

        public NormaintMonPrehiService(
            INormaIntMonPrehiRepository normaintMonPrehiRepository
            )
        {
            _normaintMonPrehiRepository = normaintMonPrehiRepository;
        }
        public async Task<int> CrearOActualizarAsync(NormaIntMonPrehiDto peticion)
        {


            

            var id = peticion.IdNormaIntMonPrehi;

            var entidad = await _normaintMonPrehiRepository.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new NormaIntMonPrehi();
            }

            var idNormaInteres = new int?();
            if (peticion.NormaInteres != null)
            {
                idNormaInteres = peticion.NormaInteres.IdNormaInteres != 0 ? peticion.NormaInteres.IdNormaInteres : null;
            }

            

            entidad.NumPlano = peticion.NumPlano;
            entidad.Fecha = peticion.Fecha;
            entidad.IdMonumentoPre = peticion.IdMonumentoPre == null || peticion.IdMonumentoPre == 0 ? null : peticion.IdMonumentoPre;
            entidad.IdNormaInteres = idNormaInteres;
           

            var response = 0;
            if (entidad.IdNormaIntMonPrehi == 0)
            {
                var entity = await _normaintMonPrehiRepository.Create(entidad);
                response = entity.IdNormaIntMonPrehi;
            }
            else
            {
                var entity = await _normaintMonPrehiRepository.Edit(entidad.IdNormaIntMonPrehi, entidad);
                response = entity.IdNormaIntMonPrehi;
            }

            //await _fichaBienCulturalRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }

        public async Task<bool> EliminarPorIdMonumentoPreinspanicoAsync(int? idMonumentoPre)
        {
            if(idMonumentoPre != null && idMonumentoPre != 0)
            {
                var lista = await _normaintMonPrehiRepository.ListarPorIdMonumentoPreAsync((int)idMonumentoPre);

                foreach (var item in lista)
                {
                    item.Estado = false;
                    await _normaintMonPrehiRepository.Edit(0, item);
                    //_normaIntMonPreinsRepositorio.Eliminar(item);
                }

                //await _normaIntMonPreinsRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
