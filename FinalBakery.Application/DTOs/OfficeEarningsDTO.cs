using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Application.DTOs
{
    public class OfficeEarningsDTO
    {
        public int OfficeId { get; set; }
        public int NumberOfOrders { get; set; }
        public int TotalPreparationCost { get; set; }
        public int TotalSells { get; set; }
        public int Earnings { get; set; }
    }
}
