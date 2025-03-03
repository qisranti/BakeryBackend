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
            //Chefs
            CreateMap<Chef, ChefEntity>().ReverseMap();
            CreateMap<ChefDTO, Chef>().ReverseMap();
            //Breads
            CreateMap<Bread, BreadEntity>().ReverseMap();
            CreateMap<BreadDTO, Bread>().ReverseMap();
            //Bread Ingredient
            CreateMap<BreadIngredient, BreadInstanceIngredientEntity>().ReverseMap();
            CreateMap<BreadIngredientDTO, BreadIngredient>().ReverseMap();
            //Bread Preparation
            CreateMap<BreadPreparation, BreadInstancePreparationEntity>().ReverseMap();
            CreateMap<BreadPreparationDTO, BreadPreparation>().ReverseMap();
            //Offices
            CreateMap<Office, OfficeEntity>().ReverseMap();
            CreateMap<OfficeDTO, Office>().ReverseMap();
            //Office Breads
            CreateMap<OfficeBread, OfficeBreadEntity>().ReverseMap();
            CreateMap<OfficeBreadDTO, OfficeBread>().ReverseMap();
            //Orders
            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            //OrderItem
            CreateMap<OrderItem, OrderItemEntity>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();
        }
    }
}
