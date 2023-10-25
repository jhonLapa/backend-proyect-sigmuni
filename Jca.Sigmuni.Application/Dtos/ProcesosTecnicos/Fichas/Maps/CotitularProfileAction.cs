using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CotitularesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class CotitularProfileAction : IMappingAction<Ficha, FichaCotitularDto>
    {
        public void Process(Ficha source, FichaCotitularDto destination, ResolutionContext context)
        {
            destination.Ficha = context.Mapper.Map<FichaDto>(source);

            if (source.UnidadCatastral != null)
            {
                destination.UnidadCatastral = context.Mapper.Map<UnidadCatastralDto>(source.UnidadCatastral);

                if (source.UnidadCatastral.TblCodigo != null && source.UnidadCatastral.TblCodigo.Count > 1)
                {
                    foreach (var item in source.UnidadCatastral.TblCodigo)
                    {
                        switch (item.FlagTipo)
                        {
                            case FlagTipoCodigo.CodigoCatastral:
                                destination.CodigoCatastral = context.Mapper.Map<TblCodigoCatastralDto>(item);
                                break;
                            case FlagTipoCodigo.CodigoCatastralReferencial:
                                destination.CodigoCatastralRef = context.Mapper.Map<TblCodigoCatastralRefDto>(item);
                                break;
                        }
                    }
                }


                if (source.TitularCatastral != null && source.TitularCatastral.Count > 0)
                {
                    //var listaTitulares = source.TitularCatastral.OrderBy(e => e.NumTitularidad);
                    //destination.Cotitulares = context.Mapper.Map<List<CotitularCatastralDto>>(listaTitulares);
                    destination.Cotitulares = context.Mapper.Map<List<CotitularCatastralDto>>(source.TitularCatastral.OrderBy(e => e.NumTitularidad));
                }

                if (source.InfoComplementarios.Count > 0)
                {
                    destination.InfoComplementario = context.Mapper.Map<InfoComplementarioDto>(source.InfoComplementarios.FirstOrDefault());
                }

                #region "Individual info"


                if (source.Declarantes != null && source.Declarantes.Count > 0)
                {
                    destination.DeclaranteInfo = context.Mapper.Map<DeclarantePersonaDto>(source.Declarantes.FirstOrDefault().Persona);
                    if (destination.DeclaranteInfo == null) destination.DeclaranteInfo = new DeclarantePersonaDto();

                    destination.DeclaranteInfo.CondicionPer = context.Mapper.Map<CondicionPerDto>(source.Declarantes.FirstOrDefault().CondicionPer);
                    destination.DeclaranteInfo.IdDeclarante = source.Declarantes.FirstOrDefault().IdDeclarante;
                    destination.DeclaranteInfo.Fecha = source.Declarantes.FirstOrDefault().Fecha;
                    destination.DeclaranteInfo.TieneFirma = source.Declarantes.FirstOrDefault().TieneFirma;
                }

                //if (source.Supervisores != null && source.Supervisores.Count > 0)
                //{
                //    destination.SupervisorInfo = context.Mapper.Map<SupervisorPersonaDto>(source.Supervisores.FirstOrDefault().Persona);
                //    if (destination.SupervisorInfo == null) destination.SupervisorInfo = new SupervisorPersonaDto();

                //    destination.SupervisorInfo.IdSupervisor = source.Supervisores.FirstOrDefault().IdSupervisor;
                //    destination.SupervisorInfo.Fecha = source.Supervisores.FirstOrDefault().Fecha;
                //    destination.SupervisorInfo.TieneFirma = source.Supervisores.FirstOrDefault().TieneFirma;
                //}

                //if (source.TecnicoCatastrales != null && source.TecnicoCatastrales.Count > 0)
                //{
                //    destination.TecnicoInfo = context.Mapper.Map<TecnicoCatastralPersonaDto>(source.TecnicoCatastrales.FirstOrDefault().Persona);
                //    if (destination.TecnicoInfo == null) destination.TecnicoInfo = new TecnicoCatastralPersonaDto();
                //    destination.TecnicoInfo.IdTecnico = source.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;
                //    destination.TecnicoInfo.Fecha = source.TecnicoCatastrales.FirstOrDefault().Fecha;
                //    destination.TecnicoInfo.TieneFirma = source.TecnicoCatastrales.FirstOrDefault().TieneFirma;
                //}

                #endregion
            }
        }
    }
}
