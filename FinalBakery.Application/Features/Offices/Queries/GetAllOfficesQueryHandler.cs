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

namespace FinalBakery.Application.Features.Offices.Queries
{
    public class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, List<Office>>
    {
        private readonly IOfficeRepository _repository;
        private readonly ILogger<GetAllOfficesQueryHandler> _logger;

        public GetAllOfficesQueryHandler(IOfficeRepository repository, ILogger<GetAllOfficesQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Office>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            var officeMenu = await _repository.GetAllOffices();
            return officeMenu;
        }
    }
}
