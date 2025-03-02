using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories
{
    public class BaseRepository<TDomain, TPersist> : IBaseRepository<TDomain>
        where TDomain : class
        where TPersist : class
    {
        protected readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public BaseRepository(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TDomain> AddAsync(TDomain entity)
        {
            var persistenceEntity = _mapper.Map<TPersist>(entity);
            var response = await _context.Set<TPersist>().AddAsync(persistenceEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDomain>(response.Entity);
        }

        public async Task DeleteAsync(TDomain entity)
        {
            var persistenceEntity = _mapper.Map<TPersist>(entity);
            _context.Set<TPersist>().Remove(persistenceEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<TDomain?> GetByIdAsync(int id)
        {
            var persistenceEntity = await _context.Set<TPersist>().FindAsync(id);
            return persistenceEntity != null ? _mapper.Map<TDomain>(persistenceEntity) : null;
        }
        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            var persistenceEntities = await _context.Set<TPersist>().ToListAsync();
            return _mapper.Map<IEnumerable<TDomain>>(persistenceEntities);
        }


        public async Task<IEnumerable<TDomain>> GetPagedAsync(int page, int pageSize)
        {
            var persistenceEntities = await _context.Set<TPersist>()
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return _mapper.Map<IEnumerable<TDomain>>(persistenceEntities);
        }

        public async Task<TDomain> UpdateAsync(TDomain entity)
        {
            var persistenceEntity = _mapper.Map<TPersist>(entity);
            _context.Set<TPersist>().Update(persistenceEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDomain>(persistenceEntity);
        }
    }
}
