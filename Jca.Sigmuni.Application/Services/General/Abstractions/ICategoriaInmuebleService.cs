using Jca.Sigmuni.Application.Dtos.General.CategoriaInmuebles;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ICategoriaInmuebleService
    {
        Task<IList<CategoriaInmuebleDto>> FindAll();
    }
}
