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
    public class OrderRepository : BaseRepository<Order, OrderEntity>, IOrderRepository
    {
        private readonly IMapper _mapper;
        public OrderRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var offices = await _context.Orders.ToListAsync();
            return _mapper.Map<List<Order>>(offices);
        }

        public async Task<List<Order>> GetOfficeOrders(int officeId)
        {
            var orders = await _context.Orders
                .Where(order => order.OfficeId == officeId)
                .ToListAsync();

            var ordersList = _mapper.Map<List<Order>>(orders);

            return ordersList;
        }
    }
}
