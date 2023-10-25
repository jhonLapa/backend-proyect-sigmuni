using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Conductores;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ConductorService : IConductorService
    {
        //private readonly IPersonaRepository _personaRepositorio;
        private readonly IConductorRepository _conductorRepository;
        //private readonly IInfoContactoServicio _infoContactoServicio;

        public ConductorService(
                              //   IPersonaRepositorio personaRepositorio,
                                 IConductorRepository conductorRepository
                               //  IInfoContactoServicio infoContactoServicio
                                )
        {
            //_personaRepositorio = personaRepositorio;
            _conductorRepository = conductorRepository;
           // _infoContactoServicio = infoContactoServicio;
        }

        public async Task<int> GuardarPersonaConductorAsync(ConductorDto peticion)
        {
           
            var idCondConductor = default(int?);
            if (peticion.CondConductor != null)
            {
                idCondConductor = peticion.CondConductor.IdCondicionConductor != 0 ? peticion.CondConductor.IdCondicionConductor : new int?();
            }


            var idCondutor = peticion.IdConductor;
            var conductor = await _conductorRepository.BuscarPorIdAsync(idCondutor);

            if (conductor == null)
            {
                conductor = new Conductor();
            }

            conductor.NombreComercial = peticion.NombreComercial;
            conductor.IdPersona = peticion.IdPersona;
            conductor.IdFicha = peticion.IdFicha;
            conductor.IdCondicionConductor = idCondConductor;
            conductor.NombreAsociacion = peticion.NombreAsociacion;
            conductor.NumTrabajadores = peticion.NumTrabajadores;
            var response = 0;
            if (conductor.IdConductor == 0)
            {
               var entity = await  _conductorRepository.Create(conductor);
                response = entity.IdConductor;
            }
            else
            {
                var entity =await _conductorRepository.Edit(conductor.IdConductor,conductor);
                response = entity.IdConductor;
            }

            //await _conductorRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }
    }
}
