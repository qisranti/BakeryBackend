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
    public class PreparationRepository : BaseRepository<Preparation, PreparationEntity>, IPreparationRepository
    {
        private readonly IMapper _mapper;
        public PreparationRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
        public async Task<Preparation?> GetByNameAsync(string name)
        {
            var preparationEntity = await _context.Praparations
                .FirstOrDefaultAsync(ingredient => ingredient.Step_Name == name);
            return preparationEntity is not null ? _mapper.Map<Preparation>(preparationEntity) : null;
        }
    }
}
