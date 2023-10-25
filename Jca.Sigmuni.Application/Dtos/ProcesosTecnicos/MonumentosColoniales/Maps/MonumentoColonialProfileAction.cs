using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos;
using Jca.Sigmuni.Application.Dtos.General.EstadosAcabados;
using Jca.Sigmuni.Application.Dtos.General.FiliacionesEstilisticas;
using Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles;
using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones;
using Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales.Maps
{
    public class MonumentoColonialProfileAction : IMappingAction<MonumentoColonial, MonumentoColonialDto>
    {
        public void Process(MonumentoColonial source, MonumentoColonialDto destination, ResolutionContext context)
        {
            if (source.TipoArquitectura != null)
            {
                destination.TipoArquitectura = context.Mapper.Map<TipoArquitecturaDto>(source.TipoArquitectura);
            }
            if (source.UsoPredio != null)
            {
                destination.UsoPredio = context.Mapper.Map<UsoPredioDto>(source.UsoPredio);
            }
            if (source.UsoPredioOrginal != null)
            {
                destination.UsoOrginalPredio = context.Mapper.Map<UsoPredioDto>(source.UsoPredioOrginal);
            }
            if (source.TiempoConstruccion != null)
            {
                destination.TiempoConstruccion = context.Mapper.Map<TiempoConstruccionDto>(source.TiempoConstruccion);
            }
            if (source.ElementoArquitectonico != null)
            {
                destination.ElementoArquitectonico = context.Mapper.Map<ElementoArquitectonicoDto>(source.ElementoArquitectonico);
            }
            if (source.FiliacionEstilistica != null)
            {
                destination.FiliacionEstilistica = context.Mapper.Map<FiliacionEstilisticaDto>(source.FiliacionEstilistica);
            }
            if (source.EstadoCimiento != null)
            {
                destination.EstadoCimiento = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoCimiento);
            }
            if (source.EstadoMuro != null)
            {
                destination.EstadoMuro = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoMuro);
            }
            if (source.EstadoPiso != null)
            {
                destination.EstadoPiso = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoPiso);
            }
            if (source.EstadoTecho != null)
            {
                destination.EstadoTecho = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoTecho);
            }
            if (source.EstadoPilastra != null)
            {
                destination.EstadoPilastra = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoPilastra);
            }
            if (source.EstadoRevestimiento != null)
            {
                destination.EstadoRevestimiento = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoRevestimiento);
            }
            if (source.EstadoBalcon != null)
            {
                destination.EstadoBalcon = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoBalcon);
            }
            if (source.EstadoPuerta != null)
            {
                destination.EstadoPuerta = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoPuerta);
            }
            if (source.EstadoVentana != null)
            {
                destination.EstadoVentana = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoVentana);
            }
            if (source.EstadoReja != null)
            {
                destination.EstadoReja = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoReja);
            }
            if (source.EstadoOtro != null)
            {
                destination.EstadoOtro = context.Mapper.Map<EstadoAcabadoDto>(source.EstadoOtro);
            }
            if (source.IntervencionInmueble != null)
            {
                destination.IntervencionInmueble = context.Mapper.Map<IntervencionInmuebleDto>(source.IntervencionInmueble);
            }
            if (source.Observacion != null)
            {
                destination.Observacion = context.Mapper.Map<ObservacionDto>(source.Observacion);
            }
        }
    }
}
