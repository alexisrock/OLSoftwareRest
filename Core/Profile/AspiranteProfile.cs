using Domain.DTO;
using Domain.Entities;


namespace Core.Profile
{
    public class AspiranteProfile : AutoMapper.Profile
    {

        public AspiranteProfile()
        {
            CreateMap<Aspirante, AspiranteResponse>()
             .ReverseMap();

            CreateMap<Aspirante, AspiranteRequest>()
             .ReverseMap();
        }

    
    }
}
