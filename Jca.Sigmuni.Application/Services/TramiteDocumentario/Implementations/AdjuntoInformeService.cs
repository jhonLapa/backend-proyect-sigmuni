using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeDocumentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class AdjuntoInformeService : IAdjuntoInformeService
    {
        private readonly IMapper _mapper;
        private readonly IAdjuntoInformeRepository _adjuntoInformeRepository;
        private readonly IDocumentoService _documentoService;
        public AdjuntoInformeService(
            IMapper mapper,
            IAdjuntoInformeRepository adjuntoInformeRepository,
              IDocumentoService documentoService
        )

        {
            _mapper = mapper;
            _adjuntoInformeRepository = adjuntoInformeRepository;
            _documentoService = documentoService;

        }

        public async Task<bool> AdjuntarDocumentoAsync(InformeDocumento peticion)
        {


            var Correcto = true ;




            if (peticion.Documento != null)
            {
                var responseDocumento = await _documentoService.Create(peticion.Documento);
                peticion.IdDocumentoB64 = responseDocumento.IdDocumentoB64;
            }



            var entidad = await _adjuntoInformeRepository.BuscarInformeDocumento(peticion.IdInformeTecnico, peticion.Flag);

            if (entidad == null)
            {
                entidad = new AdjuntoInforme();
            }

            //flag tipo_documento
            //1 = dentro_informe
            //2 = fuera_informe

            entidad.Descripcion = peticion.Descripcion;
            entidad.Estado = true;

            entidad.IdDocumento = peticion.IdDocumentoB64;
            entidad.IdInformeTecnico = peticion.IdInformeTecnico;
            entidad.Flag = peticion.Flag;

            if (entidad.Id == 0)
            {
                await _adjuntoInformeRepository.Create(entidad);
            }
            else
            {
               await _adjuntoInformeRepository.Edit(entidad.Id,entidad);
            }

          

            return Correcto;
        }

        public async Task<bool> AdjuntarDocumentoDescripcionAsync(InformeDocumento peticion)
        {


            var Correcto = true;




            if (peticion.Documento != null)
            {
                var responseDocumento = await _documentoService.Create(peticion.Documento);
                peticion.IdDocumentoB64 = responseDocumento.IdDocumentoB64;
            }



            var entidad = await _adjuntoInformeRepository.BuscarInformeDocumentoDescripcionFalse(peticion.IdInformeTecnico, peticion.Flag , peticion.Descripcion);

            if (entidad == null)
            {
                entidad = new AdjuntoInforme();
            }

            //flag tipo_documento
            //1 = dentro_informe
            //2 = fuera_informe






            entidad.Descripcion = peticion.Descripcion;
            entidad.Estado = true;
          


            entidad.IdDocumento = peticion.IdDocumentoB64;
            entidad.IdInformeTecnico = peticion.IdInformeTecnico;
            entidad.Flag = peticion.Flag;

            if (entidad.Id == 0)
            {
                await _adjuntoInformeRepository.Create(entidad);
            }
            else
            {
                await _adjuntoInformeRepository.Edit(entidad.Id, entidad);
            }



            return Correcto;
        }

        public async Task<InformeDocumentoDto?> BuscarInformeDocumentoDescripcion(int idInforme, int flag, string descripcion)
        {
            var response = await _adjuntoInformeRepository.BuscarInformeDocumentoDescripcion(idInforme, flag , descripcion);


            if (response == null)
            {
                throw new Exception(" no está registrado.");
                return _mapper.Map<InformeDocumentoDto>(response);

            }

            return _mapper.Map<InformeDocumentoDto>(response);
        }

        public async Task<InformeDocumentoDto?> BuscarInformeDocumento(int idInforme, int flag)
        {
            var response = await _adjuntoInformeRepository.BuscarInformeDocumento(idInforme,flag);
            if (response == null)
            {
                throw new Exception(" no está registrado.");
                return _mapper.Map<InformeDocumentoDto>(response);

            }
            return _mapper.Map<InformeDocumentoDto>(response);
        }


        public async Task<bool> Disable(InformeDocumentoDto peticion)
        {

            var Correcto = true;

            if (peticion != null)
            {
                var buscar = await _adjuntoInformeRepository.BuscarPorIdAsync(peticion.Id);
                if (buscar == null)
                {
                    throw new Exception(" no está registrado.");
                    return Correcto;

                }
                var response = await _adjuntoInformeRepository.Disable(peticion.Id);



            }




            return Correcto;

        }
    }
}
