using AutoMapper;
using Core.Interfaces;
using DataAccess.Interface;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class EstadoPruebaService : IEstadoPruebaService
    {

        private readonly IRepository<EstadoPrueba> estadoPruebaRepository;
        private readonly IMapper mapper;
        public EstadoPruebaService(IRepository<EstadoPrueba> estadoPruebaRepository, IMapper mappe)
        {
            this.estadoPruebaRepository = estadoPruebaRepository;
            this.mapper = mappe;
        }

        public async Task<List<EstadoPruebaResponse>> GetAll()
        {             
            var listEstadoPrueba = await estadoPruebaRepository.GetAll();
            var list = MapperListesponse(listEstadoPrueba);
            return list;
        }

        private List<EstadoPruebaResponse> MapperListesponse(List<EstadoPrueba> listEstadoPrueba)
        {
            List<EstadoPruebaResponse> listResponse = new List<EstadoPruebaResponse>();

            listEstadoPrueba.ForEach(c =>
            {
                var estadoPruebaResponse = mapper.Map<EstadoPruebaResponse>(c);              
                listResponse.Add(estadoPruebaResponse);
            });
            return listResponse;
        }


    }
}
