using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class TblCodigoService : ITblCodigoService
    {
        private readonly IMapper _mapper;
        private readonly ITblCodigoRepository _tblCodigoRepository;
        private readonly IFichaRepository _fichaRepository;
        private readonly IUnidadCatastralRepository _unidadCatastralRepository;

        public TblCodigoService(IMapper mapper, 
                                ITblCodigoRepository tblCodigoRepository,
                                IUnidadCatastralRepository unidadCatastralRepository,
                                IFichaRepository fichaRepository)
        {
            _mapper = mapper;
            _tblCodigoRepository = tblCodigoRepository;
            _unidadCatastralRepository = unidadCatastralRepository;
            _fichaRepository = fichaRepository;
        }

        public async Task<TblCodigoCatastralDto> BuscarPorIdFichaAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindByIdAsync(idFicha);

            if (ficha == null) throw new Exception("La Ficha no existe");

            var entidad = await _tblCodigoRepository.BuscarPorIdUnidadCatastralAsync(ficha.IdUnidadCatastral);

            var dto = _mapper.Map<TblCodigoCatastralDto>(entidad);
            return dto;
        }

        public async Task<TblCodigo?> CrearOActualizarCodigoCatastralAsync(TblCodigoCatastralDto peticion)
        {
            var unidadadCatastral = await _unidadCatastralRepository.Find(peticion.IdUnidadCatastral);

            var idCodigoCatastral = default(int);

            if (unidadadCatastral.TblCodigo != null && unidadadCatastral.TblCodigo.Count > 0)
            {

                foreach (var item in unidadadCatastral.TblCodigo)
                {
                    switch (item.FlagTipo)
                    {
                        case FlagTipoCodigo.CodigoCatastral:
                            idCodigoCatastral = item.IdTblCodigo;
                            break;
                    }
                }
            }

            var tblCodigo = await _tblCodigoRepository.Find(idCodigoCatastral);

            if (tblCodigo == null)
            {
                tblCodigo = new TblCodigo();
            }


            tblCodigo.CodDistrito = peticion.CodDistrito;
            tblCodigo.CodSector = peticion.CodSector;
            tblCodigo.CodManzana = peticion.CodManzana;
            tblCodigo.CodLote = peticion.CodLote;
            tblCodigo.CodEdif = peticion.CodEdif;
            tblCodigo.CodEnt = peticion.CodEnt;
            tblCodigo.CodPiso = peticion.CodPiso;
            tblCodigo.CodUnid = peticion.CodUnid;
            tblCodigo.DigitoControl = peticion.DigitoControl;
            tblCodigo.FlagTipo = FlagTipoCodigo.CodigoCatastral;
            tblCodigo.IdUnidadCatastral = peticion.IdUnidadCatastral;


            if (tblCodigo.IdTblCodigo == 0)
            {
                return await _tblCodigoRepository.Create(tblCodigo);
            }
            else
            {
                return await _tblCodigoRepository.Edit(tblCodigo.IdTblCodigo, tblCodigo);
            }
        }

        public async Task<TblCodigo?> CrearOActualizarCodigoCatastralReferencialAsync(TblCodigoCatastralRefDto peticion)
        {
            var unidadadCatastral = await _unidadCatastralRepository.Find(peticion.IdUnidadCatastral);

            var idCodigoCatastral = default(int);

            if (unidadadCatastral.TblCodigo != null && unidadadCatastral.TblCodigo.Count > 0)
            {

                foreach (var item in unidadadCatastral.TblCodigo)
                {
                    switch (item.FlagTipo)
                    {
                        case FlagTipoCodigo.CodigoCatastralReferencial:
                            idCodigoCatastral = item.IdTblCodigo;
                            break;
                    }
                }
            }

            var tblCodigo = await _tblCodigoRepository.Find(idCodigoCatastral);

            if (tblCodigo == null)
            {
                tblCodigo = new TblCodigo();
            }

            tblCodigo.CodDepartamento = peticion.CodDepartamento;
            tblCodigo.CodProvincia = peticion.CodProvincia;
            tblCodigo.CodDistrito = peticion.CodDistrito;
            tblCodigo.CodSector = peticion.CodSector;
            tblCodigo.CodManzana = peticion.CodManzana;
            tblCodigo.CodLote = peticion.CodLote;
            tblCodigo.CodEdif = peticion.CodEdif;
            tblCodigo.CodEnt = peticion.CodEnt;
            tblCodigo.CodPiso = peticion.CodPiso;
            tblCodigo.CodUnid = peticion.CodUnid;
            tblCodigo.DigitoControl = peticion.DigitoControl;
            tblCodigo.FlagTipo = FlagTipoCodigo.CodigoCatastralReferencial;
            tblCodigo.IdUnidadCatastral = peticion.IdUnidadCatastral;


            if (tblCodigo.IdTblCodigo == 0)
            {
                return await _tblCodigoRepository.Create(tblCodigo);
            }
            else
            {
                return await _tblCodigoRepository.Edit(tblCodigo.IdTblCodigo, tblCodigo);
            }
        }

        public async Task<ResponsePagination<TblCodigoCatastralDto>> PaginatedSearch(RequestPagination<TblCodigoCatastralDto> dto)
        {
            throw new NotImplementedException();
        }
    }
}
