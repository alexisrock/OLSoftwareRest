using Domain.DTO;
using Domain.Entities;
using AutoMapper;


namespace Core.Profile
{
    public class EstadoPruebaProfile : AutoMapper.Profile
    {

     
        public EstadoPruebaProfile()
        {
            CreateMap<EstadoPrueba, EstadoPruebaResponse>()
              .ReverseMap();
        }
    }
}
