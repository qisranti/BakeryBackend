using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Domain.Common
{
    public class AuditInfo
    {
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set;} = string.Empty;
        public DateTime CreatedDate { get; set;}
        public DateTime? UpdatedDate { get; set;}
    }
}
