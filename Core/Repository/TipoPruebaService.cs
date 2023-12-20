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
    public class TipoPruebaService : ITipoPruebaService
    {
        private readonly IRepository<TipoPrueba> tipoPruebaRepository;
        private readonly IMapper mapper;

        public TipoPruebaService(IRepository<TipoPrueba> tipoPruebaRepository, IMapper mapper)
        {
            this.tipoPruebaRepository = tipoPruebaRepository;
            this.mapper = mapper;
        }
        public async Task<List<TipoPruebaResponse>> GetAll()
        {
            var listTipoPrueba = await tipoPruebaRepository.GetAll();
            var list = MapperListesponse(listTipoPrueba);
            return list;
        }

        private List<TipoPruebaResponse> MapperListesponse(List<TipoPrueba> listTipoPrueba)
        {
            List<TipoPruebaResponse> listResponse = new List<TipoPruebaResponse>();

            listTipoPrueba.ForEach(c =>
            {
                var  tipoPruebaResponse = mapper.Map<TipoPruebaResponse>(c);
                listResponse.Add(tipoPruebaResponse);
            });
            return listResponse;
        }
    }
}
