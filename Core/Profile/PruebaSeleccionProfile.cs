using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Profile
{
    public class PruebaSeleccionProfile : AutoMapper.Profile
    {

        public PruebaSeleccionProfile() 
        {

            CreateMap<PruebaSeleccion, PruebaSeleccionResponse>()
             .ReverseMap();


            CreateMap<PruebaSeleccionRequest, PruebaSeleccion>()
           .ReverseMap();       ;
        }
    }
}
