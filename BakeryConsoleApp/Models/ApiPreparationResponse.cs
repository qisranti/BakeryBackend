using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryConsoleApp.Models
{
    public class ApiPreparationResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object validationErrors { get; set; }
        public List<PreparationResponse> entity { get; set; }
    }

    public class PreparationResponse
    {
        public int orderId { get; set; }
        public int officeId { get; set; }
        public List<PreparationOrderItem> orderItems { get; set; }
    }

    public class PreparationOrderItem
    {
        public int breadId { get; set; }
        public string breadName { get; set; }
        public decimal orderItem_Cost { get; set; }
        public int orderItem_Quantity { get; set; }
        public List<PreparationStep> preparationSteps { get; set; }
    }

    public class PreparationStep
    {
        public string step_Name { get; set; }
        public int step_Duration { get; set; }
        public int step_Order { get; set; }
        public PreparationAuditInfo audit { get; set; }
    }

    public class PreparationAuditInfo
    {
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
    }


}
