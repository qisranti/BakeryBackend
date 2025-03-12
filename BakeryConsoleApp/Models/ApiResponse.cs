using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryConsoleApp.Models
{
    public class ApiResponse
    {
        public object entity { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public object validationErrors { get; set; }
    }

}
