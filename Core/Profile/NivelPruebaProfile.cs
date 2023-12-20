﻿
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Profile
{
    public class NivelPruebaProfile : AutoMapper.Profile
    {
        public NivelPruebaProfile()
        {
            CreateMap<NivelPrueba, NivelPruebaResponse>()
             .ReverseMap();
        }


    }
}
