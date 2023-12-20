using AutoMapper;
using Core.Interfaces;
using DataAccess.Interface;
using Domain.Common;
using Domain.DTO;
using Domain.Entities;

namespace Core.Repository
{
    public class AspiranteService: IAspiranteService
    {

        private readonly IRepository<Aspirante> repository;
        private readonly IMapper mapper;

        public AspiranteService(IRepository<Aspirante> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public async Task<List<AspiranteResponse>> GetAll()
        {
            
            var listAspìrante = await repository.GetAll();
            var list = MapperListesponse(listAspìrante);
            return list;
        }      
        private List<AspiranteResponse> MapperListesponse(List<Aspirante> listAspirante)
        {
            List<AspiranteResponse> listResponse = new List<AspiranteResponse>();

            listAspirante.ForEach(c =>
            {
                var Response = mapper.Map<AspiranteResponse>(c);
                listResponse.Add(Response);
            });
            return listResponse;
        }
        public async Task<AspiranteResponse> GetId(int Id)
        {
            if (Id > 0)
            {                 
                var aspìrante = await repository.GetById(Id);
                var Response = mapper.Map<AspiranteResponse>(aspìrante);
                return Response;
            }
            return null;
        }
        public async Task<BaseResponse> Create(AspiranteRequest aspiranteRequest)
        {
            var outPut = new BaseResponse();
            try
            {
                if (aspiranteRequest is not null) {
                    var candidato = mapper.Map<Aspirante>(aspiranteRequest);
                    await repository.Insert(candidato);
                    outPut.Mensaje = "Aspirante creado con éxito";
                }
                else
                {
                    outPut.Mensaje = "Eror en el request";
                }             
            }
            catch (Exception ex )
            {
                outPut.Mensaje = ex.Message ?? ex.InnerException.Message;                
            }
            return outPut;
        }
        public async Task<BaseResponse> Update(AspiranteUpdateRequest aspiranteRequest)
        {
            var outPut = new BaseResponse();
            try
            {
                var aspìrante = await repository.GetById(aspiranteRequest.Id);
                if (aspìrante is not null)
                {
                    await updateAspirante(aspìrante, aspiranteRequest);
                    outPut.Mensaje = "Aspirante actualizado con éxito";
                }
                else
                {
                    outPut = null;
                }
            }
            catch (Exception ex)
            {
                outPut.Mensaje = ex.Message ?? ex.InnerException.Message;
            }
            return outPut;
        }
        private async Task updateAspirante(Aspirante aspirante, AspiranteUpdateRequest aspiranteRequest)
        {
            aspirante.Nombres = aspiranteRequest.Nombres;
            aspirante.Email = aspiranteRequest.Email;
            aspirante.Telefono = aspiranteRequest.Telefono;
            aspirante.IdTipoDocumento = aspiranteRequest.IdTipoDocumento;
            aspirante.NumDocumento = aspiranteRequest.NumDocumento;
            aspirante.IdUsuario = aspiranteRequest.IdUsuario;
            aspirante.FechaActualizacion = DateTime.Now;
            await repository.Update(aspirante);
        }
        public async Task<BaseResponse> Delete(int id)
        {
            var outPut = new BaseResponse();
            try
            {
                var aspìrante = await repository.GetById(id);
                if (aspìrante is not null)
                {
                    await DeleteAspirante(aspìrante);
                    outPut.Mensaje = "Aspirante eliminado con éxito";
                }
                else
                {
                    outPut = null;
                }
            }
            catch (Exception ex)
            {
                outPut.Mensaje = ex.Message ?? ex.InnerException.Message;
            }
            return outPut;
        }
        private async Task DeleteAspirante(Aspirante aspirante)
        {
            await repository.Delete(aspirante);
        }



    }
}
