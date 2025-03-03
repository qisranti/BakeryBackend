using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Breads.Commands
{
    public class AddNewPreparationStepCommand : IRequest<CreateComandResponse<BreadPreparation>>
    {
        public int BreadId { get; set; }
        public string StepName { get; set; } = string.Empty;
        public int StepDuration { get; set; }
        public int StepOrder { get; set; }
    }
}
