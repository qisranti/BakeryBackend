using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Application.Models
{
    public class CreateComandResponse<T> : BaseResponse
    {
        public T Entity { get; set; }

        public CreateComandResponse(T createdEntity)
        {
            Entity = createdEntity;
        }
        public CreateComandResponse(T createdEntity, string message, bool success) : base(message, success)
        {
            Entity = createdEntity;
        }

    }
}
