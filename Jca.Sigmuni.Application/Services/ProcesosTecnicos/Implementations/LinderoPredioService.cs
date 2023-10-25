using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.LinderoPredios;
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
    public class LinderoPredioService : ILinderoPredioService
    {
        private readonly IMapper _mapper;
        private readonly ILinderoPredioRepository _linderoPredioRepository;

        public LinderoPredioService(IMapper mapper,
                                    ILinderoPredioRepository linderoPredioRepository)
        {
            _mapper = mapper;
            _linderoPredioRepository = linderoPredioRepository;
        }

        public async Task<LinderoPredio?> CrearOActualizarAsync(LinderoPredioDto peticion)
        {
            var id = peticion.Id;

            var linderoPredio = await _linderoPredioRepository.Find(id);
            if (linderoPredio == null)
            {
                linderoPredio = new LinderoPredio();
            }

            linderoPredio.MedidaFrenteCampo = peticion.MedidaFrenteCampo;
            linderoPredio.MedidaFrenteTitulo = peticion.MedidaFrenteTitulo;
            linderoPredio.ColindaFrenteCampo = peticion.ColindaFrenteCampo;
            linderoPredio.ColindaFrenteTitulo = peticion.ColindaFrenteTitulo;
            linderoPredio.MedidaDerechaCampo = peticion.MedidaDerechaCampo;
            linderoPredio.MedidaDerechaTitulo = peticion.MedidaDerechaTitulo;
            linderoPredio.ColindaDerechaCampo = peticion.ColindaDerechaCampo;
            linderoPredio.ColindaDerechaTitulo = peticion.ColindaDerechaTitulo;
            linderoPredio.MedidaIzquierdaCampo = peticion.MedidaIzquierdaCampo;
            linderoPredio.MedidaIzquierdaTitulo = peticion.MedidaIzquierdaTitulo;
            linderoPredio.ColindaIzquierdaCampo = peticion.ColindaIzquierdaCampo;
            linderoPredio.ColindaIzquierdaTitulo = peticion.ColindaIzquierdaTitulo;
            linderoPredio.MedidaFondoCampo = peticion.MedidaFondoCampo;
            linderoPredio.MedidaFondoTitulo = peticion.MedidaFondoTitulo;
            linderoPredio.ColindaFondoCampo = peticion.ColindaFondoCampo;
            linderoPredio.ColindaFondoTitulo = peticion.ColindaFondoTitulo;

            if (linderoPredio.Id == 0)
            {
                linderoPredio.Id = id;
                return await _linderoPredioRepository.Create(linderoPredio);
            }
            else
            {
                return await _linderoPredioRepository.Edit(linderoPredio.Id, linderoPredio);
            }
        }
    }
}
