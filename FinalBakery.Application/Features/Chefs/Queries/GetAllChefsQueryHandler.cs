using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Breads.Queries;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Chefs.Queries
{
    public class GetAllChefsQueryHandler : IRequestHandler<GetAllChefsQuery, List<Chef>>
    {
        private readonly IChefRepository _repository;
        private readonly ILogger<GetAllChefsQueryHandler> _logger;

        public GetAllChefsQueryHandler(IChefRepository repository, ILogger<GetAllChefsQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Chef>> Handle(GetAllChefsQuery request, CancellationToken cancellationToken)
        {
            var officeMenu = await _repository.GetAllChefs();
            return officeMenu;
        }
    }
}
