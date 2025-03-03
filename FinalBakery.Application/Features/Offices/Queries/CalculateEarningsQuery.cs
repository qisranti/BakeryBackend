using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Offices.Queries
{
    public class CalculateEarningsQuery : IRequest<CreateComandResponse<OfficeEarnings>>
    {
        public int OfficeId { get; set; }
    }
}
