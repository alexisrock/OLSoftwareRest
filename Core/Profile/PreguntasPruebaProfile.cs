using Domain.DTO;
using Domain.Entities;
 

namespace Core.Profile
{
    public class PreguntasPruebaProfile : AutoMapper.Profile
    {

        public PreguntasPruebaProfile()
        {
            CreateMap<PreguntasPrueba, PreguntasPruebaResponse>()
             .ReverseMap();

            CreateMap<PreguntasPrueba, PreguntasPruebaRequest>()
            .ReverseMap();
            
        }
    }
}
