using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaDocumentos;
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
    public class FichaDocumentoService : IFichaDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IFichaDocumentoRepository _fichaDocumentoRepository;

        public FichaDocumentoService(IMapper mapper,
                                     IFichaDocumentoRepository fichaDocumentoRepository)
        {
            _mapper = mapper;
            _fichaDocumentoRepository = fichaDocumentoRepository;
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _fichaDocumentoRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _fichaDocumentoRepository.EliminarAsync(item.IdFichaDocumento);
            }

            return response;
        }

        public async Task<FichaDocumento> CrearAsync(FichaDocumentoDto peticion)
        {
            var idTipoDocumentoPresentado = default(int?);
            if (peticion.TipoDocumentoPresentado != null)
            {
                idTipoDocumentoPresentado = peticion.TipoDocumentoPresentado.IdTipoDocumentoFicha != 0 ? peticion.TipoDocumentoPresentado.IdTipoDocumentoFicha : new int?();
            }

            var idArea = default(int?);
            if (peticion.Area != null)
            {
                idArea = peticion.Area.Id != 0 ? peticion.Area.Id : new int?();
            }

            var fichaDocumento = new FichaDocumento
            {
                NumeroDocumento = peticion.NumeroDocumento,
                Fecha = peticion.Fecha,
                TotalArea = peticion.TotalArea,
                IdFicha = peticion.IdFicha,
                IdTipoDocumento = idTipoDocumentoPresentado,
            };

            return await _fichaDocumentoRepository.Create(fichaDocumento);
        }
    }
}
