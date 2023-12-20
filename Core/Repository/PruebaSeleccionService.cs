using AutoMapper;
using Core.Interfaces;
using DataAccess;
using DataAccess.Interface;
using Domain.Common;
using Domain.Common.Enums;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class PruebaSeleccionService : IPruebaSeleccionService
    {

        private readonly IRepository<PruebaSeleccion> repository;
        private readonly IRepository<PreguntasPrueba> repositoryPreguntas;
        private readonly IMapper mapper;
        private readonly OLSoftwareDBContext oLSoftwareDBContext;
        public PruebaSeleccionService(IRepository<PruebaSeleccion> repository, IMapper mapper, IRepository<PreguntasPrueba> repositoryPreguntas, OLSoftwareDBContext oLSoftwareDBContext)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryPreguntas = repositoryPreguntas;
            this.oLSoftwareDBContext = oLSoftwareDBContext;
        }
        public async Task<List<PruebaSeleccionResponse>> GetAll()
        {
             var listPruebaSeleccion = await repository.GetAll();
             var list = MapperListesponse(listPruebaSeleccion);
             return list;   
        }      
        private List<PruebaSeleccionResponse> MapperListesponse(List<PruebaSeleccion> listPruebaSeleccion)
        {
            List<PruebaSeleccionResponse> listResponse = new List<PruebaSeleccionResponse>();

            listPruebaSeleccion.ForEach(c =>
            {
                var Response = mapper.Map<PruebaSeleccionResponse>(c);
                listResponse.Add(Response);
            });
            return listResponse;
        }
        public async Task<PruebaSeleccionResponse> GetId(int Id)
        {
            if (Id > 0)
            {
                var pruebaSeleccion = await repository.GetById(Id);
                var response = mapper.Map<PruebaSeleccionResponse>(pruebaSeleccion);
                return response;
            }
            return null;
        }
        public async Task<List<PreguntasPruebaResponse>> GetIdPreguntas(int Id)
        {

            if (Id > 0)
            {
                var listaPreguntas = await repositoryPreguntas.GetListByParam(x => x.IdPruebaSeleccion == Id);
                var response = MapperListesponsePregunta(listaPreguntas);
                return response;
            }
            return null;

        }
        private List<PreguntasPruebaResponse> MapperListesponsePregunta(List<PreguntasPrueba> listPreguntas)
        {
            List<PreguntasPruebaResponse> listResponse = new List<PreguntasPruebaResponse>();

            listPreguntas.ForEach(c =>
            {
                var Response = mapper.Map<PreguntasPruebaResponse>(c);
                listResponse.Add(Response);
            });
            return listResponse;
        }
        public async Task<BaseResponse> Create(PruebaSeleccionRequest pruebaSeleccionRequest)
        {
            var outPut = new BaseResponse();

             if (pruebaSeleccionRequest is not null)
                {
                    var strategy = oLSoftwareDBContext.Database.CreateExecutionStrategy();

                    await strategy.ExecuteAsync(async () =>
                    {

                        using (var transaction = oLSoftwareDBContext.Database.BeginTransaction())
                        {
                            try
                            {

                                var id = await InsertPrueba(pruebaSeleccionRequest);
                                await InsertPregunta(id, pruebaSeleccionRequest.ListPreguntas);
                                await transaction.CommitAsync();
                                outPut.Mensaje = "Prueba creada con éxito";

                            }
                            catch (Exception ex)
                            {
                                await transaction.RollbackAsync();
                                outPut.Mensaje = ex.Message ?? ex.InnerException.Message;
                            }
                        }
                    });                    
                }
                else
                {
                    outPut.Mensaje = "Error en el request";
                }
         
            return outPut;
        }
        private async Task<int> InsertPrueba(PruebaSeleccionRequest pruebaSeleccionRequest)
        {
            var pruebaSeleccion = mapper.Map<PruebaSeleccion>(pruebaSeleccionRequest);
            pruebaSeleccion.CantidadPreguntas = pruebaSeleccionRequest.ListPreguntas.Count;
            pruebaSeleccion.IdEstadoPrueba = (int)EnumEstaoPrueba.Registrada;  
                pruebaSeleccion.FechaInicio = DateTime.Now;
            await repository.Insert(pruebaSeleccion);
            return pruebaSeleccion.Id;
        }
        private async Task InsertPregunta(int id, List<PreguntasPruebaRequest> ListPreguntas)
        {
            foreach (var item in ListPreguntas)
            {
                var Pregunta = mapper.Map<PreguntasPrueba>(item);
                Pregunta.IdPruebaSeleccion = id;
                await repositoryPreguntas.Insert(Pregunta);
 
            }
        }

        public async Task<BaseResponse> Update(PruebaSeleccionUpdateRequest pruebaSeleccionUpdateRequest)
        {
            var outPut = new BaseResponse();

            if (pruebaSeleccionUpdateRequest is not null)
            {
                var strategy = oLSoftwareDBContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {

                    using (var transaction = oLSoftwareDBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var pruebaSeleccion = await repository.GetById(pruebaSeleccionUpdateRequest.Id);
                            if (pruebaSeleccion != null)
                            {
                                await UpdatePrueba(pruebaSeleccion, pruebaSeleccionUpdateRequest);
                                await DeletePreguntas(pruebaSeleccionUpdateRequest.Id);
                                await InsertPregunta(pruebaSeleccionUpdateRequest.Id, pruebaSeleccionUpdateRequest.ListPreguntas);
                                await transaction.CommitAsync();
                                outPut.Mensaje = "Prueba actualizada con éxito";
                            }
                           

                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            outPut.Mensaje = ex.Message ?? ex.InnerException.Message;
                        }
                    }
                });
            }
            else
            {
                outPut.Mensaje = "Error en el request";
            }

            return outPut;
        }
        private async Task UpdatePrueba(PruebaSeleccion pruebaSeleccion, PruebaSeleccionUpdateRequest pruebaSeleccionUpdateRequest)
        {
            pruebaSeleccion.Descripcion = pruebaSeleccionUpdateRequest.Descripcion;
            pruebaSeleccion.IdAspirante = pruebaSeleccionUpdateRequest.IdAspirante;
            pruebaSeleccion.LenguajeEvaluar = pruebaSeleccionUpdateRequest.LenguajeEvaluar;
            pruebaSeleccion.LenguajeEvaluar = pruebaSeleccionUpdateRequest.LenguajeEvaluar;
            pruebaSeleccion.CantidadPreguntas = pruebaSeleccionUpdateRequest.ListPreguntas.Count;
            pruebaSeleccion.IdEstadoPrueba = pruebaSeleccionUpdateRequest.IdEstadoPrueba;
            pruebaSeleccion.Calificacion = pruebaSeleccionUpdateRequest.Calificacion;
            pruebaSeleccion.IdUsuario = pruebaSeleccionUpdateRequest.IdUsuario;
            pruebaSeleccion.FechaActualizacion = DateTime.Now;
            await repository.Update(pruebaSeleccion);          
        }
        private async Task DeletePreguntas(int idPrueba)
        {
            var listaPreguntas = await repositoryPreguntas.GetListByParam(x => x.IdPruebaSeleccion == idPrueba);
            foreach (var item in listaPreguntas)
            {
                await repositoryPreguntas.Delete(item);
            }
        }

        public async Task<BaseResponse> Delete(int id)
        {


            var outPut = new BaseResponse();

            if (id > 0 )
            {
                var strategy = oLSoftwareDBContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {

                    using (var transaction = oLSoftwareDBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var pruebaSeleccion = await repository.GetById(id);
                            if (pruebaSeleccion != null)
                            {
                              
                                await DeletePreguntas(id);
                                await DeletePrueba(pruebaSeleccion);
                                await transaction.CommitAsync();
                                outPut.Mensaje = "Prueba eliminada con éxito";
                            }


                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            outPut.Mensaje = ex.Message ?? ex.InnerException.Message;
                        }
                    }
                });
            }
            else
            {
                outPut.Mensaje = "Error en el request";
            }

            return outPut;

        }
        private async Task DeletePrueba(PruebaSeleccion pruebaSeleccion)
        {
            await repository.Delete(pruebaSeleccion);
        }
    }
}
