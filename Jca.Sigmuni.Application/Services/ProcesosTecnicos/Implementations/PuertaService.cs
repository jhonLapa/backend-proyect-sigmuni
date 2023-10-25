using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.PadronNumeraciones.Numeraciones.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class PuertaService : IPuertaService
    {
        private readonly IMapper _mapper;
        private readonly IPuertaRepository _puertaRepository;
        private readonly INumeracionRepository _numeracionRepository;

        public PuertaService(IMapper mapper,
                             IPuertaRepository puertaRepository,
                             INumeracionRepository numeracionRepository)
        {
            _mapper = mapper;
            _puertaRepository = puertaRepository;
            _numeracionRepository = numeracionRepository;
        }

        public async Task<List<PuertaDto>> ListarPorUbicacionPredioAsync(int idUbicacionPredio)
        {
            var listaPuerta = await _puertaRepository.ListarPorUbicacionPredioAsync(idUbicacionPredio);

            return _mapper.Map<List<PuertaDto>>(listaPuerta);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _puertaRepository.EliminarAsync(id);
        }

        public async Task<bool> EliminarPorListaAsync(List<PuertaDto> puertas)
        {
            foreach (var item in puertas)
            {
                int id = item.IdPuerta;
                var response = await _puertaRepository.EliminarAsync(id);
                if (response == false) return response;
            }

            return true;
        }
        public async Task<IList<PuertaDto>> FindAll()
        {
            var response = await _puertaRepository.FindAll();

            return _mapper.Map<IList<PuertaDto>>(response);
        }

        public async Task<Puerta?> GuardarAsync(PuertaDto peticion)
        {
            int id = peticion.IdPuerta != 0 || peticion.IdPuerta != null ? peticion.IdPuerta : 0;
            var puerta = await _puertaRepository.Find(id);

            if (puerta == null) puerta = new Puerta();

            var idTipoPuerta = default(int?);

            if (peticion.TipoPuerta != null)
            {
                idTipoPuerta = peticion.TipoPuerta.IdTipoPuerta != 0 || peticion.TipoPuerta.IdTipoPuerta != null ? peticion.TipoPuerta.IdTipoPuerta : new int?();
            }

            var idVia = default(string);
            if (peticion.Via != null)
            {
                idVia = !string.IsNullOrWhiteSpace(peticion.Via.IdVia) ? peticion.Via.IdVia : null;
            }

            var idCondNumPrincipal = default(int?);
            if (peticion.CondicionNumeracion != null)
            {
                idCondNumPrincipal = peticion.CondicionNumeracion.IdCondicionNumeracion != 0 ? peticion.CondicionNumeracion.IdCondicionNumeracion : new int?();
            }

            //var idCondNumSecundario = default(int?);
            //if (peticion.CondNumSecundario != null)
            //{
            //    idCondNumSecundario = peticion.CondNumSecundario.Id != 0 || peticion.TipoPuerta.IdTipoPuerta != null ? peticion.CondNumSecundario.Id : new int?();
            //}

            //var idTipoNumPrincipal = default(int?);
            //if (peticion.TipoNumPrincipal != null)
            //{
            //    idTipoNumPrincipal = peticion.TipoNumPrincipal.Id != 0 || peticion.TipoPuerta.IdTipoPuerta != null ? peticion.TipoNumPrincipal.Id : new int?();
            //}

            //var idTipoNumSecundario = default(int?);
            //if (peticion.TipoNumSecundario != null)
            //{
            //    idTipoNumSecundario = peticion.TipoNumSecundario.Id != 0 || peticion.TipoPuerta.IdTipoPuerta != null ? peticion.TipoNumSecundario.Id : new int?();
            //}

            //var idUbicacionNumeracion = default(int?);
            //if (peticion.UbicacionNumeracion != null)
            //{
            //    idUbicacionNumeracion = peticion.UbicacionNumeracion.Id != 0 || peticion.TipoPuerta.IdTipoPuerta != null ? peticion.UbicacionNumeracion.Id : new int?();
            //}

            var idTipoInterior = default(int?);
            if (peticion.TipoInterior != null)
            {
                idTipoInterior = peticion.TipoInterior.IdTipoInterior != 0 || peticion.TipoInterior.IdTipoInterior != null ? peticion.TipoInterior.IdTipoInterior : new int?();
            }

            var numeracion = await _numeracionRepository.ObtenerPorIdTblCodigoYTipoPuerta(peticion.IdTblCodigo, idTipoPuerta ?? 0);
            if (numeracion != null)
            {
                if (numeracion.Certificado != null)
                {
                    puerta.NumCertifPrincipal = numeracion.Certificado.NumCertificadoExterior;
                    puerta.AnioPrincipal = numeracion.Certificado.AnioCertificadoExterior;

                    puerta.NumCertifSecundario = numeracion.Certificado.NumCertificadoInterior;
                    puerta.AnioSecundario = numeracion.Certificado.AnioCertificadoInterior;
                }
            }

            puerta.CodigoPuerta = peticion.CodigoPuerta;
            puerta.NumeracionMunicipal = peticion.NumeracionMunicipal;
            puerta.IdTipoPuerta = idTipoPuerta;
            puerta.IdVia = idVia;
            puerta.IdLoteCartografia = peticion.IdLoteCartografia;
            puerta.IdUbicacionPredio = peticion.IdUbicacionPredio;
            puerta.IdCondNumPrincipal = idCondNumPrincipal;
            //puerta.IdCondNumSecundario = idCondNumSecundario;
            //puerta.IdTipoNumPrincipal = idTipoNumPrincipal;
            //puerta.IdTipoNumSecundario = idTipoNumSecundario;
            puerta.LtPrincipal = peticion.LtPrincipal;
            puerta.LtScundario = peticion.LtScundario;
            //puerta.IdUbicacionNumeracion = idUbicacionNumeracion;
            puerta.NumCertifPrincipal = peticion.NumCertifPrincipal;
            puerta.NumeroInterior = peticion.NumeroInterior;
            puerta.IdTipoInterior = idTipoInterior;


            if (puerta.IdPuerta == 0)
                return await _puertaRepository.Create(puerta);
            else
                return await _puertaRepository.Edit(puerta.IdPuerta, puerta);
        }
    }
}
