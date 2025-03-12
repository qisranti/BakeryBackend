using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryConsoleApp.Models
{
    public class ApiEarningsResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object validationErrors { get; set; }
        public EarningsEntity entity { get; set; }
    }

    public class EarningsEntity
    {
        public int officeId { get; set; }
        public string officeName { get; set; }
        public int numberOfOrders { get; set; }
        public decimal totalPreparationCost { get; set; }
        public decimal totalSells { get; set; }
        public decimal earnings { get; set; }
    }

}
