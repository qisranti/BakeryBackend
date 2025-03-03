using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.DTOs
{
    public class OrderItemPreparationDTO
    {
        public int BreadId { get; set; }
        public string BreadName { get; set; } = string.Empty;
        public int OrderItem_Cost { get; set; }
        public int OrderItem_Quantity { get; set; }
        public ICollection<Preparation> PreparationSteps { get; set; } = [];
    }
}
