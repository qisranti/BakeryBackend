using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.DTOs;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<Ingredient?> GetByNameAsync(string name);

        Task<List<Ingredient>> GetIngredients(int breadId);
    }
}
