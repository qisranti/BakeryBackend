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
    public class OfficeRepository : BaseRepository<Office, OfficeEntity>, IOfficeRepository
    {
        private readonly IMapper _mapper;
        public OfficeRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<Office> AssignChefAsync(int chefId, int officeId)
        {
            var chef = await _context.Chefs.FindAsync(chefId);
            if (chef == null)
            {
                throw new ArgumentException("Selected Chef doesn't exist");
            }
            var office = await _context.Offices.FindAsync(officeId);
            if (office == null)
            {
                throw new ArgumentException("Selected Office doesn't exist");
            }
            office.ChefId = chefId;

            bool breadExists = await _context.OfficeBreads
                             .AnyAsync(ob => ob.OfficeId == officeId && ob.BreadId == chef.SpecialtyBreadId);

            if (!breadExists)
            {
                var newOfficeBread = new OfficeBreadEntity
                {
                    OfficeId = officeId,
                    BreadId = chef.SpecialtyBreadId,
                    Audit = new Domain.Common.AuditInfo
                    {
                        CreatedBy = "Isra",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    }
                };

                _context.OfficeBreads.Add(newOfficeBread);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Office>(office);
        }

        public async Task<List<Office>> GetAllOffices()
        {
            var offices = await _context.Offices.ToListAsync();
            return _mapper.Map<List<Office>>(offices);
        }

        public async Task<Office?> GetByNameAsync(string officeName)
        {
            var officeEntity = await _context.Offices
                .FirstOrDefaultAsync(office => office.Office_Name == officeName);
            return officeEntity is not null ? _mapper.Map<Office>(officeEntity) : null;
        }
    }
}
