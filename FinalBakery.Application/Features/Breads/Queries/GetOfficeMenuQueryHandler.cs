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

namespace FinalBakery.Application.Features.Breads.Queries
{
    public class GetOfficeMenuQueryHandler : IRequestHandler<GetOfficeMenuQuery, List<Bread>>
    {
        private readonly IOfficeBreadRepository _repository;
        private readonly ILogger<GetOfficeMenuQueryHandler> _logger;

        public GetOfficeMenuQueryHandler(IOfficeBreadRepository repository, ILogger<GetOfficeMenuQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Bread>> Handle(GetOfficeMenuQuery request, CancellationToken cancellationToken)
        {
            var officeMenu = await _repository.GetOfficeMenu(request.OfficeId);
            return officeMenu;
        }
    }
}
