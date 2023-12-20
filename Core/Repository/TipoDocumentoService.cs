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
    public class TipoDocumentoService: ITipoDocumentoService
    {

        private readonly IRepository<TipoDocumento> tipoDocumentoRepository;
        private readonly IMapper mapper;
        public TipoDocumentoService(IRepository<TipoDocumento> tipoDocumentoRepository, IMapper mappe)
        {
            this.tipoDocumentoRepository = tipoDocumentoRepository;
            this.mapper = mappe;
        }  
              

        public async Task<List<TipoDocumentoResponse>> GetAll()
        {
            var listTipoDocumento= await tipoDocumentoRepository.GetAll();
            var list = MapperListesponse(listTipoDocumento);
            return list;
        }

        private List<TipoDocumentoResponse> MapperListesponse(List<TipoDocumento> listTipoDocumento)
        {
            List<TipoDocumentoResponse> listResponse = new List<TipoDocumentoResponse>();

            listTipoDocumento.ForEach(c =>
            {
                var tipoDocumentoResponse = mapper.Map<TipoDocumentoResponse>(c);
                listResponse.Add(tipoDocumentoResponse);
            });
            return listResponse;
        }
    }
}
