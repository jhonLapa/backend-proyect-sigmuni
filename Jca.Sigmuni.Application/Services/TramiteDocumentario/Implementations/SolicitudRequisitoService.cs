using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class SolicitudRequisitoService : ISolicitudRequisitoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISolicitudRequisitoRepository _solicitudRequisitoRepository;

        public SolicitudRequisitoService(ApplicationDbContext context,IMapper mapper,ISolicitudRequisitoRepository solicitudRequisitoRepository)
        {
            _context = context;
            _mapper = mapper;
            _solicitudRequisitoRepository= solicitudRequisitoRepository;
        }

        public async Task<bool> ActualizarRevisionRequisitoPresentadoAsync(int idSolicitudRequisito, string revision)
        {
            var response = false;
            var idSolicitudRequisitoReg = idSolicitudRequisito;
            var solicitudRequisito = await _context.SolicitudRequisitos.FindAsync(idSolicitudRequisitoReg);

            if (solicitudRequisito == null) 
            {
                //validacion
                response = false;
            }
            else
            {
                if (revision == "SI")
                {
                    var flag = "2";
                    solicitudRequisito.Flag = flag;
                    _context.SolicitudRequisitos.Update(solicitudRequisito);
                    response= true;
                }
                else 
                {
                    var flag = "3";
                    solicitudRequisito.Flag= flag;
                    _context.SolicitudRequisitos.Update(solicitudRequisito);
                    response = true;

                }
            }

            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<SolicitudRequisitoDto> EliminarDocumentoSolicitudRequisito(int idSolicitudRequisito)
        {
            var response = await _solicitudRequisitoRepository.EliminarDocumentoSolicitudRequisito(idSolicitudRequisito);
            return _mapper.Map<SolicitudRequisitoDto>(response);
        }
    }
}
