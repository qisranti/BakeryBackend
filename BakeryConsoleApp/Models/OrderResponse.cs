using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryConsoleApp.Models
{
    public class OrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object ValidationErrors { get; set; }
        public OrderEntity Entity { get; set; }
    }

    public class OrderEntity
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public decimal OrderTotalCost { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public AuditInfo Audit { get; set; }
    }

    public class OrderItem
    {
        
    }

    public class AuditInfo
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
