using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepositoryUsuario
    {
        Task<Usuario?> GetByParam(string username);

    }
}
