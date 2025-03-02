using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize);
        Task<T?> GetByIdAsync(int id);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
