using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Domain.Entities
{
    public class OfficeEarnings
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; } = string.Empty;
        public int NumberOfOrders { get; set; }
        public int TotalPreparationCost { get; set; }
        public int TotalSells { get; set; }
        public int Earnings { get; set; }
    }
}
