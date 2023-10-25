using System;
namespace Jca.Sigmuni.Application.Core.Services
{
	public interface IServiceEditable<TDto, TFormDto, K>
    {
        Task<TDto?> Edit(K id, TFormDto dto);
        Task<TDto?> Disable(K id);
    }
}

