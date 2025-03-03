using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Breads.Queries
{
    public class GetOfficeMenuQuery : IRequest<List<Bread>>
    {
        public int OfficeId { get; set; }
    }
}
