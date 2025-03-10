﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.DTOs;
using FinalBakery.Domain.Entities;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient, IngredientsEntity>, IIngredientRepository
    {
        private readonly IMapper _mapper;
        public IngredientRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
        public async Task<Ingredient?> GetByNameAsync(string name)
        {
            var ingredientEntity = await _context.Ingredients
                .FirstOrDefaultAsync(ingredient => ingredient.Ingredient_Name == name);
            return ingredientEntity is not null ? _mapper.Map<Ingredient>(ingredientEntity) : null;
        }
        public async Task<List<Ingredient>> GetIngredients(int breadId)
        {
            var breadIngredients = await _context.BreadIngredients
                .Where(breadIngredients => breadIngredients.BreadInstanceId == breadId)
                .Select(breadIngredients => breadIngredients.IngredientId)
                .ToListAsync();

            var ingredients = await _context.Ingredients
                .Where(ingredient => breadIngredients.Contains(ingredient.Id))
                .ToListAsync();

            var ingredientsList = _mapper.Map<List<Ingredient>>(ingredients);

            return ingredientsList;
        }
    }
}
