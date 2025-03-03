using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Domain.Entities;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories
{
    public class ChefRepository : BaseRepository<Chef, ChefEntity>, IChefRepository
    {
        private readonly IMapper _mapper;
        public ChefRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<Chef>> GetAllChefs()
        {
            var chefs = await _context.Chefs.ToListAsync();
            return _mapper.Map<List<Chef>>(chefs);
        }

        public async Task<Chef?> GetByNameAsync(string name)
        {
            var chefEntity = await _context.Chefs
                .FirstOrDefaultAsync(chef => chef.Chef_Name == name);
            return chefEntity is not null ? _mapper.Map<Chef>(chefEntity) : null;
        }
    }
}
