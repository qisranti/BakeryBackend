using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Domain.Entities;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, OrderItemEntity>, IOrderItemRepository
    {
        private readonly IMapper _mapper;
        public OrderItemRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderId(int orderId)
        {
            var orderItems = await _context.OrderItems
                .Where(orderItem => orderItem.OrderId == orderId)
                .ToListAsync();

            var orderItemsList = _mapper.Map<List<OrderItem>>(orderItems);

            return orderItemsList;
        }
    }
}
