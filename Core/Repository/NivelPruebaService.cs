using AutoMapper;
using Core.Interfaces;
using DataAccess.Interface;
using Domain.DTO;
using Domain.Entities;

namespace Core.Repository
{
    public class NivelPruebaService : INivelPruebaService
    {

        private readonly IRepository<NivelPrueba> nivelPruebaRepository;
        private readonly IMapper mapper;
        public NivelPruebaService(IRepository<NivelPrueba> nivelPruebaRepository, IMapper mapper)
        {
            this.nivelPruebaRepository = nivelPruebaRepository;
            this.mapper = mapper;
        }           

        
        public async Task<List<NivelPruebaResponse>> GetAll()
        {
            var listNivelPrueba = await nivelPruebaRepository.GetAll();
            var list = MapperListesponse(listNivelPrueba);
            return list;
        }
        private List<NivelPruebaResponse> MapperListesponse(List<NivelPrueba> listNivelPrueba)
        {
            List<NivelPruebaResponse> listResponse = new List<NivelPruebaResponse>();

            listNivelPrueba.ForEach(c =>
            {
                var nivelPruebaResponse = mapper.Map<NivelPruebaResponse>(c);
                listResponse.Add(nivelPruebaResponse);
            });
            return listResponse;
        }

    }
}
