using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones.Maps
{
    public class ValorConstruccionProfileAction : IMappingAction<Construccion, ValorConstruccionDto>
    {
        public void Process(Construccion source, ValorConstruccionDto destination, ResolutionContext context)
        {
            if (source.Ficha.IdTipoFicha == (int)TipoFichaEnum.Individual)
            {
                destination.TipoNivel = "PIS";
            }
            else if (source.Ficha.IdTipoFicha == (int)TipoFichaEnum.BienesComunes)
            {
                destination.TipoNivel = "BC";
            }

            if (source.NumeroPiso != null)
            {
                destination.Nivel = source.NumeroPiso;
            }

            if (source.MesAnio != null)
            {
                destination.AnioConstruccion = source.MesAnio?.Year.ToString();
            }

            #region "Depreciacion"
            var idClasificacionPredioUC = default(int);
            if (source.Ficha.DescripcionPredios.Count > 0)
            {
                if (source.Ficha.DescripcionPredios.FirstOrDefault().ClasificacionPredio != null)
                {
                    idClasificacionPredioUC = source.Ficha.DescripcionPredios.FirstOrDefault().ClasificacionPredio.IdClasificacionPredio;
                    destination.Clasificacion = source.Ficha.DescripcionPredios.FirstOrDefault().ClasificacionPredio.Descripcion;
                }
            }

            if (source.Mep != null)
            {
                destination.MaterialPredominante = source.Mep.Descripcion;
            }

            if (source.Ecs != null)
            {
                destination.EstadoConservacion = source.Ecs.Descripcion;
            }
            #endregion
        }
    }
}
