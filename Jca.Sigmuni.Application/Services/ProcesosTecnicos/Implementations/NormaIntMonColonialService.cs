using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonColoniales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class NormaIntMonColonialService : INormaIntMonColonialService
    {
        private readonly INormaIntMonColonialRepository _normaIntMonColonialRepository;

        public NormaIntMonColonialService(
            INormaIntMonColonialRepository normaIntMonColonialRepository
            )
        {
            _normaIntMonColonialRepository = normaIntMonColonialRepository;
        }
        public async Task<int> CrearOActualizarAsync(NormaIntMonColonialDto peticion)
        {
            

            var id = peticion.IdNormaIntMonColonial;

            var entidad = await _normaIntMonColonialRepository.BuscarPorIdAsync(id);

            if (entidad == null)
            {
                entidad = new NormaIntMonColonial();
            }

            var idNormaInteres = new int();
            if (peticion.NormaInteres != null)
            {
                idNormaInteres = peticion.NormaInteres.IdNormaInteres != 0 ? peticion.NormaInteres.IdNormaInteres : new int();
            }

            //if (idNormaInteres == 0)
            //{
            //    return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "Id Norma interes es requerido en Normas legales monumento coloquial, es requerido");
            //}

            entidad.NumPlano = peticion.NumPlano;
            entidad.Fecha = peticion.Fecha;
            entidad.IdMonumentoColonial = peticion.IdMonumentoColonial;
            entidad.IdNormaInteres = idNormaInteres;

            var response = 0;
            if (entidad.IdNormaInteres == 0)
            {
                var entity =  await _normaIntMonColonialRepository.Create(entidad);
                response = entity.IdNormaIntMonColonial;
            }
            else
            {
                //entidad.Estado = 1;
                var entity = await _normaIntMonColonialRepository.Edit(entidad.IdNormaIntMonColonial, entidad);
                response = entity.IdNormaIntMonColonial;
            }

            //await _normaIntMonColonialRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;

        }

        //public async Task<int> CrearAsync(NormaIntMonColonialDto peticion)
        //{
        //    var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<long>>(peticion);

        //    if (!operacionValidacion.Completado)
        //    {
        //        return operacionValidacion;
        //    }

        //    var idNormaInteres = new long();
        //    if (peticion.NormaInteres != null)
        //    {
        //        idNormaInteres = !string.IsNullOrWhiteSpace(peticion.NormaInteres.Id) ? RijndaelUtilitario.DecryptRijndaelFromUrl<long>(peticion.NormaInteres.Id) : new long();
        //    }

        //    if (idNormaInteres == 0)
        //    {
        //        return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "Id Norma interes es requerido en Normas legales monumento coloquial, es requerido");
        //    }

        //    var normaIntMonColonial = new NormaIntMonColonial
        //    {
        //        NumPlano = peticion.NumPlano,
        //        Fecha = peticion.Fecha,
        //        IdMonumentoColonial = peticion.IdMonumentoColonial,
        //        IdNormaInteres = idNormaInteres
        //    };


        //    _normaIntMonColonialRepositorio.Insertar(normaIntMonColonial);
        //    await _normaIntMonColonialRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

        //    return new OperacionDto<RespuestaSimpleDto<long>>(new RespuestaSimpleDto<long>()
        //    {
        //        Id = normaIntMonColonial.Id,
        //        Mensaje = "Se guardó correctamente"
        //    });

        //}

        public async Task<bool> EliminarPorIdMonumentoColonialAsync(int idMonumentoColonial)
        {
            var lista = await _normaIntMonColonialRepository.ListarPorIdMonumentoColonialAsync(idMonumentoColonial);

            foreach (var item in lista)
            {
                item.Estado = false;
                _normaIntMonColonialRepository.Edit(item.IdNormaIntMonColonial,item);
                //_normaIntMonColonialRepositorio.Eliminar(item);
            }

            //await _normaIntMonColonialRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return true;
        }
    }
}
