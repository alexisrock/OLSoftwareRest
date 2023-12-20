using Domain.Common;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAspiranteService
    {
        Task<List<AspiranteResponse>> GetAll();
        Task<AspiranteResponse> GetId(int Id);
        Task<BaseResponse> Create(AspiranteRequest aspiranteRequest);
        Task<BaseResponse> Update(AspiranteUpdateRequest aspiranteRequest);
        Task<BaseResponse> Delete(int id);

    }
}
