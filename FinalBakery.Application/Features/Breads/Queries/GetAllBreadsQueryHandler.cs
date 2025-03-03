using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Offices.Queries;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Breads.Queries
{
    public class GetAllBreadsQueryHandler : IRequestHandler<GetAllBreadsQuery, List<Bread>>
    {
        private readonly IBreadRepository _repository;
        private readonly ILogger<GetAllBreadsQueryHandler> _logger;

        public GetAllBreadsQueryHandler(IBreadRepository repository, ILogger<GetAllBreadsQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Bread>> Handle(GetAllBreadsQuery request, CancellationToken cancellationToken)
        {
            var officeMenu = await _repository.GetAllBreads();
            return officeMenu;
        }
    }
}
