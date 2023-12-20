using Domain.Common;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPruebaSeleccionService
    {

        Task<List<PruebaSeleccionResponse>> GetAll();
        Task<PruebaSeleccionResponse> GetId(int Id);
        Task<List<PreguntasPruebaResponse>> GetIdPreguntas(int Id);
        Task<BaseResponse> Create(PruebaSeleccionRequest pruebaSeleccionRequest);
        Task<BaseResponse> Update(PruebaSeleccionUpdateRequest pruebaSeleccionUpdateRequest);
        Task<BaseResponse> Delete(int id);
    }
}
