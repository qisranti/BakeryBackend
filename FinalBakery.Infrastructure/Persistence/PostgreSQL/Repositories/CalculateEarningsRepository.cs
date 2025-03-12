using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories
{
    public class CalculateEarningsRepository : ICalculateEarningsRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CalculateEarningsRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OfficeEarnings> CalculateOfficeEarnings(int officeId)
        {
            var orders = await _context.Orders
                        .Where(o => o.OfficeId == officeId && o.Order_Status == 1 && o.Audit.CreatedDate.Date == DateTime.UtcNow.Date)
                        .ToListAsync();
            
            int numberOfOrders = orders.Count();
            int totalPreparationCost = 0;
            int totalSells = 0;

            foreach (var order in orders)
            {
                var orderItems = await _context.OrderItems
                    .Where(oi => oi.OrderId == order.Id)
                    .Include(oi => oi.Bread)
                    .ToListAsync();
                foreach (var orderItem in orderItems)
                {
                    var breads = await _context.Breads
                        .FirstOrDefaultAsync(bread => bread.Id == orderItem.BreadId);
                    
                    totalPreparationCost = (int)(totalPreparationCost + (breads.Bread_Cost)*orderItem.OrderItem_Quantity);

                    totalSells = (int)(totalSells + (orderItem.OrderItem_Cost * orderItem.OrderItem_Quantity));
                }
            }
            var officeEarnings = new OfficeEarnings() 
            {
                OfficeId = officeId,
                OfficeName = "",
                NumberOfOrders = numberOfOrders,
                TotalPreparationCost = totalPreparationCost,
                TotalSells = totalSells,
                Earnings = totalSells - totalPreparationCost
            };

            return officeEarnings;
        }
        
    }
}
