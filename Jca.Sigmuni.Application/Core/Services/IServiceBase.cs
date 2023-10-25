using System;
namespace Jca.Sigmuni.Application.Core.Services
{
	public interface IServiceBase<TDto, TFormDto, K>
    {
        Task<TDto> Create(TFormDto dto);
        Task<TDto?> Find(K id);
        Task<IList<TDto>> FindAll();
    }
}