using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.DTOs;
using FinalBakery.Domain.Entities;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;

namespace FinalBakery.Application.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            // Ingredients
            CreateMap<Ingredient, IngredientsEntity>().ReverseMap();
            CreateMap<IngredientDTO, Ingredient>().ReverseMap();
            // Preparations
            CreateMap<Preparation, PreparationEntity>().ReverseMap();
            CreateMap<PreparationDTO, Preparation>().ReverseMap();
        }
    }
}
