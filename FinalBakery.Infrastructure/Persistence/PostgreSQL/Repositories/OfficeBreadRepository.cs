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
    public class OfficeBreadRepository : BaseRepository<OfficeBread, OfficeBreadEntity>, IOfficeBreadRepository
    {
        private readonly IMapper _mapper;
        public OfficeBreadRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<Bread>> GetOfficeMenu(int officeId)
        {
            var officeBreads = await _context.OfficeBreads
                .Where(officeBreads => officeBreads.OfficeId == officeId)
                .Select(officeBreads => officeBreads.BreadId)
                .ToListAsync();

            var breads = await _context.Breads
                .Where(bread => officeBreads.Contains(bread.Id))
                .ToListAsync();

            var breadsList = _mapper.Map<List<Bread>>(breads);

            return breadsList;
        }

        public async Task<OfficeBread> AddBreadToMenu(int breadId, int officeId)
        {
            var existingOfficeBread = await _context.OfficeBreads
                .FirstOrDefaultAsync(bi => bi.BreadId == breadId && bi.OfficeId == officeId);
            if (existingOfficeBread != null)
            {
                return _mapper.Map<OfficeBread>(existingOfficeBread);
            }
            var officeBreadEntity = new OfficeBread()
            {
                BreadId = breadId,
                OfficeId = officeId,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };
            _context.OfficeBreads.Add(_mapper.Map<OfficeBreadEntity>(officeBreadEntity));
            await _context.SaveChangesAsync();

            return officeBreadEntity;
        }
    }
}
