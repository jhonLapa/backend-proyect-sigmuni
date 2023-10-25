using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos;
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
    public class ServicioBasicoService : IServicioBasicoService
    {
        private readonly IMapper _mapper;
        private readonly IServicioBasicoRepository _servicioBasicoRepository;

        public ServicioBasicoService(IMapper mapper,
                                     IServicioBasicoRepository servicioBasicoRepository)
        {
            _mapper = mapper;
            _servicioBasicoRepository = servicioBasicoRepository;
        }

        public async Task<ServicioBasico?> CrearOActualizarAsync(ServicioBasicoDto peticion)
        {
            var id = peticion.IdServicioBasico;

            var servicioBasico = await _servicioBasicoRepository.Find(id);

            if (servicioBasico == null)
            {
                servicioBasico = new ServicioBasico();
            }

            var idLuz = new int?();
            var idAgua = new int?();
            var idTelefono = new int?();
            var idDesague = new int?();
            var idGas = new int?();
            var idInternet = new int?();
            var idCable = new int?();

            if (peticion.Luz != null)
            {
                idLuz = peticion.Luz.IdTipoServicioBasico != 0 ? peticion.Luz.IdTipoServicioBasico : new int?();
            }
            if (peticion.Agua != null)
            {
                idAgua = peticion.Agua.IdTipoServicioBasico != 0 ? peticion.Agua.IdTipoServicioBasico : new int?();
            }
            if (peticion.Telefono != null)
            {
                idTelefono = peticion.Telefono.IdTipoServicioBasico != 0 ? peticion.Telefono.IdTipoServicioBasico : new int?();
            }
            if (peticion.Desague != null)
            {
                idDesague = peticion.Desague.IdTipoServicioBasico != 0 ? peticion.Desague.IdTipoServicioBasico : new int?();
            }
            if (peticion.Gas != null)
            {
                idGas = peticion.Gas.IdTipoServicioBasico != 0 ? peticion.Gas.IdTipoServicioBasico : new int?();
            }
            if (peticion.Internet != null)
            {
                idInternet = peticion.Internet.IdTipoServicioBasico != 0 ? peticion.Internet.IdTipoServicioBasico : new int?();
            }
            if (peticion.Cable != null)
            {
                idCable = peticion.Cable.IdTipoServicioBasico != 0 ? peticion.Cable.IdTipoServicioBasico : new int?();
            }

            servicioBasico.IdLuz = idLuz;
            servicioBasico.IdAgua = idAgua;
            servicioBasico.IdTelefono = idTelefono;
            servicioBasico.IdDesague = idDesague;
            servicioBasico.IdGas = idGas;
            servicioBasico.IdInternet = idInternet;
            servicioBasico.IdCable = idCable;
            servicioBasico.IdFicha = peticion.IdFicha;
            servicioBasico.NumContratoAgua = peticion.NumContratoAgua;
            servicioBasico.SuministroLuz = peticion.SuministroLuz;
            servicioBasico.NumTelefono = peticion.NumTelefono;

            if (servicioBasico.IdServicioBasico == 0)
            {
                return await _servicioBasicoRepository.Create(servicioBasico);
            }
            else
            {
                return await _servicioBasicoRepository.Edit(servicioBasico.IdServicioBasico, servicioBasico);
            }
        }
    }
}
