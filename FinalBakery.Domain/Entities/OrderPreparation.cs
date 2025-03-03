using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Domain.Entities
{
    public class OrderPreparation
    {
        public int OrderId { get; set; }
        public int OfficeId { get; set; }
        public ICollection<OrderItemPreparation> OrderItems { get; set; } = [];
    }
}
