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
    internal class PrepareOrdersRepository : IPrepareOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PrepareOrdersRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<OrderPreparation>> PrepareOfficeOrders(int officeId)
        {
            var orders = await _context.Orders
                        .Where(o => o.OfficeId == officeId && o.Order_Status != 1)
                        .ToListAsync();

            var orderPreparations = new List<OrderPreparation>();


            foreach (var order in orders)
            {
                var orderItems = await _context.OrderItems
                    .Where(oi => oi.OrderId == order.Id)
                    .Include(oi => oi.Bread)
                    .ToListAsync();

                var orderPreparation = new OrderPreparation
                {
                    OrderId = order.Id,
                    OfficeId = order.OfficeId,
                    OrderItems = new List<OrderItemPreparation>()
                };

                foreach (var orderItem in orderItems)
                {
                    
                    var preparationSteps = await _context.BreadPreparation
                        .Where(bp => bp.BreadInstanceId == orderItem.BreadId)
                        .Select(bp => bp.Preparation)
                        .OrderBy(ps => ps.Step_Order)
                        .ToListAsync();

                    var preparationStepsDomain = _mapper.Map<List<Preparation>>(preparationSteps);

                    var orderItemPreparation = new OrderItemPreparation
                    {
                        BreadId = orderItem.BreadId,
                        BreadName = orderItem.Bread.Bread_Name,
                        PreparationSteps = preparationStepsDomain
                    };

                    orderPreparation.OrderItems.Add(orderItemPreparation);
                }

                orderPreparations.Add(orderPreparation);

                order.Order_Status = 1;
            }
            await _context.SaveChangesAsync();

            return orderPreparations;
        }
    }
}
