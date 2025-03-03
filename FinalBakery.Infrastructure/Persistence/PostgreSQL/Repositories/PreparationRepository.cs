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
            var preparationEntity = await _context.Preparations
                .FirstOrDefaultAsync(ingredient => ingredient.Step_Name == name);
            return preparationEntity is not null ? _mapper.Map<Preparation>(preparationEntity) : null;
        }

        public async Task<List<Preparation>> GetPreparations(int breadId)
        {
            var breadPreaparation = await _context.BreadPreparation
                .Where(breadPreaparation => breadPreaparation.BreadInstanceId == breadId)
                .Select(breadPreaparation => breadPreaparation.PreparationId)
                .ToListAsync();

            var preparations = await _context.Preparations
                .Where(preparation => breadPreaparation.Contains(preparation.Id))
                .ToListAsync();

            var preparationsList = _mapper.Map<List<Preparation>>(preparations);

            return preparationsList;
        }
    }
}
