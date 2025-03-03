using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.DTOs;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Breads.Commands
{
    public class AddNewIngredientCommand : IRequest<CreateComandResponse<BreadIngredient>>
    {
        public int BreadId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public int IngredientQuantity { get; set; }
    }
}
