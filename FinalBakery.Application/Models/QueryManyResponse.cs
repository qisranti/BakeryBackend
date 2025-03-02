﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBakery.Application.Models
{
    public class QueryManyResponse<T> : BaseResponse
    {
        public IEnumerable<T> Entities { get; set; }

        public QueryManyResponse(IEnumerable<T> entities)
        {
            Entities = entities;
        }

        public QueryManyResponse(IEnumerable<T> entities, string message, bool success) : base(message, success)
        {
            Entities = entities;
        }
    }
}
