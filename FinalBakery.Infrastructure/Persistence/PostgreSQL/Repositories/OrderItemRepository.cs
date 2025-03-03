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

        public async Task<OrderItem> CreateOrderItem(int orderId, int breadId, int orderPrice, int orderQuantity)
        {
            var parentOrder = await _context.Orders
                .FirstOrDefaultAsync(bi => bi.Id == orderId);

            var officeOrder = await _context.Offices
                .FirstOrDefaultAsync(bi => bi.Id == parentOrder.OfficeId);

            var currentOrderItems = await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();

            var orderBread = await _context.Breads
                .FirstOrDefaultAsync(bi => bi.Id == breadId);
            
            if(orderPrice < orderBread.Bread_Cost)
            {
                throw new InvalidOperationException($"The sale price ({orderPrice}) can't be less than the preparation cost ({orderBread.Bread_Cost}).");
            }

            int totalQuantity = currentOrderItems.Sum(oi => oi.OrderItem_Quantity);

            if(totalQuantity + orderQuantity> officeOrder.Office_Capacity)
            {
                throw new InvalidOperationException($"The total quantity of items ({totalQuantity + orderQuantity}) exceeds the office capacity ({officeOrder.Office_Capacity}).");
            }

            var orderItem = new OrderItem()
            {
                OrderId = orderId,
                BreadId = breadId,
                OrderItem_Cost = orderPrice,
                OrderItem_Quantity = orderQuantity,
                Audit = new Domain.Common.AuditInfo
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
            };
            _context.OrderItems.Add(_mapper.Map<OrderItemEntity>(orderItem));
            await _context.SaveChangesAsync();

            return orderItem;
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
