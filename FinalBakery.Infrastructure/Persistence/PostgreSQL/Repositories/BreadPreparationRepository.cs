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
    public class BreadPreparationRepository : BaseRepository<BreadPreparation, BreadInstancePreparationEntity>, IBreadPreparationRepository
    {
        private readonly IMapper _mapper;
        public BreadPreparationRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<BreadPreparation> AddPreparationStep(int breadId, int preparationId)
        {
            var breadPreparationEntity = new BreadPreparation()
            {
                BreadInstanceId = breadId,
                PreparationId = preparationId,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };
            _context.BreadPreparation.Add(_mapper.Map<BreadInstancePreparationEntity>(breadPreparationEntity));
            await _context.SaveChangesAsync();

            return breadPreparationEntity;
        }

        public async Task<BreadPreparation> AddNewPreparationStep(int breadId, string stepName, int stepDuration, int stepOrder)
        {
            var preparation = new Preparation
            {
                Step_Name = stepName,
                Step_Duration = stepDuration,
                Step_Order = stepOrder,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };
            _context.Preparations.Add(_mapper.Map<PreparationEntity>(preparation));
            await _context.SaveChangesAsync();

            var createdPreparation = await _context.Preparations
                                  .FirstOrDefaultAsync(i => i.Step_Name == stepName && i.Step_Duration == stepDuration && i.Step_Order == stepOrder);

            if (createdPreparation == null)
            {
                throw new Exception("Error white trying to get preparation id.");
            }

            var breadPreparation = new BreadPreparation()
            {
                BreadInstanceId = breadId,
                PreparationId = createdPreparation.Id,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };

            _context.BreadPreparation.Add(_mapper.Map<BreadInstancePreparationEntity>(breadPreparation));
            await _context.SaveChangesAsync();

            return breadPreparation;
        }
    }
}
