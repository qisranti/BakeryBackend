using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.Contracts.Persistence
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<List<OrderItem>> GetOrderItemsByOrderId(int orderId);

        Task<OrderItem> CreateOrderItem(int orderId, int breadId, int orderPrice, int orderQuantity);
    }
}
