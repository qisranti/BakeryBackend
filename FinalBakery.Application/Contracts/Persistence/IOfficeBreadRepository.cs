using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IOfficeBreadRepository : IBaseRepository<OfficeBread>
    {
        Task<List<Bread>> GetOfficeMenu(int officeId);
        Task<OfficeBread> AddBreadToMenu(int breadId, int officeId);
    }
}
