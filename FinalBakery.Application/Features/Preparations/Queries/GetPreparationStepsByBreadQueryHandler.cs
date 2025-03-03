using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Ingredients.Queries;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Preparations.Queries
{
    public class GetPreparationStepsByBreadQueryHandler : IRequestHandler<GetPreparationStepsByBreadQuery, List<Preparation>>
    {
        private readonly IPreparationRepository _repository;
        private readonly ILogger<GetPreparationStepsByBreadQueryHandler> _logger;

        public GetPreparationStepsByBreadQueryHandler(IPreparationRepository repository, ILogger<GetPreparationStepsByBreadQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Preparation>> Handle(GetPreparationStepsByBreadQuery request, CancellationToken cancellationToken)
        {
            var listOfPreparationSteps = await _repository.GetPreparations(request.BreadId);
            return listOfPreparationSteps;
        }
    }
}
