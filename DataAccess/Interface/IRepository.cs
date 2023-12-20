using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepository<T> where T : BaseEntities
    {

        Task<List<T>> GetAll();
        Task<T?> GetById(object id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task Save();
        Task<T?> GetByParam(Expression<Func<T, bool>> obj);
        Task<List<T>> GetListByParam(Expression<Func<T, bool>> obj);
        Task<List<T>> GetAllByParamIncluding(Expression<Func<T, bool>> obj, params Expression<Func<T, object>>[] includeProperties);

    }
}
