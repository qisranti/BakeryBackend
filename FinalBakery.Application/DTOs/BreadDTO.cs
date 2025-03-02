using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Application.DTOs
{
    public class BreadDTO
    {
        public string Bread_Name { get; set; } = string.Empty;
        public float Bread_Cost { get; set; }
        public ICollection<IngredientDTO> Ingredients { get; set; } = [];
        public ICollection<PreparationDTO> Preparation { get; set; } = [];
        public AuditInfo Audit { get; set; } = default!;
    }
}
