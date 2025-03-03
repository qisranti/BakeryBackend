using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IChefRepository : IBaseRepository<Chef>
    {
        Task<Chef?> GetByNameAsync(string name);

        Task<List<Chef>> GetAllChefs();
    }
}
