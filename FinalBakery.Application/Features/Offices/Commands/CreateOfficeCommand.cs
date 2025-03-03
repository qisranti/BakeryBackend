using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.DTOs;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Offices.Commands
{
    public class CreateOfficeCommand : IRequest<CreateComandResponse<Office>>
    {
        public OfficeDTO? OfficeDto { get; set; }
    }
}
