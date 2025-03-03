using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Ingredients.Queries
{
    public class GetIngredientsByBreadQuery : IRequest<List<Ingredient>>
    {
        public int BreadId { get; set; }
    }
}
