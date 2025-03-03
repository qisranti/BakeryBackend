using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.DTOs
{
    public class OrderPreparationDTO
    {
        public int OrderId { get; set; }
        public int OfficeId { get; set; }
        public ICollection<OrderItemPreparationDTO> OrderItems { get; set; } = [];
    }
}
