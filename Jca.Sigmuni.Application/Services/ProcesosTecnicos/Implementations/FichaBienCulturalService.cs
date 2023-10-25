using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class FichaBienCulturalService : IFichaBienCulturalService
    {
        private readonly IFichaBienCulturalRepository _fichaBienCulturalRepository;

        public FichaBienCulturalService(
            IFichaBienCulturalRepository fichaBienCulturalRepository
            )
        {
            _fichaBienCulturalRepository = fichaBienCulturalRepository;
        }
        public async Task<int> CrearOActualizarAsync(FichaBienCulturalDto peticion)
        {
           

            var id = peticion.IdFichaBienCultural;

            var fichaBienCultural = await _fichaBienCulturalRepository.BuscarPorIdAsync(id);

            if (fichaBienCultural == null)
            {
                fichaBienCultural = new FichaBienCultural();
            }

            fichaBienCultural.CUIDistrito = peticion.CUIDistrito;
            fichaBienCultural.CUISector = peticion.CUISector;
            fichaBienCultural.CUIManzana = peticion.CUIManzana;
            fichaBienCultural.CUILote = peticion.CUILote;
            fichaBienCultural.CUISubLote = peticion.CUISubLote;
            fichaBienCultural.CRCZona = peticion.CRCZona;
            fichaBienCultural.CRCCoordenadaEsta = peticion.CRCCoordenadaEsta;
            fichaBienCultural.CRCCoordenadaNorte = peticion.CRCCoordenadaNorte;
            fichaBienCultural.CRCUnidadCatastral = peticion.CRCUnidadCatastral;
            fichaBienCultural.IdFicha = peticion.IdFicha;

            var response = 0;
            if (fichaBienCultural.IdFichaBienCultural == 0)
            {
                var entity =  await _fichaBienCulturalRepository.Create(fichaBienCultural);
                response = entity.IdFichaBienCultural;
            }
            else
            {
                var entity = await  _fichaBienCulturalRepository.Edit(fichaBienCultural.IdFichaBienCultural,fichaBienCultural);
                response = entity.IdFichaBienCultural;
            }

            //await _fichaBienCulturalRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }
    }
}
