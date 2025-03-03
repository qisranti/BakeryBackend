using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Preparations.Queries
{
    public class GetPreparationStepsByBreadQuery : IRequest<List<Preparation>>
    {
        public int BreadId { get; set; }
    }
}
