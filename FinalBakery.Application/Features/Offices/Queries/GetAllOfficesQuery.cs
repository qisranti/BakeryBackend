using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Offices.Queries
{
    public class GetAllOfficesQuery : IRequest<List<Office>> { }
}
