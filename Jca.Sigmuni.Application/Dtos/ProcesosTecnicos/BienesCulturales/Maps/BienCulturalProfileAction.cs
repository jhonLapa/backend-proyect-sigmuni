using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosPrehispanicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonColoniales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.BienesCulturales.Maps
{
    public class BienCulturalProfileAction : IMappingAction<Ficha, BienCulturalDto>
    {
        public void Process(Ficha source, BienCulturalDto destination, ResolutionContext context)
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

                if (source.FichaBienCulturales != null && source.FichaBienCulturales.Count > 0)
                {

                    destination.DatoAdicinalFicha = context.Mapper.Map<FichaBienCulturalDto>(source.FichaBienCulturales.FirstOrDefault());

                    if (source.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico != null && source.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico.Count > 0)
                    {
                        destination.MonumentoPrehispanico = context.Mapper.Map<MonumentoPrehispanicoDto>(source.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault());
                        List<Sunarp> listaRegistroPrediosMonumentoPre = new List<Sunarp>();
                        foreach (var item in source.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().Sunarp)
                        {
                            if (item.Estado == true)
                            {
                                listaRegistroPrediosMonumentoPre.Add(item);
                            }
                        }
                        if (listaRegistroPrediosMonumentoPre != null && listaRegistroPrediosMonumentoPre.Count > 0)
                        {
                            destination.RegistroPrediosMonumentoPre = context.Mapper.Map<List<SunarpDto>>(listaRegistroPrediosMonumentoPre);
                        }

                        List<NormaIntMonPrehi> listaNormaInteresMonPreinspanico = new List<NormaIntMonPrehi>();
                        foreach (var item in source.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().NormaIntMonPreins)
                        {
                            if (item.Estado == true)
                            {
                                listaNormaInteresMonPreinspanico.Add(item);
                            }
                        }
                        if (listaNormaInteresMonPreinspanico != null && listaNormaInteresMonPreinspanico.Count > 0)
                        {
                            destination.NormaInteresMonPreinspanico = context.Mapper.Map<List<NormaIntMonPrehiDto>>(listaNormaInteresMonPreinspanico);
                        }
                        //if (source.FichaBienCultural.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().Sunarp != null && source.FichaBienCultural.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().Sunarp.Count > 0)
                        //{
                        //    destination.RegistroPrediosMonumentoPre = context.Mapper.Map<List<SunarpDto>>(source.FichaBienCultural.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().Sunarp);
                        //}
                        //if (source.FichaBienCultural.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().NormaIntMonPreins != null && source.FichaBienCultural.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().NormaIntMonPreins.Count > 0)
                        //{
                        //    destination.NormaInteresMonPreinspanico = context.Mapper.Map<List<NormaIntMonPreinsDto>>(source.FichaBienCultural.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().NormaIntMonPreins);
                        //}
                    }
                    if (source.FichaBienCulturales.FirstOrDefault().MonumentoColonial != null && source.FichaBienCulturales.FirstOrDefault().MonumentoColonial.Count > 0)
                    {
                        destination.InfoMonumentoColonial = context.Mapper.Map<MonumentoColonialDto>(source.FichaBienCulturales.FirstOrDefault().MonumentoColonial.FirstOrDefault());
                        if(source.FichaBienCulturales?.FirstOrDefault()?.MonumentoColonial?.FirstOrDefault().Sunarp != null)
                        {
                            List<Sunarp> listaRegistroPrediosMonumentoColonial = new List<Sunarp>();
                            foreach (var item in source.FichaBienCulturales.FirstOrDefault().MonumentoColonial.FirstOrDefault().Sunarp)
                            {
                                if (item.Estado == true)
                                {
                                    listaRegistroPrediosMonumentoColonial.Add(item);
                                }
                            }
                            if (listaRegistroPrediosMonumentoColonial != null && listaRegistroPrediosMonumentoColonial.Count > 0)
                            {
                                destination.RegistroPrediosMonumentoColonial = context.Mapper.Map<List<SunarpDto>>(listaRegistroPrediosMonumentoColonial);
                            }
                        }
                        if (source.FichaBienCulturales.FirstOrDefault().MonumentoColonial.FirstOrDefault().NormaIntMonColonial != null)
                        {
                            List<NormaIntMonColonial> listaNormaInteresMonColonial = new List<NormaIntMonColonial>();
                            foreach (var item in source.FichaBienCulturales.FirstOrDefault().MonumentoColonial.FirstOrDefault().NormaIntMonColonial)
                            {
                                if (item.Estado == true)
                                {
                                    listaNormaInteresMonColonial.Add(item);
                                }
                            }
                            if (listaNormaInteresMonColonial != null && listaNormaInteresMonColonial.Count > 0)
                            {
                                destination.NormaInteresMonColonial = context.Mapper.Map<List<NormaIntMonColonialDto>>(listaNormaInteresMonColonial);
                            }
                        }
                        //if (source.FichaBienCultural.FirstOrDefault().MonumentoColonial.FirstOrDefault().Sunarp != null && source.FichaBienCultural.FirstOrDefault().MonumentoColonial.FirstOrDefault().Sunarp.Count > 0)
                        //{
                        //    destination.RegistroPrediosMonumentoColonial = context.Mapper.Map<List<SunarpDto>>(source.FichaBienCultural.FirstOrDefault().MonumentoColonial.FirstOrDefault().Sunarp);
                        //}
                        //if (source.FichaBienCultural.FirstOrDefault().MonumentoColonial.FirstOrDefault().NormaIntMonColonial != null && source.FichaBienCultural.FirstOrDefault().MonumentoColonial.FirstOrDefault().NormaIntMonColonial.Count > 0)
                        //{
                        //    destination.NormaInteresMonColonial = context.Mapper.Map<List<NormaIntMonColonialDto>>(source.FichaBienCultural.FirstOrDefault().MonumentoColonial.FirstOrDefault().NormaIntMonColonial);
                        //}
                    }
                }

                if (source.TitularCatastral != null && source.TitularCatastral.Count > 0)
                {
                    //destination.CaracteristicaTitularidad = context.Mapper.Map<CaracteristicaTitularidadDto>(source.TitularCatastral.FirstOrDefault().CaracteristicaTitularidad);
                    if (source.TitularCatastral.FirstOrDefault().Persona != null)
                    {
                        destination.Titular = context.Mapper.Map<PersonaTitularDto>(source.TitularCatastral.FirstOrDefault().Persona);
                        destination.Titular.IdTitularCatastral = source.TitularCatastral.FirstOrDefault().IdTitularCatastral;
                        destination.Titular.CodigoContribuyente = source.TitularCatastral.FirstOrDefault().CodContribuyente;
                        if (source.TitularCatastral.FirstOrDefault().Dependientes != null && source.TitularCatastral.FirstOrDefault().Dependientes.Count > 0)
                        {
                            destination.Titular.Conyuge = context.Mapper.Map<ConyugeTitularDto>(source.TitularCatastral.FirstOrDefault().Dependientes.FirstOrDefault().Persona);
                        }
                    }
                }

                if (source.Litigantes != null)
                {
                    var naturalLitigante = new List<PersonaLitiganteDto>();
                    var juridicoLitigante = new List<PersonaLitiganteJuridicoDto>();
                    var conyugeLitigante = new List<ConyugeLitiganteDto>();
                    foreach (var item in source.Litigantes)
                    {
                        if (item.Persona != null)
                        {
                            //if (!string.IsNullOrWhiteSpace(item.Persona.NumeroDni))
                            //{
                            var natural = context.Mapper.Map<PersonaLitiganteDto>(item);
                            naturalLitigante.Add(natural);

                            if (item.Dependientes != null && item.Dependientes.Count > 0)
                            {
                                foreach (var itemC in item.Dependientes)
                                {
                                    var conyugue = context.Mapper.Map<ConyugeLitiganteDto>(itemC.Persona);
                                    conyugeLitigante.Add(conyugue);
                                }
                            }
                            //}

                            if (!string.IsNullOrWhiteSpace(item.Persona.NumeroRuc))
                            {
                                var juridico = context.Mapper.Map<PersonaLitiganteJuridicoDto>(item);
                                juridicoLitigante.Add(juridico);
                            }
                        }


                    }
                    destination.NaturalLitigante = naturalLitigante;
                    destination.JuridicoLitigante = juridicoLitigante;
                    destination.ConyugesLitigante = conyugeLitigante;
                }

                if (source.InfoComplementarios != null)
                {
                    destination.InfoComplementaria = context.Mapper.Map<InfoComplementarioDto>(source.InfoComplementarios.FirstOrDefault());
                }

                if (source.Declarantes != null && source.Declarantes.Count > 0)
                {
                    destination.DeclaranteInfo = context.Mapper.Map<DeclarantePersonaDto>(source.Declarantes.FirstOrDefault().Persona);
                    destination.DeclaranteInfo.CondicionPer = context.Mapper.Map<CondicionPerDto>(source.Declarantes.FirstOrDefault().CondicionPer);
                    destination.DeclaranteInfo.IdDeclarante = source.Declarantes.FirstOrDefault().IdDeclarante;
                    destination.DeclaranteInfo.Fecha = source.Declarantes.FirstOrDefault().Fecha;
                    destination.DeclaranteInfo.TieneFirma = source.Declarantes.FirstOrDefault().TieneFirma;
                }

                if (source.Supervisores != null && source.Supervisores.Count > 0)
                {
                    destination.SupervisorInfo = context.Mapper.Map<SupervisorPersonaDto>(source.Supervisores.FirstOrDefault().Persona);
                    destination.SupervisorInfo.IdSupervisor = source.Supervisores.FirstOrDefault().IdSupervisor;
                    destination.SupervisorInfo.Fecha = source.Supervisores.FirstOrDefault().Fecha;
                    destination.SupervisorInfo.TieneFirma = source.Supervisores.FirstOrDefault().TieneFirma;
                }

                if (source.TecnicoCatastrales != null && source.TecnicoCatastrales.Count > 0)
                {
                    destination.TecnicoInfo = context.Mapper.Map<TecnicoCatastralPersonaDto>(source.TecnicoCatastrales.FirstOrDefault().Persona);
                    destination.TecnicoInfo.IdTecnico = source.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;
                    destination.TecnicoInfo.Fecha = source.TecnicoCatastrales.FirstOrDefault().Fecha;
                    destination.TecnicoInfo.TieneFirma = source.TecnicoCatastrales.FirstOrDefault().TieneFirma;
                }
            }
        }
    }
}
