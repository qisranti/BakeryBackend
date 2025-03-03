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
    public class BreadRepository : BaseRepository<Bread, BreadEntity>, IBreadRepository
    {
        private readonly IMapper _mapper;
        public BreadRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<Bread>> GetAllBreads()
        {
            var breads = await _context.Breads.ToListAsync();
            return _mapper.Map<List<Bread>>(breads);
        }

        public async Task<Bread?> GetByNameAsync(string name)
        {
            var breadEntity = await _context.Breads
                .FirstOrDefaultAsync(chef => chef.Bread_Name == name);
            return breadEntity is not null ? _mapper.Map<Bread>(breadEntity) : null;
        }

    }
}
