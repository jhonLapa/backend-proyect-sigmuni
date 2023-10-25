using System;
namespace Jca.Sigmuni.Application.Core.Services
{
	public interface IServiceCrud<TDto, TFormDto, K> : IServiceBase<TDto, TFormDto, K>, IServiceEditable<TDto, TFormDto, K>
    {
	}
}

