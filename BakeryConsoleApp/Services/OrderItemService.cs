using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryConsoleApp.Models;
using Newtonsoft.Json;

namespace BakeryConsoleApp.Services
{
    public class OrderItemService
    {
        public async Task<bool> CreateOrderItemAsync(HttpClient client, int orderId, int breadId, int price, int quantity)
        {
            var url = $"OrderItems/createOrderItem?orderId={orderId}&breadId={breadId}&orderItemPrice={price}&orderItemQuantity={quantity}";
            var response = await client.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);

            if (apiResponse.success)
            {
                Console.WriteLine("¡Pedido realizado con éxito!");
                return true;
            }
            else
            {
                Console.WriteLine($"Error al realizar el pedido: {apiResponse.message}");
                return false;
            }
        }
    }
}
