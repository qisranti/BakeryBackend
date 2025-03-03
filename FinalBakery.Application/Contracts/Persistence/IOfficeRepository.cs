using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IOfficeRepository : IBaseRepository<Office>
    {
        Task<Office?> GetByNameAsync(string officeName);

        Task<List<Office>> GetAllOffices();

        Task<Office> AssignChefAsync(int chefId, int officeId);

    }
}
