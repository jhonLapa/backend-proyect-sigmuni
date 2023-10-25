using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class OtraInstalacionService : IOtraInstalacionService
    {
        private readonly IMapper _mapper;
        private readonly IOtraInstalacionRepository _otraInstalacionRepository;

        public OtraInstalacionService(IMapper mapper,
                                      IOtraInstalacionRepository otraInstalacionRepository)
        {
            _mapper = mapper;
            _otraInstalacionRepository = otraInstalacionRepository;
        }

        public async Task<OtraInstalacion> CrearAsync(OtraInstalacionDto peticion)
        {
            var idMep = new int?();
            var idEcs = new int?();
            var idEcc = new int?();
            var idUca = new int?();
            var idTipoOtraInstalacion = new int?();
            var idUnidadMedida = new int?();


            if (peticion.Mep != null)
            {
                idMep = peticion.Mep.IdMep != 0 ? peticion.Mep.IdMep : new int?();
            }

            if (peticion.Ecs != null)
            {
                idEcs = peticion.Ecs.IdEcs != 0 ? peticion.Ecs.IdEcs : new int?();
            }

            if (peticion.Ecc != null)
            {
                idEcc = peticion.Ecc.IdEcc != 0 ? peticion.Ecc.IdEcc : new int?();
            }

            if (peticion.Uca != null)
            {
                idUca = peticion.Uca.IdUca != 0 ? peticion.Uca.IdUca : new int?();
            }

            if (peticion.TipoOtraInstalacion != null)
            {
                idTipoOtraInstalacion = peticion.TipoOtraInstalacion.IdTipoOtraInstalacion != 0 ? peticion.TipoOtraInstalacion.IdTipoOtraInstalacion : new int?();
            }

            if (peticion.UnidadMedida != null)
            {
                idUnidadMedida = peticion.UnidadMedida.IdUnidadMedida != 0 ? peticion.UnidadMedida.IdUnidadMedida : new int?();
            }

            var otraInstalacion = new OtraInstalacion
            {
                Cantidad = peticion.Cantidad,
                ProductoTotal = peticion.ProductoTotal,
                IdUca = idUca,
                IdTipoOtrasInstalaciones = idTipoOtraInstalacion,
                IdEcc = idEcc,
                IdEcs = idEcs,
                IdMep = idMep,
                IdFicha = peticion.IdFicha,
                MesAnio = peticion.MesAnio,
                Largo = peticion.Largo,
                Ancho = peticion.Ancho,
                Alto = peticion.Alto,
                IdUnidadMedida = idUnidadMedida
            };

            return await _otraInstalacionRepository.Create(otraInstalacion);
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _otraInstalacionRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _otraInstalacionRepository.EliminarAsync(item.IdOtraInstalacion);
            }

            return response;
        }
    }
}
