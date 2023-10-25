using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones.Maps
{
    public class ValorizacionBusquedaProfileAction : IMappingAction<Ficha, ValorizacionBusquedaDto>
    {
        public void Process(Ficha source, ValorizacionBusquedaDto destination, ResolutionContext context)
        {
            var ficha = source;
            destination.Anio = ficha.AnioFicha.ToString();

            if(ficha.UnidadCatastral != null)
            {
                if(ficha.UnidadCatastral.TblCodigo.Count > 0)
                {
                    destination.CodigoUbigeo = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodDistrito;
                    destination.CodigoSector = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodSector;
                    destination.CodigoManzana = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodManzana;
                    destination.CodigoLote = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodLote;
                    destination.CodigoEdif = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodEdif;
                    destination.CodigoEnt = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodEnt;
                    destination.CodigoPiso = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodPiso;
                    destination.CodigoUnid = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.CodUnid;
                    destination.DigitoControl = ficha.UnidadCatastral?.TblCodigo?.FirstOrDefault()?.DigitoControl;
                }
            }

            List<Construccion> listaConstrucciones = new List<Construccion>();

            if (ficha.Construcciones.Count > 0)
            {
                foreach (var item in ficha.Construcciones)
                {
                    listaConstrucciones.Add(item);
                }
            }


            // Cálculo de ValorTotalConstruccion
            decimal? valorConstrucciones = 0;
            foreach (var item in listaConstrucciones)
            {
                var valor = item.ValorConstruccion != null ? item.ValorConstruccion : 0;
                valorConstrucciones += valor;
            }
            destination.ValorTotalConstruccion = (decimal)valorConstrucciones;


            // Cálculo ValorizacionTotal
            destination.ValorizacionTotal = (destination.ValorTerreno ?? 0) + destination.ValorTotalConstruccion;
        }
    }
}
