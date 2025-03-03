using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IBreadPreparationRepository : IBaseRepository<BreadPreparation>
    {
        Task<BreadPreparation> AddPreparationStep(int breadId, int preparationId);
        Task<BreadPreparation> AddNewPreparationStep(int breadId, string stepName, int stepDuration, int stepOrder);
    }
}
