using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class EdificacionService : IEdificacionService
    {
        private readonly IMapper _mapper;
        private readonly IEdificacionRepository _edificacionRepository;

        public EdificacionService(IMapper mapper,
                                  IEdificacionRepository edificacionRepository)
        {
            _mapper = mapper;
            _edificacionRepository = edificacionRepository;
        }

        public async Task<Edificacion?> CrearOActualizarAsync(EdificacionDto peticion)
        {
            var id = peticion.IdEdificacion;

            var entidad = await _edificacionRepository.Find(id);

            if (entidad == null) entidad = new Edificacion();


            entidad.Nombre = peticion.Nombre;
            entidad.Manzana = peticion.Manzana;
            entidad.NumLote = peticion.NumLote;
            entidad.LoteUrbano = peticion.LoteUrbano;
            entidad.SubLote = peticion.SubLote;
            if (peticion.TipoEdificacion != null) entidad.IdTipoEdificacion = peticion.TipoEdificacion.IdTipoEdificacion;
            if (peticion.TipoAgrupacion != null) entidad.IdTipoAgrupacion = peticion.TipoAgrupacion.IdTipoAgrupacion;


            if (entidad.IdEdificacion == 0) return await _edificacionRepository.Create(entidad);
            else return await _edificacionRepository.Edit(entidad.IdEdificacion, entidad);
        }

    }
}
