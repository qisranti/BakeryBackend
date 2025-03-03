using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IBreadIngredientRepository : IBaseRepository<BreadIngredient>
    {
        Task<BreadIngredient> AddIngredient(int breadId, int ingredientId);

        Task<BreadIngredient> AddNewIngredient(int breadId, string ingredientName, int ingredientQuantity);
    }
}
