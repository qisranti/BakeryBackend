using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Application.Models
{
    public class GetQueryResponse<T> : BaseResponse
    {
        public T Body { get; set; }

        public GetQueryResponse(T body)
        {
            Body = body;
        }

        public GetQueryResponse(T body, string message, bool success) : base(message, success)
        {
            Body = body;
        }

    }
}
