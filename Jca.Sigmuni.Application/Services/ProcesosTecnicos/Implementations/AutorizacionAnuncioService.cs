using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class AutorizacionAnuncioService :IAutorizacionAnuncioService
    {
        private readonly IAutorizacionAnuncioRepository _autorizacionAnuncioRepository;

        public AutorizacionAnuncioService(
                                           IAutorizacionAnuncioRepository autorizacionAnuncioRepository
                                          )
        {
            _autorizacionAnuncioRepository = autorizacionAnuncioRepository;
        }

        public async Task<int> CrearAsync(AutorizacionAnuncioDto peticion)
        {
            

            var idTipoAnuncio = default(int?);

            if (peticion.TipoAnuncio != null)
            {
                idTipoAnuncio = peticion.TipoAnuncio.IdTipoAnuncio != 0 ? peticion.TipoAnuncio.IdTipoAnuncio : new int?();
            }

            var idCondicionAnuncio = default(int?);
            if (peticion.CondicionAnuncio != null)
            {
                idCondicionAnuncio = peticion.CondicionAnuncio.IdCondicionAnuncio != 0 ? peticion.CondicionAnuncio.IdCondicionAnuncio : new int?();
            }

            var autorizacionAnuncio = new AutorizacionAnuncio
            {
                IdTipoAnuncio = idTipoAnuncio,
                NumeLados = peticion.NumeLados,
                AreaAutorizada = peticion.AreaAutorizada,
                AreaVerificada = peticion.AreaVerificada,
                NumeExpediente = peticion.NumeExpediente,
                NumeLicencia = peticion.NumeLicencia,
                FechaExpedicion = peticion.FechaExpedicion,
                FechaVencimiento = peticion.FechaVencimiento,
                IdCondicionAnuncio = idCondicionAnuncio,
                IdFicha = peticion.IdFicha,
                AnioAutorizacion = peticion.AnioAutorizacion
            };

            var response = await _autorizacionAnuncioRepository.Create(autorizacionAnuncio);
           // await _autorizacionAnuncioRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response.IdAutorizacionAnuncio;
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _autorizacionAnuncioRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _autorizacionAnuncioRepository.EliminarAsync(item.IdAutorizacionAnuncio);
            }

            return response;
        }
    }
}
