﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IBreadRepository : IBaseRepository<Bread>
    {
        Task<Bread?> GetByNameAsync(string name);

        Task<List<Bread>> GetAllBreads();
    }
}
