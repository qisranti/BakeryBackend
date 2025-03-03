using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Domain.Entities;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories
{
    public class BreadIngredientRepository : BaseRepository<BreadIngredient, BreadInstanceIngredientEntity>, IBreadIngredientRepository
    {
        private readonly IMapper _mapper;
        public BreadIngredientRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<BreadIngredient> AddIngredient(int breadId, int ingredientId)
        {
            var existingBreadIngredient = await _context.BreadIngredients
                .FirstOrDefaultAsync(bi => bi.BreadInstanceId == breadId && bi.IngredientId == ingredientId);
            if (existingBreadIngredient != null)
            {
                return _mapper.Map<BreadIngredient>(existingBreadIngredient);
            }
            var breadIngredientEntity = new BreadIngredient()
            {
                BreadInstanceId = breadId,
                IngredientId = ingredientId,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };
            _context.BreadIngredients.Add(_mapper.Map<BreadInstanceIngredientEntity>(breadIngredientEntity));
            await _context.SaveChangesAsync();

            return breadIngredientEntity;
        }

        public async Task<BreadIngredient> AddNewIngredient(int breadId, string ingredientName, int ingredientQuantity)
        {
            var ingredient = new Ingredient
            {
                Ingredient_Name = ingredientName,
                Ingredient_Quantity = ingredientQuantity,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };
            _context.Ingredients.Add(_mapper.Map<IngredientsEntity>(ingredient));
            await _context.SaveChangesAsync();

            var createdIngredient = await _context.Ingredients
                                  .FirstOrDefaultAsync(i => i.Ingredient_Name == ingredientName && i.Ingredient_Quantity == ingredientQuantity);

            if (createdIngredient == null)
            {
                throw new Exception("Error al obtener el ID del ingrediente.");
            }

            var breadIngredient = new BreadIngredient()
            {
                BreadInstanceId = breadId,
                IngredientId = createdIngredient.Id,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };

            _context.BreadIngredients.Add(_mapper.Map<BreadInstanceIngredientEntity>(breadIngredient));
            await _context.SaveChangesAsync();

            return breadIngredient;
        }
    }
}
