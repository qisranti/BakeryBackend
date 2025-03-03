using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.DTOs;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Breads.Commands
{
    public class CreateBreadCommand : IRequest<CreateComandResponse<Bread>>
    {
        public BreadDTO? BreadDTO { get; set; }
    }
}
