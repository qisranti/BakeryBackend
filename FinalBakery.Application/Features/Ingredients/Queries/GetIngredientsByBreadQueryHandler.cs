using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Ingredients.Queries
{
    public class GetIngredientsByBreadQueryHandler : IRequestHandler<GetIngredientsByBreadQuery, List<Ingredient>>
    {
        private readonly IIngredientRepository _repository;
        private readonly ILogger<GetIngredientsByBreadQueryHandler> _logger;

        public GetIngredientsByBreadQueryHandler(IIngredientRepository repository, ILogger<GetIngredientsByBreadQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Ingredient>> Handle(GetIngredientsByBreadQuery request, CancellationToken cancellationToken)
        {
            var listOfIngredients = await _repository.GetIngredients(request.BreadId);
            return listOfIngredients;
        }
    }
}
