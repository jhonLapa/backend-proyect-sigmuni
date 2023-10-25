using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.General.Perfiles.Maps
{
    public class PerfilFormProfile : Profile
    {
        public PerfilFormProfile()
        {
            CreateMap<Domain.General.Perfil, PerfilFormDto>().ReverseMap();
        }
    }
}
